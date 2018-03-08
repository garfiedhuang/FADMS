using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:sys_info
	/// </summary>
	public partial class sys_info
	{
		public sys_info()
		{}
		#region  Method
        		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Garfield.Model.sys_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_info set ");
			strSql.Append("sys_value=@sys_value");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sys_key", MySqlDbType.VarChar,50),
					new MySqlParameter("@sys_value", MySqlDbType.VarChar),
					new MySqlParameter("@id", MySqlDbType.Int32,4)};
			parameters[0].Value = model.sys_key;
			parameters[1].Value = model.sys_value;
			parameters[2].Value = model.id;

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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sys_key,sys_value ");
			strSql.Append(" FROM sys_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		
		#endregion  Method
	}
}

