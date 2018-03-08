using Garfield.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garfield.DAL
{
    public partial class Reports_FZ
    {
        public Reports_FZ()
        { }
        #region  Method

        public DataTable GetMenuTree(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
	a.RoleID,
	b.App_ids,
	REPLACE(b.Menu_ids,'m','') as Menu_ids
FROM
	sys_role_emp a
INNER JOIN sys_authority b ON a.RoleID = b.Role_id
WHERE 1=1
AND App_ids = 'a7,'");//固定只查询【数据查询】应用的菜单
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            var dtMenuIds = DbHelperMySQL.Query(strSql.ToString()).Tables[0];
            if (dtMenuIds == null || dtMenuIds.Rows.Count == 0) return null;

            var menuIds = dtMenuIds.Rows[0]["Menu_ids"].ToString().TrimEnd(',');//101,96,97,98,99,100,
            strSql.Clear();
            strSql.Append($@"SELECT
	Menu_id,
	Menu_name,
	Menu_url,
	Menu_icon
FROM
	sys_menu
WHERE
	Menu_id IN ({menuIds})
AND Menu_url <> ''
ORDER BY Menu_order ASC");

            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetCZSR(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DB_FZ_CZSR WHERE 1=1 ");
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetCZSR_YS(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DB_FZ_CZSR_YS WHERE 1=1 ");
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetPAY(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DB_FZ_PAY WHERE 1=1 ");
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetPAY_YS(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DB_FZ_PAY_YS WHERE 1=1 ");
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetZBXX(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DB_FZ_ZBXX WHERE 1=1 ");
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetZYSR(string queryParas)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM DB_FZ_ZYSR WHERE 1=1 ");
            if (!string.IsNullOrEmpty(queryParas))
            {
                strSql.Append(queryParas);
            }
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0];
        }

        #endregion
    }
}
