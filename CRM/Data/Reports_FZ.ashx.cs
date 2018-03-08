using Garfield.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Garfield.CRM.Data
{
    /// <summary>
    /// Reports_FZ 的摘要说明
    /// </summary>
    public class Reports_FZ : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest request = context.Request;

            #region 弃用 20180224
            //var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            //var ticket = FormsAuthentication.Decrypt(cookie.Value);
            //string CoockiesID = ticket.UserData;

            //BLL.hr_employee emp = new BLL.hr_employee();
            //int emp_id = int.Parse(CoockiesID);
            //DataSet dsemp = emp.GetList("id=" + emp_id);
            //string empname = dsemp.Tables[0].Rows[0]["name"].ToString();
            //string uid = dsemp.Tables[0].Rows[0]["uid"].ToString();

            //if (request["Action"] == "getUserTree")
            //{
            //    BLL.Sys_online sol = new BLL.Sys_online();
            //    Model.Sys_online model = new Model.Sys_online();

            //    model.UserName = PageValidate.InputText(empname, 250);
            //    model.UserID = emp_id;
            //    model.LastLogTime = DateTime.Now;

            //    DataSet ds1 = sol.GetList(" UserID=" + emp_id);

            //    //添加当前用户信息
            //    if (ds1.Tables[0].Rows.Count > 0)
            //    {
            //        sol.Update(model, " UserID=" + emp_id);
            //    }
            //    else
            //    {
            //        sol.Add(model);
            //    }

            //    //删除超时用户
            //    //sol.Delete(" LastLogTime<DATEADD(MI,-2,getdate())");//SQL Server使用
            //    sol.Delete(" LastLogTime<date_sub(now(),interval 2 day)");

            //    BLL.Reports_FZ rFZ = new BLL.Reports_FZ();
            //    var data = rFZ.GetMenuTree(emp_id);
            //    var result = Common.DataToJson.SerializeObject(data);
            //    context.Response.Write(result);
            //}
            #endregion

            if (request["Action"] == "Reports_FZ_Index")
            {
                BLL.Reports_FZ rFZ = new BLL.Reports_FZ();
                var year = int.Parse(context.Request["syear_val"]);
                var data = rFZ.GetReports_FZ_Index(year);
                var result = Common.DataToJson.SerializeObject(data);
                context.Response.Write(result);
            }
            if (request["Action"] == "Reports_FZ_FundsAnalysis")
            {
                BLL.Reports_FZ rFZ = new BLL.Reports_FZ();
                var year = int.Parse(context.Request["syear_val"]);
                var data = rFZ.GetReports_FZ_FundsAnalysis(year);
                var result = Common.DataToJson.SerializeObject(data);
                context.Response.Write(result);
            }
            if (request["Action"] == "Reports_FZ_NotTaxRevenue")
            {
                BLL.Reports_FZ rFZ = new BLL.Reports_FZ();
                var year = int.Parse(context.Request["syear_val"]);
                var data = rFZ.GetReports_FZ_NotTaxRevenue(year);
                var result = Common.DataToJson.SerializeObject(data);
                context.Response.Write(result);
            }
            if (request["Action"] == "Reports_FZ_TaxRevenue")
            {
                BLL.Reports_FZ rFZ = new BLL.Reports_FZ();
                var year = int.Parse(context.Request["syear_val"]);
                var data = rFZ.GetReports_FZ_TaxRevenue(year);
                var result = Common.DataToJson.SerializeObject(data);
                context.Response.Write(result);
            }
            if (request["Action"] == "Reports_FZ_TransferIncome")
            {
                BLL.Reports_FZ rFZ = new BLL.Reports_FZ();
                var year = int.Parse(context.Request["syear_val"]);
                var data = rFZ.GetReports_FZ_TransferIncome(year);
                var result = Common.DataToJson.SerializeObject(data);
                context.Response.Write(result);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}