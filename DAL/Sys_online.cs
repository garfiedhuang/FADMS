using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:Sys_online
	/// </summary>
	public partial class Sys_online
	{
		public Sys_online()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Garfield.Model.Sys_online model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_online(");
			strSql.Append("UserID,UserName,LastLogTime)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@UserName,@LastLogTime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserID", MySqlDbType.Int32,4),
					new MySqlParameter("@UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("@LastLogTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.LastLogTime;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Garfield.Model.Sys_online model, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_online set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("LastLogTime=@LastLogTime");
            strSql.Append(" where " + where);
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserID", MySqlDbType.Int32,4),
					new MySqlParameter("@UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("@LastLogTime", MySqlDbType.DateTime)
                                        };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.LastLogTime;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string wherestr)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_online ");
            strSql.Append(" where " + wherestr + "  ");
            MySqlParameter[] parameters = {
};

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("select UserID,UserName,LastLogTime ");
			strSql.Append(" FROM Sys_online ");
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
			strSql.Append(" UserID,UserName,LastLogTime ");
			strSql.Append(" FROM Sys_online ");
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

	

		#endregion  Method
	}
}

