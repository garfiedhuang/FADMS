using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garfield.BLL
{
    public partial class Reports_FZ
    {
        private readonly Garfield.DAL.Reports_FZ dal = new Garfield.DAL.Reports_FZ();
        private static DataTable dtFz_Czsr;
        private static DataTable dtFz_Czsr_Ys;
        private static DataTable dtFz_Pay;
        private static DataTable dtFz_Pay_Ys;
        private static DataTable dtFz_Zbxx;
        private static DataTable dtFz_Zysr;
        public Reports_FZ()
        {
            //dtFz_Czsr = dal.GetCZSR("");
            //dtFz_Czsr_Ys = dal.GetCZSR_YS("");
            //dtFz_Pay = dal.GetPAY("");
            //dtFz_Pay_Ys = dal.GetPAY_YS("");
            //dtFz_Zbxx = dal.GetZBXX("");
            //dtFz_Zysr = dal.GetZYSR("");
        }
        #region  Method

        public string GetMenuTree(int emp_id)
        {
            try
            {
                var _dtMenu = dal.GetMenuTree($" AND a.empID='{emp_id}'");
                var _htmlMenu = new StringBuilder();
                //<a href="index.html">首页</a>
                //<a href="taxRevenue.html">税收收入分析</a>
                //<a href="notTaxRevenue.html">非税收入分析</a>
                //<a href="transferIncome.html">转移性收入</a>
                //<a href="fundsAnalysis.html">三公经费分析</a>
                //<a href="login.html">退出</a>
                using (_dtMenu)
                {
                    if (_dtMenu != null && _dtMenu.Rows.Count > 0)
                    {
                        foreach (DataRow dr in _dtMenu.Rows)
                        {
                            _htmlMenu.Append($"<a href=\"{dr["Menu_url"].ToString()}\">{dr["Menu_name"].ToString()}</a>");
                        }
                        _htmlMenu.Append($"<a onclick=\"javascript:logout();\">退出</a>");
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                return _htmlMenu.ToString();
            }
            catch// (Exception ex)
            {
                return string.Empty;
            }
        }

        public dynamic GetReports_FZ_Index(int year)
        {
            try
            {
                dtFz_Czsr = dal.GetCZSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year}'");
                dtFz_Czsr_Ys = dal.GetCZSR_YS($" AND INCOME_TIME='{year}'");
                dtFz_Pay = dal.GetPAY($" AND DATE_FORMAT(PAY_TIME,'%Y')='{year}'");
                dtFz_Pay_Ys = dal.GetPAY_YS($" AND PAY_TIME='{year}'");

                #region //财政收入
                var _sssr = 0m;
                var _fssr = 0m;
                var _zwsr = 0m;
                var _zysr = 0m;
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    var _drTemp = dtFz_Czsr.AsEnumerable().Where(s => 1 == 1).ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _sssr = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<string>("INCOME_TYPE").ToString() == "FSSR").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _fssr = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<string>("INCOME_TYPE").ToString() == "ZWSR").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _zwsr = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<string>("INCOME_TYPE").ToString() == "ZYSR").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _zysr = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                }
                var _governmentReceipts = new
                {
                    name = "财政收入",
                    data = new List<dynamic>(){
                        new {
                        name="税收收入",
                        value=string.Format("{0:N}",_sssr) },
                        new {
                        name="非税收入",
                        value=string.Format("{0:N}",_fssr) },
                        new {
                        name="债务收入",
                        value=string.Format("{0:N}",_zwsr) },
                        new {
                        name="转移性收入",
                        value=string.Format("{0:N}",_zysr) }
                    }
                };
                #endregion

                #region //税收收入
                var _firstQuarter = 0m;
                var _secondeQuarter = 0m;
                var _thirdQuarter = 0m;
                var _fourthQuarter = 0m;
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    var _drTempSSSR = dtFz_Czsr.AsEnumerable().Where(s => s.Field<string>("INCOME_TYPE").ToString() == "SSSR").ToList();
                    if (_drTempSSSR != null && _drTempSSSR.Count > 0)
                    {
                        var _drTemp = _drTempSSSR.Where(s => "01,02,03".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _firstQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                        _drTemp = _drTempSSSR.Where(s => "04,05,06".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _secondeQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                        _drTemp = _drTempSSSR.Where(s => "07,08,09".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _thirdQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                        _drTemp = _drTempSSSR.Where(s => "10,11,12".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _fourthQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    }
                }
                var _taxRevenue = new
                {
                    name = "税收收入",
                    data = new List<dynamic>(){
                        new {
                        name="第一季度",
                        value=_firstQuarter },
                        new {
                        name="第二季度",
                        value=_secondeQuarter },
                        new {
                        name="第三季度",
                        value=_thirdQuarter },
                        new {
                        name="第四季度",
                        value=_fourthQuarter }
                    }
                };
                #endregion

                #region //非税收入
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    var _drTempFSSR = dtFz_Czsr.AsEnumerable().Where(s => s.Field<string>("INCOME_TYPE").ToString() == "FSSR").ToList();
                    if (_drTempFSSR != null && _drTempFSSR.Count > 0)
                    {
                        var _drTemp = _drTempFSSR.Where(s => "01,02,03".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _firstQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                        _drTemp = _drTempFSSR.Where(s => "04,05,06".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _secondeQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                        _drTemp = _drTempFSSR.Where(s => "07,08,09".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _thirdQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                        _drTemp = _drTempFSSR.Where(s => "10,11,12".Contains(s.Field<DateTime>("INCOME_TIME").ToString("MM"))).ToList();
                        if (_drTemp != null && _drTemp.Count > 0) _fourthQuarter = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    }
                }
                var _notTaxRevenue = new
                {
                    name = "非税收入",
                    data = new List<dynamic>(){
                        new {
                        name="第一季度",
                        value=_firstQuarter },
                        new {
                        name="第二季度",
                        value=_secondeQuarter },
                        new {
                        name="第三季度",
                        value=_thirdQuarter },
                        new {
                        name="第四季度",
                        value=_fourthQuarter }
                    }
                };
                #endregion

                #region //收入合计
                var _totalRevenueValue = 0m;
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    _totalRevenueValue = dtFz_Czsr.AsEnumerable().Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                }
                var _totalRevenue = new
                {
                    name = "收入合计",
                    value = string.Format("{0:N}", _totalRevenueValue)
                };
                #endregion

                #region //收入进度
                var _advanceValue = 0m;
                var _incomeProgressValue = 0m;
                if (dtFz_Czsr_Ys != null && dtFz_Czsr_Ys.Rows.Count > 0)
                {
                    _advanceValue = dtFz_Czsr_Ys.AsEnumerable().Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    _incomeProgressValue = Math.Round((_totalRevenueValue / _advanceValue) * 100, 2);
                    if (_incomeProgressValue > 100) _incomeProgressValue = 100;
                }
                var _incomeProgress = new
                {
                    name = "收入进度",
                    data = new List<dynamic>(){
                        new {
                        name="完成率",
                        value=_incomeProgressValue } }
                };
                #endregion

                #region //支出合计
                var _totalExpenditureValue = 0m;
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    _totalExpenditureValue = dtFz_Pay.AsEnumerable().Sum(s => s.Field<decimal>("PAY_MONEY"));
                }
                var _totalExpenditure = new
                {
                    name = "支出合计",
                    value = string.Format("{0:N}", _totalExpenditureValue)
                };
                #endregion

                #region //支出进度
                var _advancePayValue = 0m;
                var _payProgressValue = 0m;
                if (dtFz_Pay_Ys != null && dtFz_Pay_Ys.Rows.Count > 0)
                {
                    _advancePayValue = dtFz_Pay_Ys.AsEnumerable().Sum(s => s.Field<decimal>("PAY_MONEY"));
                    _payProgressValue = Math.Round((_totalExpenditureValue / _advancePayValue) * 100, 2);
                    if (_payProgressValue > 100) _payProgressValue = 100;
                }
                var _payProgress = new
                {
                    name = "支出进度",
                    data = new List<dynamic>(){
                        new {
                        name="完成率",
                        value=_payProgressValue } }
                };
                #endregion

                #region //全年收支状况
                var _incomeJanurary = 0m;
                var _incomeFebruary = 0m;
                var _incomeMarch = 0m;
                var _incomeApril = 0m;
                var _incomeMay = 0m;
                var _incomeJune = 0m;
                var _incomeJuly = 0m;
                var _incomeAugust = 0m;
                var _incomeSeptember = 0m;
                var _incomeOctober = 0m;
                var _incomeNovember = 0m;
                var _incomeDecember = 0m;
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeJanurary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeFebruary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeMarch = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeApril = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeMay = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeJune = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeJuly = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeAugust = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeSeptember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeOctober = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeNovember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _incomeDecember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    #endregion
                }

                var _payJanurary = 0m;
                var _payFebruary = 0m;
                var _payMarch = 0m;
                var _payApril = 0m;
                var _payMay = 0m;
                var _payJune = 0m;
                var _payJuly = 0m;
                var _payAugust = 0m;
                var _paySeptember = 0m;
                var _payOctober = 0m;
                var _payNovember = 0m;
                var _payDecember = 0m;
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payJanurary = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payFebruary = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payMarch = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payApril = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payMay = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payJune = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payJuly = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payAugust = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _paySeptember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payOctober = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payNovember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _payDecember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));
                    #endregion
                }

                #region
                var _balance = new
                {
                    name = "全年收支状况",
                    data = new
                    {
                        income = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_incomeJanurary },
                            new {
                            name="2月",
                            value=_incomeFebruary },
                            new {
                            name="3月",
                            value=_incomeMarch },
                            new {
                            name="4月",
                            value=_incomeApril },
                            new {
                            name="5月",
                            value=_incomeMay },
                            new {
                            name="6月",
                            value=_incomeJune },
                            new {
                            name="7月",
                            value=_incomeJuly },
                            new {
                            name="8月",
                            value=_incomeAugust },
                            new {
                            name="9月",
                            value=_incomeSeptember },
                            new {
                            name="10月",
                            value=_incomeOctober },
                            new {
                            name="11月",
                            value=_incomeNovember },
                            new {
                            name="12月",
                            value=_incomeDecember },
                        },
                        pay = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_payJanurary },
                            new {
                            name="2月",
                            value=_payFebruary },
                            new {
                            name="3月",
                            value=_payMarch },
                            new {
                            name="4月",
                            value=_payApril },
                            new {
                            name="5月",
                            value=_payMay },
                            new {
                            name="6月",
                            value=_payJune },
                            new {
                            name="7月",
                            value=_payJuly },
                            new {
                            name="8月",
                            value=_payAugust },
                            new {
                            name="9月",
                            value=_paySeptember },
                            new {
                            name="10月",
                            value=_payOctober },
                            new {
                            name="11月",
                            value=_payNovember },
                            new {
                            name="12月",
                            value=_payDecember },
                        }
                    }
                };
                #endregion
                #endregion

                #region //财政支出
                var _groupByTemp = new List<FiscalExpenditure>();
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    _groupByTemp = dtFz_Pay.AsEnumerable().GroupBy(g => g.Field<string>("MK_NAME"))
                       .Select(a => new FiscalExpenditure() { ItemName = a.Key, TotalMoney = a.Sum(s => s.Field<decimal>("PAY_MONEY")) }).ToList();

                    if (_groupByTemp != null && _groupByTemp.Count() > 0)
                    {
                        var _groupByTempCount = _groupByTemp.Count();
                        if (_groupByTempCount < 3)
                        {
                            for (int i = 0; i < 3 - _groupByTempCount; i++)
                            {
                                _groupByTemp.Add(new FiscalExpenditure() { ItemName = "-", TotalMoney = 0m });
                            }
                        }

                        if (_groupByTempCount > 3)
                            _groupByTemp = _groupByTemp.OrderByDescending(o => o.TotalMoney).Take(3).ToList();
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            _groupByTemp.Add(new FiscalExpenditure() { ItemName = "-", TotalMoney = 0m });
                        }
                    }
                }
                var _fiscalExpenditure = new
                {
                    name = "财政支出",
                    data = new List<dynamic>(){
                        new {
                        name=_groupByTemp[0].ItemName,
                        value=string.Format("{0:N}",_groupByTemp[0].TotalMoney) },
                        new {
                        name=_groupByTemp[1].ItemName,
                        value=string.Format("{0:N}",_groupByTemp[1].TotalMoney) },
                        new {
                        name=_groupByTemp[2].ItemName,
                        value=string.Format("{0:N}",_groupByTemp[2].TotalMoney) }
                    }
                };
                #endregion

                #region //功能科目支出
                _groupByTemp = new List<FiscalExpenditure>();
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    _groupByTemp = dtFz_Pay.AsEnumerable().GroupBy(g => g.Field<string>("BS_NAME"))
                       .Select(a => new FiscalExpenditure() { ItemName = a.Key, TotalMoney = a.Sum(s => s.Field<decimal>("PAY_MONEY")) }).ToList();

                    if (_groupByTemp != null && _groupByTemp.Count() > 0)
                    {
                        var _groupByTempCount = _groupByTemp.Count();
                        if (_groupByTempCount < 4)
                        {
                            for (int i = 0; i < 4 - _groupByTempCount; i++)
                            {
                                _groupByTemp.Add(new FiscalExpenditure() { ItemName = "NA" + i.ToString(), TotalMoney = 0m });
                            }
                        }

                        if (_groupByTempCount > 4)
                            _groupByTemp = _groupByTemp.OrderByDescending(o => o.TotalMoney).Take(4).ToList();
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _groupByTemp.Add(new FiscalExpenditure() { ItemName = "NA" + i.ToString(), TotalMoney = 0m });
                        }
                    }
                }
                var _functionPay = new
                {
                    name = "功能科目支出",
                    data = new List<dynamic>(){
                        new {
                        name=_groupByTemp[0].ItemName,
                        value=_groupByTemp[0].TotalMoney },
                        new {
                        name=_groupByTemp[1].ItemName,
                        value=_groupByTemp[1].TotalMoney },
                        new {
                        name=_groupByTemp[2].ItemName,
                        value=_groupByTemp[2].TotalMoney },
                        new {
                        name=_groupByTemp[3].ItemName,
                        value=_groupByTemp[3].TotalMoney }
                    }
                };
                #endregion

                #region //经济分类支出
                _groupByTemp = new List<FiscalExpenditure>();
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    _groupByTemp = dtFz_Pay.AsEnumerable().GroupBy(g => g.Field<string>("BK_NAME"))
                       .Select(a => new FiscalExpenditure() { ItemName = a.Key, TotalMoney = a.Sum(s => s.Field<decimal>("PAY_MONEY")) }).ToList();

                    if (_groupByTemp != null && _groupByTemp.Count() > 0)
                    {
                        var _groupByTempCount = _groupByTemp.Count();
                        if (_groupByTempCount < 4)
                        {
                            for (int i = 0; i < 4 - _groupByTempCount; i++)
                            {
                                _groupByTemp.Add(new FiscalExpenditure() { ItemName = "NA" + i.ToString(), TotalMoney = 0m });
                            }
                        }

                        if (_groupByTempCount > 4)
                            _groupByTemp = _groupByTemp.OrderByDescending(o => o.TotalMoney).Take(4).ToList();
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _groupByTemp.Add(new FiscalExpenditure() { ItemName = "NA" + i.ToString(), TotalMoney = 0m });
                        }
                    }
                }
                var _economyPay = new
                {
                    name = "经济分类支出",
                    data = new List<dynamic>(){
                        new {
                        name=_groupByTemp[0].ItemName,
                        value=_groupByTemp[0].TotalMoney },
                        new {
                        name=_groupByTemp[1].ItemName,
                        value=_groupByTemp[1].TotalMoney },
                        new {
                        name=_groupByTemp[2].ItemName,
                        value=_groupByTemp[2].TotalMoney },
                        new {
                        name=_groupByTemp[3].ItemName,
                        value=_groupByTemp[3].TotalMoney }
                    }
                };
                #endregion

                return new
                {
                    status = "200",
                    message = "返回成功",
                    result = new
                    {
                        governmentReceipts = _governmentReceipts,
                        taxRevenue = _taxRevenue,
                        notTaxRevenue = _notTaxRevenue,
                        totalRevenue = _totalRevenue,
                        incomeProgress = _incomeProgress,
                        totalExpenditure = _totalExpenditure,
                        payProgress = _payProgress,
                        balance = _balance,
                        fiscalExpenditure = _fiscalExpenditure,
                        functionPay = _functionPay,
                        economyPay = _economyPay
                    }
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "-1",
                    message = ex.Message,
                    result = new { }
                };
            }
        }

        public dynamic GetReports_FZ_FundsAnalysis(int year)
        {
            try
            {
                dtFz_Pay = dal.GetPAY($" AND DATE_FORMAT(PAY_TIME,'%Y')='{year}'");
                var dtOldFz_Pay = dal.GetPAY($" AND DATE_FORMAT(PAY_TIME,'%Y')='{year - 1}'");

                var _top1Pay = 0m;//
                var _top2Pay = 0m;//
                var _top3Pay = 0m;//
                var _total = 0m;//合计

                #region 三公经费支出

                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    _top1Pay = dtFz_Pay.AsEnumerable().Where(w => w.Field<string>("BK_CODE") == "BK006").Sum(s => s.Field<decimal>("PAY_MONEY"));
                    _top2Pay = dtFz_Pay.AsEnumerable().Where(w => w.Field<string>("BK_CODE") == "BK007").Sum(s => s.Field<decimal>("PAY_MONEY"));
                    _top3Pay = dtFz_Pay.AsEnumerable().Where(w => w.Field<string>("BK_CODE") == "BK005").Sum(s => s.Field<decimal>("PAY_MONEY"));
                    _total = _top1Pay + _top2Pay + _top3Pay;
                }

                var _fundsPayOverview = new
                {
                    top1Pay = _top1Pay,
                    top2Pay = _top2Pay,
                    top3Pay = _top3Pay,
                    total = _total
                };

                var _fundsPay = new
                {
                    name = "三公经费支出",
                    data = new List<dynamic>() {
                        new { name="因公出国(境)经费",value=_top1Pay},
                        new { name="公务车购置及运行费",value=_top2Pay},
                        new { name="公务接待",value=_top3Pay},
                    }
                };
                #endregion

                #region 三公经费支出对比情况
                var _oldYearJanurary = 0m;
                var _oldYearFebruary = 0m;
                var _oldYearMarch = 0m;
                var _oldYearApril = 0m;
                var _oldYearMay = 0m;
                var _oldYearJune = 0m;
                var _oldYearJuly = 0m;
                var _oldYearAugust = 0m;
                var _oldYearSeptember = 0m;
                var _oldYearOctober = 0m;
                var _oldYearNovember = 0m;
                var _oldYearDecember = 0m;
                if (dtOldFz_Pay != null && dtOldFz_Pay.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJanurary = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearFebruary = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMarch = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearApril = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMay = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJune = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJuly = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearAugust = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearSeptember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearOctober = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearNovember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtOldFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearDecember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));
                    #endregion
                }

                var _currentYearJanurary = 0m;
                var _currentYearFebruary = 0m;
                var _currentYearMarch = 0m;
                var _currentYearApril = 0m;
                var _currentYearMay = 0m;
                var _currentYearJune = 0m;
                var _currentYearJuly = 0m;
                var _currentYearAugust = 0m;
                var _currentYearSeptember = 0m;
                var _currentYearOctober = 0m;
                var _currentYearNovember = 0m;
                var _currentYearDecember = 0m;
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJanurary = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearFebruary = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMarch = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearApril = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMay = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJune = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJuly = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearAugust = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearSeptember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearOctober = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearNovember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));

                    _drTemp = dtFz_Pay.AsEnumerable().Where(s => s.Field<DateTime>("PAY_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearDecember = _drTemp.Sum(s => s.Field<decimal>("PAY_MONEY"));
                    #endregion
                }

                #region
                var _payCompare = new
                {
                    name = "三公经费支出对比情况",
                    data = new
                    {
                        oldYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_oldYearJanurary },
                            new {
                            name="2月",
                            value=_oldYearFebruary },
                            new {
                            name="3月",
                            value=_oldYearMarch },
                            new {
                            name="4月",
                            value=_oldYearApril },
                            new {
                            name="5月",
                            value=_oldYearMay },
                            new {
                            name="6月",
                            value=_oldYearJune },
                            new {
                            name="7月",
                            value=_oldYearJuly },
                            new {
                            name="8月",
                            value=_oldYearAugust },
                            new {
                            name="9月",
                            value=_oldYearSeptember },
                            new {
                            name="10月",
                            value=_oldYearOctober },
                            new {
                            name="11月",
                            value=_oldYearNovember },
                            new {
                            name="12月",
                            value=_oldYearDecember },
                        },
                        cucrYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_currentYearJanurary },
                            new {
                            name="2月",
                            value=_currentYearFebruary },
                            new {
                            name="3月",
                            value=_currentYearMarch },
                            new {
                            name="4月",
                            value=_currentYearApril },
                            new {
                            name="5月",
                            value=_currentYearMay },
                            new {
                            name="6月",
                            value=_currentYearJune },
                            new {
                            name="7月",
                            value=_currentYearJuly },
                            new {
                            name="8月",
                            value=_currentYearAugust },
                            new {
                            name="9月",
                            value=_currentYearSeptember },
                            new {
                            name="10月",
                            value=_currentYearOctober },
                            new {
                            name="11月",
                            value=_currentYearNovember },
                            new {
                            name="12月",
                            value=_currentYearDecember },
                        }
                    }
                };
                #endregion

                #endregion

                #region 支出信息
                var _payInfo = new List<PayInfo>();
                if (dtFz_Pay != null && dtFz_Pay.Rows.Count > 0)
                {
                    foreach (DataRow item in dtFz_Pay.Rows)
                        _payInfo.Add(new PayInfo()
                        {
                            MB_Name = item["MB_NAME"].ToString(),
                            ME_Name = item["ME_NAME"].ToString(),
                            BL_Name = item["BL_NAME"].ToString(),
                            MK_Name = item["MK_NAME"].ToString(),
                            BS_Name = item["BS_NAME"].ToString(),
                            BK_Name = item["BK_NAME"].ToString(),
                            BIS_Name = item["BIS_NAME"].ToString(),
                            PAY_ACCCODE = item["PAY_ACCCODE"].ToString(),
                            PAY_ACCNAME = item["PAY_ACCNAME"].ToString(),
                            PAY_ACCBANK = item["PAY_ACCBANK"].ToString(),
                            PAY_Money = Convert.ToDecimal(item["PAY_MONEY"].ToString())
                        });
                }
                #endregion

                return new
                {
                    status = "200",
                    message = "返回成功",
                    result = new
                    {
                        fundsPay = _fundsPay,
                        fundsPayOverview = _fundsPayOverview,
                        payCompare = _payCompare,
                        payInfo = _payInfo.OrderByDescending(o => o.PAY_Money).ToList()
                    }
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "-1",
                    message = ex.Message,
                    result = new { }
                };
            }
        }

        public dynamic GetReports_FZ_NotTaxRevenue(int year)
        {
            try
            {
                dtFz_Czsr = dal.GetCZSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year}' AND INCOME_TYPE='FSSR'");
                dtFz_Czsr_Ys = dal.GetCZSR_YS($" AND INCOME_TIME='{year}' AND INCOME_TYPE='FSSR'");

                var dtOldFz_Czsr = dal.GetCZSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year - 1}' AND INCOME_TYPE='FSSR'");

                var _ncYS = 0m;//年初预算
                var _bnSR = 0m;//本年收入
                var _incomeProgress = 0m;//完成进度%

                #region 非税收收入概况

                if (dtFz_Czsr_Ys != null && dtFz_Czsr_Ys.Rows.Count > 0)
                {
                    _ncYS = dtFz_Czsr_Ys.AsEnumerable().Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                }
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    _bnSR = dtFz_Czsr.AsEnumerable().Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                }

                if (_bnSR > 0 && _ncYS > 0)
                {
                    _incomeProgress = Math.Round((_bnSR / _ncYS) * 100, 2);
                    if (_incomeProgress > 100) _incomeProgress = 100m;
                }

                var _taxRevenueOverview = new
                {
                    ncYS = _ncYS,
                    bnSR = _bnSR,
                    incomeProgress = _incomeProgress
                };
                #endregion

                #region 非税收收入对比情况
                var _oldYearJanurary = 0m;
                var _oldYearFebruary = 0m;
                var _oldYearMarch = 0m;
                var _oldYearApril = 0m;
                var _oldYearMay = 0m;
                var _oldYearJune = 0m;
                var _oldYearJuly = 0m;
                var _oldYearAugust = 0m;
                var _oldYearSeptember = 0m;
                var _oldYearOctober = 0m;
                var _oldYearNovember = 0m;
                var _oldYearDecember = 0m;
                if (dtOldFz_Czsr != null && dtOldFz_Czsr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJanurary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearFebruary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMarch = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearApril = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMay = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJune = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJuly = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearAugust = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearSeptember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearOctober = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearNovember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearDecember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    #endregion
                }

                var _currentYearJanurary = 0m;
                var _currentYearFebruary = 0m;
                var _currentYearMarch = 0m;
                var _currentYearApril = 0m;
                var _currentYearMay = 0m;
                var _currentYearJune = 0m;
                var _currentYearJuly = 0m;
                var _currentYearAugust = 0m;
                var _currentYearSeptember = 0m;
                var _currentYearOctober = 0m;
                var _currentYearNovember = 0m;
                var _currentYearDecember = 0m;
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJanurary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearFebruary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMarch = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearApril = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMay = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJune = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJuly = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearAugust = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearSeptember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearOctober = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearNovember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearDecember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    #endregion
                }

                #region
                var _incomeCompare = new
                {
                    name = "非税收收入对比情况",
                    data = new
                    {
                        oldYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_oldYearJanurary },
                            new {
                            name="2月",
                            value=_oldYearFebruary },
                            new {
                            name="3月",
                            value=_oldYearMarch },
                            new {
                            name="4月",
                            value=_oldYearApril },
                            new {
                            name="5月",
                            value=_oldYearMay },
                            new {
                            name="6月",
                            value=_oldYearJune },
                            new {
                            name="7月",
                            value=_oldYearJuly },
                            new {
                            name="8月",
                            value=_oldYearAugust },
                            new {
                            name="9月",
                            value=_oldYearSeptember },
                            new {
                            name="10月",
                            value=_oldYearOctober },
                            new {
                            name="11月",
                            value=_oldYearNovember },
                            new {
                            name="12月",
                            value=_oldYearDecember },
                        },
                        cucrYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_currentYearJanurary },
                            new {
                            name="2月",
                            value=_currentYearFebruary },
                            new {
                            name="3月",
                            value=_currentYearMarch },
                            new {
                            name="4月",
                            value=_currentYearApril },
                            new {
                            name="5月",
                            value=_currentYearMay },
                            new {
                            name="6月",
                            value=_currentYearJune },
                            new {
                            name="7月",
                            value=_currentYearJuly },
                            new {
                            name="8月",
                            value=_currentYearAugust },
                            new {
                            name="9月",
                            value=_currentYearSeptember },
                            new {
                            name="10月",
                            value=_currentYearOctober },
                            new {
                            name="11月",
                            value=_currentYearNovember },
                            new {
                            name="12月",
                            value=_currentYearDecember },
                        }
                    }
                };
                #endregion

                #endregion

                #region 收入详情
                var _groupByTemp = new List<FiscalIncome>();
                var _incomeDetail = new List<IncomeDetail>();
                if (dtFz_Czsr_Ys != null && dtFz_Czsr_Ys.Rows.Count > 0)
                {
                    _groupByTemp = dtFz_Czsr_Ys.AsEnumerable().GroupBy(g => g.Field<string>("INCOME_BACC"))
                       .Select(s => new FiscalIncome()
                       {
                           ItemCode = s.Key,
                           ItemName = s.FirstOrDefault().Field<string>("INCOME_BACC_NAME"),
                           TotalMoney = s.Sum(m => m.Field<decimal>("INCOME_BUDGET"))
                       }).ToList();

                    var _realityTemp = 0m;
                    var _completionRate = 0m;
                    _groupByTemp.ForEach((item) =>
                    {
                        _realityTemp = dtFz_Czsr.AsEnumerable()
                                                 .Where(w => w.Field<string>("INCOME_BACC").ToString() == item.ItemCode)
                                                 .Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                        if (_realityTemp > 0 && item.TotalMoney > 0)
                        {
                            _completionRate = Math.Round((_realityTemp / item.TotalMoney) * 100, 2);
                            if (_completionRate > 100) _completionRate = 100;
                        }
                        _incomeDetail.Add(new IncomeDetail()
                        {
                            type = item.ItemCode,
                            name = item.ItemName,
                            budget = item.TotalMoney,
                            reality = _realityTemp,
                            completionRate = $"{_completionRate}%"
                        });
                    });
                }
                #endregion

                return new
                {
                    status = "200",
                    message = "返回成功",
                    result = new
                    {
                        incomeProgress = new { name = "收入进度", data = new List<dynamic>() { new { name = "完成率", value = _incomeProgress } } },
                        taxRevenueOverview = _taxRevenueOverview,
                        incomeCompare = _incomeCompare,
                        incomeDetail = _incomeDetail.OrderByDescending(o => o.reality).ToList()
                    }
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "-1",
                    message = ex.Message,
                    result = new { }
                };
            }
        }

        public dynamic GetReports_FZ_TaxRevenue(int year)
        {
            try
            {
                dtFz_Czsr = dal.GetCZSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year}' AND INCOME_TYPE='SSSR'");
                dtFz_Czsr_Ys = dal.GetCZSR_YS($" AND INCOME_TIME='{year}' AND INCOME_TYPE='SSSR'");

                var dtOldFz_Czsr = dal.GetCZSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year - 1}' AND INCOME_TYPE='SSSR'");

                var _ncYS = 0m;//年初预算
                var _bnSR = 0m;//本年收入
                var _incomeProgress = 0m;//完成进度%

                #region 税收收入概况

                if (dtFz_Czsr_Ys != null && dtFz_Czsr_Ys.Rows.Count > 0)
                {
                    _ncYS = dtFz_Czsr_Ys.AsEnumerable().Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                }
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    _bnSR = dtFz_Czsr.AsEnumerable().Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                }

                if (_bnSR > 0 && _ncYS > 0)
                {
                    _incomeProgress = Math.Round((_bnSR / _ncYS) * 100, 2);
                    if (_incomeProgress > 100) _incomeProgress = 100m;
                }

                var _taxRevenueOverview = new
                {
                    ncYS = _ncYS,
                    bnSR = _bnSR,
                    incomeProgress = _incomeProgress
                };
                #endregion

                #region 税收收入对比情况
                var _oldYearJanurary = 0m;
                var _oldYearFebruary = 0m;
                var _oldYearMarch = 0m;
                var _oldYearApril = 0m;
                var _oldYearMay = 0m;
                var _oldYearJune = 0m;
                var _oldYearJuly = 0m;
                var _oldYearAugust = 0m;
                var _oldYearSeptember = 0m;
                var _oldYearOctober = 0m;
                var _oldYearNovember = 0m;
                var _oldYearDecember = 0m;
                if (dtOldFz_Czsr != null && dtOldFz_Czsr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJanurary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearFebruary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMarch = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearApril = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMay = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJune = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJuly = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearAugust = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearSeptember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearOctober = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearNovember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtOldFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearDecember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    #endregion
                }

                var _currentYearJanurary = 0m;
                var _currentYearFebruary = 0m;
                var _currentYearMarch = 0m;
                var _currentYearApril = 0m;
                var _currentYearMay = 0m;
                var _currentYearJune = 0m;
                var _currentYearJuly = 0m;
                var _currentYearAugust = 0m;
                var _currentYearSeptember = 0m;
                var _currentYearOctober = 0m;
                var _currentYearNovember = 0m;
                var _currentYearDecember = 0m;
                if (dtFz_Czsr != null && dtFz_Czsr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJanurary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearFebruary = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMarch = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearApril = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMay = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJune = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJuly = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearAugust = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearSeptember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearOctober = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearNovember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));

                    _drTemp = dtFz_Czsr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearDecember = _drTemp.Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                    #endregion
                }

                #region
                var _incomeCompare = new
                {
                    name = "税收收入对比情况",
                    data = new
                    {
                        oldYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_oldYearJanurary },
                            new {
                            name="2月",
                            value=_oldYearFebruary },
                            new {
                            name="3月",
                            value=_oldYearMarch },
                            new {
                            name="4月",
                            value=_oldYearApril },
                            new {
                            name="5月",
                            value=_oldYearMay },
                            new {
                            name="6月",
                            value=_oldYearJune },
                            new {
                            name="7月",
                            value=_oldYearJuly },
                            new {
                            name="8月",
                            value=_oldYearAugust },
                            new {
                            name="9月",
                            value=_oldYearSeptember },
                            new {
                            name="10月",
                            value=_oldYearOctober },
                            new {
                            name="11月",
                            value=_oldYearNovember },
                            new {
                            name="12月",
                            value=_oldYearDecember },
                        },
                        cucrYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_currentYearJanurary },
                            new {
                            name="2月",
                            value=_currentYearFebruary },
                            new {
                            name="3月",
                            value=_currentYearMarch },
                            new {
                            name="4月",
                            value=_currentYearApril },
                            new {
                            name="5月",
                            value=_currentYearMay },
                            new {
                            name="6月",
                            value=_currentYearJune },
                            new {
                            name="7月",
                            value=_currentYearJuly },
                            new {
                            name="8月",
                            value=_currentYearAugust },
                            new {
                            name="9月",
                            value=_currentYearSeptember },
                            new {
                            name="10月",
                            value=_currentYearOctober },
                            new {
                            name="11月",
                            value=_currentYearNovember },
                            new {
                            name="12月",
                            value=_currentYearDecember },
                        }
                    }
                };
                #endregion

                #endregion

                #region 收入详情
                var _groupByTemp = new List<FiscalIncome>();
                var _incomeDetail = new List<IncomeDetail>();
                if (dtFz_Czsr_Ys != null && dtFz_Czsr_Ys.Rows.Count > 0)
                {
                    _groupByTemp = dtFz_Czsr_Ys.AsEnumerable().GroupBy(g => g.Field<string>("INCOME_BACC"))
                       .Select(s => new FiscalIncome()
                       {
                           ItemCode = s.Key,
                           ItemName = s.FirstOrDefault().Field<string>("INCOME_BACC_NAME"),
                           TotalMoney = s.Sum(m => m.Field<decimal>("INCOME_BUDGET"))
                       }).ToList();

                    var _realityTemp = 0m;
                    var _completionRate = 0m;
                    _groupByTemp.ForEach((item) =>
                    {
                        _realityTemp = dtFz_Czsr.AsEnumerable()
                                                 .Where(w => w.Field<string>("INCOME_BACC").ToString() == item.ItemCode)
                                                 .Sum(s => s.Field<decimal>("INCOME_BUDGET"));
                        if (_realityTemp > 0 && item.TotalMoney > 0)
                        {
                            _completionRate = Math.Round((_realityTemp / item.TotalMoney) * 100, 2);
                            if (_completionRate > 100) _completionRate = 100;
                        }
                        _incomeDetail.Add(new IncomeDetail()
                        {
                            type = item.ItemCode,
                            name = item.ItemName,
                            budget = item.TotalMoney,
                            reality = _realityTemp,
                            completionRate = $"{_completionRate}%"
                        });
                    });
                }
                #endregion

                return new
                {
                    status = "200",
                    message = "返回成功",
                    result = new
                    {
                        incomeProgress = new { name = "收入进度", data = new List<dynamic>() { new { name = "完成率", value = _incomeProgress } } },
                        taxRevenueOverview = _taxRevenueOverview,
                        incomeCompare = _incomeCompare,
                        incomeDetail = _incomeDetail.OrderByDescending(o => o.reality).ToList()
                    }
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "-1",
                    message = ex.Message,
                    result = new { }
                };
            }
        }

        public dynamic GetReports_FZ_TransferIncome(int year)
        {
            try
            {
                dtFz_Zbxx = dal.GetZBXX($" AND PAY_TIME='{year}'");
                dtFz_Zysr = dal.GetZYSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year}'");
                var dtOldFz_Zysr = dal.GetZYSR($" AND DATE_FORMAT(INCOME_TIME,'%Y')='{year - 1}'");

                var _countrySR = 0m;//中央
                var _provinceSR = 0m;//省级
                var _citySR = 0m;//市级
                var _total = 0m;//合计

                #region 转移性收入

                if (dtFz_Zysr != null && dtFz_Zysr.Rows.Count > 0)
                {
                    _countrySR = dtFz_Zysr.AsEnumerable().Where(w => w.Field<string>("BL_NAME") == "中央").Sum(s => s.Field<decimal>("BUDGET_MONEY"));
                    _provinceSR = dtFz_Zysr.AsEnumerable().Where(w => w.Field<string>("BL_NAME") == "省级").Sum(s => s.Field<decimal>("BUDGET_MONEY"));
                    _citySR = dtFz_Zysr.AsEnumerable().Where(w => w.Field<string>("BL_NAME") == "市级").Sum(s => s.Field<decimal>("BUDGET_MONEY"));
                    _total = _countrySR + _provinceSR + _citySR;
                }

                var _transferIncomeOverview = new
                {
                    country = _countrySR,
                    province = _provinceSR,
                    city = _citySR,
                    total = _total
                };

                var _transferIncome = new
                {
                    name = "转移性收入",
                    data = new List<dynamic>() {
                        new { name="中央",value=_countrySR},
                        new { name="省级",value=_provinceSR},
                        new { name="市级",value=_citySR},
                    }
                };
                #endregion

                #region 转移性收入对比情况
                var _oldYearJanurary = 0m;
                var _oldYearFebruary = 0m;
                var _oldYearMarch = 0m;
                var _oldYearApril = 0m;
                var _oldYearMay = 0m;
                var _oldYearJune = 0m;
                var _oldYearJuly = 0m;
                var _oldYearAugust = 0m;
                var _oldYearSeptember = 0m;
                var _oldYearOctober = 0m;
                var _oldYearNovember = 0m;
                var _oldYearDecember = 0m;
                if (dtOldFz_Zysr != null && dtOldFz_Zysr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJanurary = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearFebruary = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMarch = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearApril = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearMay = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJune = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearJuly = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearAugust = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearSeptember = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearOctober = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearNovember = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtOldFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _oldYearDecember = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));
                    #endregion
                }

                var _currentYearJanurary = 0m;
                var _currentYearFebruary = 0m;
                var _currentYearMarch = 0m;
                var _currentYearApril = 0m;
                var _currentYearMay = 0m;
                var _currentYearJune = 0m;
                var _currentYearJuly = 0m;
                var _currentYearAugust = 0m;
                var _currentYearSeptember = 0m;
                var _currentYearOctober = 0m;
                var _currentYearNovember = 0m;
                var _currentYearDecember = 0m;
                if (dtFz_Zysr != null && dtFz_Zysr.Rows.Count > 0)
                {
                    #region
                    var _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "01").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJanurary = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "02").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearFebruary = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "03").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMarch = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "04").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearApril = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "05").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearMay = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "06").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJune = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "07").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearJuly = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "08").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearAugust = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "09").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearSeptember = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "10").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearOctober = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "11").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearNovember = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));

                    _drTemp = dtFz_Zysr.AsEnumerable().Where(s => s.Field<DateTime>("INCOME_TIME").ToString("MM") == "12").ToList();
                    if (_drTemp != null && _drTemp.Count > 0) _currentYearDecember = _drTemp.Sum(s => s.Field<decimal>("BUDGET_MONEY"));
                    #endregion
                }

                #region
                var _incomeCompare = new
                {
                    name = "转移性收入对比情况",
                    data = new
                    {
                        oldYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_oldYearJanurary },
                            new {
                            name="2月",
                            value=_oldYearFebruary },
                            new {
                            name="3月",
                            value=_oldYearMarch },
                            new {
                            name="4月",
                            value=_oldYearApril },
                            new {
                            name="5月",
                            value=_oldYearMay },
                            new {
                            name="6月",
                            value=_oldYearJune },
                            new {
                            name="7月",
                            value=_oldYearJuly },
                            new {
                            name="8月",
                            value=_oldYearAugust },
                            new {
                            name="9月",
                            value=_oldYearSeptember },
                            new {
                            name="10月",
                            value=_oldYearOctober },
                            new {
                            name="11月",
                            value=_oldYearNovember },
                            new {
                            name="12月",
                            value=_oldYearDecember },
                        },
                        cucrYear = new List<dynamic>(){
                            new {
                            name="1月",
                            value=_currentYearJanurary },
                            new {
                            name="2月",
                            value=_currentYearFebruary },
                            new {
                            name="3月",
                            value=_currentYearMarch },
                            new {
                            name="4月",
                            value=_currentYearApril },
                            new {
                            name="5月",
                            value=_currentYearMay },
                            new {
                            name="6月",
                            value=_currentYearJune },
                            new {
                            name="7月",
                            value=_currentYearJuly },
                            new {
                            name="8月",
                            value=_currentYearAugust },
                            new {
                            name="9月",
                            value=_currentYearSeptember },
                            new {
                            name="10月",
                            value=_currentYearOctober },
                            new {
                            name="11月",
                            value=_currentYearNovember },
                            new {
                            name="12月",
                            value=_currentYearDecember },
                        }
                    }
                };
                #endregion

                #endregion

                #region 指标信息
                var _targetInfo = new List<TagetInfo>();
                if (dtFz_Zbxx != null && dtFz_Zbxx.Rows.Count > 0)
                {
                    foreach (DataRow item in dtFz_Zbxx.Rows)
                        _targetInfo.Add(new TagetInfo()
                        {
                            MB_Name = item["MB_NAME"].ToString(),
                            ME_Name = item["ME_NAME"].ToString(),
                            BL_Name = item["BL_NAME"].ToString(),
                            MK_Name = item["MK_NAME"].ToString(),
                            BS_Name = item["BS_NAME"].ToString(),
                            BK_Name = item["BK_NAME"].ToString(),
                            BIS_Name = item["BIS_NAME"].ToString(),
                            DC_Name = item["DC_NAME"].ToString(),
                            BUDGET_Money = Convert.ToDecimal(item["BUDGET_MONEY"].ToString())
                        });
                }
                #endregion

                return new
                {
                    status = "200",
                    message = "返回成功",
                    result = new
                    {
                        transferIncome = _transferIncome,
                        transferIncomeOverview = _transferIncomeOverview,
                        incomeCompare = _incomeCompare,
                        targetInfo = _targetInfo.OrderByDescending(o => o.BUDGET_Money).ToList()
                    }
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = "-1",
                    message = ex.Message,
                    result = new { }
                };
            }
        }
        #endregion
    }

    public class FiscalExpenditure
    {
        public string ItemName { get; set; }
        public decimal TotalMoney { get; set; }
    }

    public class FiscalIncome
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal TotalMoney { get; set; }
    }

    public class IncomeDetail
    {
        public string type { get; set; }
        public string name { get; set; }
        public decimal budget { get; set; }
        public decimal reality { get; set; }
        public string completionRate { get; set; }
    }

    public class TransferIncome
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal TotalMoney { get; set; }
    }

    public class TagetInfo
    {
        public string MB_Name { get; set; }
        public string ME_Name { get; set; }
        public string BL_Name { get; set; }
        public string MK_Name { get; set; }
        public string BS_Name { get; set; }
        public string BK_Name { get; set; }
        public string BIS_Name { get; set; }
        public string DC_Name { get; set; }
        public decimal BUDGET_Money { get; set; }
    }

    public class PayInfo
    {
        public string MB_Name { get; set; }
        public string ME_Name { get; set; }
        public string BL_Name { get; set; }
        public string MK_Name { get; set; }
        public string BS_Name { get; set; }
        public string BK_Name { get; set; }
        public string BIS_Name { get; set; }
        public string PAY_ACCCODE { get; set; }
        public string PAY_ACCNAME { get; set; }
        public string PAY_ACCBANK { get; set; }
        public decimal PAY_Money { get; set; }
    }

}
