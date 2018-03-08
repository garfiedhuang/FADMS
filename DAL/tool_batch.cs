using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:tool_batch
	/// </summary>
	public partial class tool_batch
	{
		public tool_batch()
		{}
		#region  Method
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Garfield.Model.tool_batch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tool_batch(");
			strSql.Append("batch_type,o_dep_id,o_dep,o_emp_id,o_emp,c_dep_id,c_dep,c_emp_id,c_emp,b_count,create_id,create_name,create_date)");
			strSql.Append(" values (");
			strSql.Append("@batch_type,@o_dep_id,@o_dep,@o_emp_id,@o_emp,@c_dep_id,@c_dep,@c_emp_id,@c_emp,@b_count,@create_id,@create_name,@create_date)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("@batch_type", MySqlDbType.VarChar,50),
					new MySqlParameter("@o_dep_id", MySqlDbType.Int32,4),
					new MySqlParameter("@o_dep", MySqlDbType.VarChar,250),
					new MySqlParameter("@o_emp_id", MySqlDbType.Int32,4),
					new MySqlParameter("@o_emp", MySqlDbType.VarChar,250),
					new MySqlParameter("@c_dep_id", MySqlDbType.Int32,4),
					new MySqlParameter("@c_dep", MySqlDbType.VarChar,250),
					new MySqlParameter("@c_emp_id", MySqlDbType.Int32,4),
					new MySqlParameter("@c_emp", MySqlDbType.VarChar,250),
					new MySqlParameter("@b_count", MySqlDbType.Int32,4),
					new MySqlParameter("@create_id", MySqlDbType.Int32,4),
					new MySqlParameter("@create_name", MySqlDbType.VarChar,250),
					new MySqlParameter("@create_date", MySqlDbType.DateTime)};
			parameters[0].Value = model.batch_type;
			parameters[1].Value = model.o_dep_id;
			parameters[2].Value = model.o_dep;
			parameters[3].Value = model.o_emp_id;
			parameters[4].Value = model.o_emp;
			parameters[5].Value = model.c_dep_id;
			parameters[6].Value = model.c_dep;
			parameters[7].Value = model.c_emp_id;
			parameters[8].Value = model.c_emp;
			parameters[9].Value = model.b_count;
			parameters[10].Value = model.create_id;
			parameters[11].Value = model.create_name;
			parameters[12].Value = model.create_date;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,batch_type,o_dep_id,o_dep,o_emp_id,o_emp,c_dep_id,c_dep,c_emp_id,c_emp,b_count,create_id,create_name,create_date ");
			strSql.Append(" FROM tool_batch ");
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
			strSql.Append(" id,batch_type,o_dep_id,o_dep,o_emp_id,o_emp,c_dep_id,c_dep,c_emp_id,c_emp,b_count,create_id,create_name,create_date ");
			strSql.Append(" FROM tool_batch ");
            if (strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" Limit " + Top.ToString());
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
            //strSql.Append(" top " + PageSize + " * FROM tool_batch ");
            strSql.Append(" * FROM tool_batch where 1=1 ");
            //strSql.Append(" WHERE id not in ( SELECT top " + (PageIndex - 1) * PageSize + " id FROM tool_batch ");
            //strSql.Append(" where " + strWhere + " order by " + filedOrder +")");
			strSql1.Append(" select count(id) FROM tool_batch ");
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

