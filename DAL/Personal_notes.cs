using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:Personal_notes
	/// </summary>
	public partial class Personal_notes
	{
		public Personal_notes()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "Personal_notes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Personal_notes");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Garfield.Model.Personal_notes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Personal_notes(");
			strSql.Append("emp_id,emp_name,note_content,note_color,xyz,note_time)");
			strSql.Append(" values (");
			strSql.Append("@emp_id,@emp_name,@note_content,@note_color,@xyz,@note_time)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("@emp_id", MySqlDbType.Int32,4),
					new MySqlParameter("@emp_name", MySqlDbType.VarChar,250),
					new MySqlParameter("@note_content", MySqlDbType.VarChar,-1),
					new MySqlParameter("@note_color", MySqlDbType.VarChar,250),
					new MySqlParameter("@xyz", MySqlDbType.VarChar,250),
					new MySqlParameter("@note_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.emp_id;
			parameters[1].Value = model.emp_name;
			parameters[2].Value = model.note_content;
			parameters[3].Value = model.note_color;
			parameters[4].Value = model.xyz;
			parameters[5].Value = model.note_time;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Garfield.Model.Personal_notes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Personal_notes set ");			
			strSql.Append("xyz=@xyz ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {					
					new MySqlParameter("@xyz", MySqlDbType.VarChar,250),
					new MySqlParameter("@id", MySqlDbType.Int32,4)};
			parameters[0].Value = model.xyz;
			parameters[1].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Personal_notes ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4)
};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Personal_notes ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public Garfield.Model.Personal_notes GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            //strSql.Append("select  top 1 id,emp_id,emp_name,note_content,note_color,xyz,note_time from Personal_notes ");
            strSql.Append("select id,emp_id,emp_name,note_content,note_color,xyz,note_time from Personal_notes ");
            strSql.Append(" where id=@id");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4)
};
			parameters[0].Value = id;

			Garfield.Model.Personal_notes model=new Garfield.Model.Personal_notes();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["emp_id"].ToString()!="")
				{
					model.emp_id=int.Parse(ds.Tables[0].Rows[0]["emp_id"].ToString());
				}
				model.emp_name=ds.Tables[0].Rows[0]["emp_name"].ToString();
				model.note_content=ds.Tables[0].Rows[0]["note_content"].ToString();
				model.note_color=ds.Tables[0].Rows[0]["note_color"].ToString();
				model.xyz=ds.Tables[0].Rows[0]["xyz"].ToString();
				if(ds.Tables[0].Rows[0]["note_time"].ToString()!="")
				{
					model.note_time=DateTime.Parse(ds.Tables[0].Rows[0]["note_time"].ToString());
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
			strSql.Append("select id,emp_id,emp_name,note_content,note_color,xyz,note_time ");
			strSql.Append(" FROM Personal_notes ");
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
			strSql.Append(" id,emp_id,emp_name,note_content,note_color,xyz,note_time ");
			strSql.Append(" FROM Personal_notes ");
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

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Personal_notes";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

