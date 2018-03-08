using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:Sys_role_emp
	/// </summary>
	public partial class Sys_role_emp
	{
		public Sys_role_emp()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Garfield.Model.Sys_role_emp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_role_emp(");
			strSql.Append("RoleID,empID)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@empID)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RoleID", MySqlDbType.Int32,4),
					new MySqlParameter("@empID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.empID;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Garfield.Model.Sys_role_emp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_role_emp set ");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("empID=@empID");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RoleID", MySqlDbType.Int32,4),
					new MySqlParameter("@empID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.empID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_role_emp ");
            strSql.Append(" where " + strWhere);
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Garfield.Model.Sys_role_emp GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            //strSql.Append("select  top 1 RoleID,empID from Sys_role_emp ");
            strSql.Append("select RoleID,empID from Sys_role_emp ");
            strSql.Append(" where 1=1 ");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
};

			Garfield.Model.Sys_role_emp model=new Garfield.Model.Sys_role_emp();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RoleID"]!=null && ds.Tables[0].Rows[0]["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["empID"]!=null && ds.Tables[0].Rows[0]["empID"].ToString()!="")
				{
					model.empID=int.Parse(ds.Tables[0].Rows[0]["empID"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RoleID,empID ");
			strSql.Append(" FROM Sys_role_emp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			//if(Top>0)
			//{
			//	strSql.Append(" top "+Top.ToString());
			//}
			strSql.Append(" RoleID,empID ");
			strSql.Append(" FROM Sys_role_emp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder, out string Total)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSql1 = new StringBuilder();
			strSql.Append("select ");
            //strSql.Append(" top " + PageSize + " * FROM Sys_role_emp ");
            strSql.Append(" * FROM Sys_role_emp where 1=1 ");
            //strSql.Append(" WHERE id not in ( SELECT top " + (PageIndex - 1) * PageSize + " id FROM Sys_role_emp ");
            //strSql.Append(" where " + strWhere + " order by " + filedOrder +")");
			strSql1.Append(" select count(id) FROM Sys_role_emp ");
			if (strWhere.Trim() != "")
			{
			    strSql.Append(" and " + strWhere);
			    strSql1.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            strSql.Append(" limit " + (PageIndex - 1) * PageSize + "," + PageSize);
            Total = DbHelperMySQL.Query(strSql1.ToString()).Tables[0].Rows[0][0].ToString();
			return DbHelperMySQL.Query(strSql.ToString());
		}

		#endregion  Method
	}
}

