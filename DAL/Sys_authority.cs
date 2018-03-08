using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:Sys_authority
	/// </summary>
	public partial class Sys_authority
	{
		public Sys_authority()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Garfield.Model.Sys_authority model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_authority(");
			strSql.Append("Role_id,App_ids,Menu_ids,Button_ids,Create_id,Create_date)");
			strSql.Append(" values (");
			strSql.Append("@Role_id,@App_ids,@Menu_ids,@Button_ids,@Create_id,@Create_date)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Role_id", MySqlDbType.Int32,4),
					new MySqlParameter("@App_ids", MySqlDbType.VarChar,250),
					new MySqlParameter("@Menu_ids", MySqlDbType.VarChar,-1),
					new MySqlParameter("@Button_ids", MySqlDbType.VarChar,-1),
					new MySqlParameter("@Create_id", MySqlDbType.Int32,4),
					new MySqlParameter("@Create_date", MySqlDbType.DateTime)};
			parameters[0].Value = model.Role_id;
			parameters[1].Value = model.App_ids;
			parameters[2].Value = model.Menu_ids;
			parameters[3].Value = model.Button_ids;
			parameters[4].Value = model.Create_id;
			parameters[5].Value = model.Create_date;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Garfield.Model.Sys_authority model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_authority set ");
			strSql.Append("Role_id=@Role_id,");
			strSql.Append("App_ids=@App_ids,");
			strSql.Append("Menu_ids=@Menu_ids,");
			strSql.Append("Button_ids=@Button_ids,");
			strSql.Append("Create_id=@Create_id,");
			strSql.Append("Create_date=@Create_date");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Role_id", MySqlDbType.Int32,4),
					new MySqlParameter("@App_ids", MySqlDbType.VarChar,250),
					new MySqlParameter("@Menu_ids", MySqlDbType.VarChar,-1),
					new MySqlParameter("@Button_ids", MySqlDbType.VarChar,-1),
					new MySqlParameter("@Create_id", MySqlDbType.Int32,4),
					new MySqlParameter("@Create_date", MySqlDbType.DateTime)};
			parameters[0].Value = model.Role_id;
			parameters[1].Value = model.App_ids;
			parameters[2].Value = model.Menu_ids;
			parameters[3].Value = model.Button_ids;
			parameters[4].Value = model.Create_id;
			parameters[5].Value = model.Create_date;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_authority ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

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
		/// 得到一个对象实体
		/// </summary>
		public Garfield.Model.Sys_authority GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            //strSql.Append("select  top 1 Role_id,App_ids,Menu_ids,Button_ids,Create_id,Create_date from Sys_authority ");
            strSql.Append("select Role_id,App_ids,Menu_ids,Button_ids,Create_id,Create_date from Sys_authority ");
            strSql.Append(" where 1=1");
            strSql.Append(" limit 1");
            MySqlParameter[] parameters = {
};

			Garfield.Model.Sys_authority model=new Garfield.Model.Sys_authority();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Role_id"]!=null && ds.Tables[0].Rows[0]["Role_id"].ToString()!="")
				{
					model.Role_id=int.Parse(ds.Tables[0].Rows[0]["Role_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["App_ids"]!=null && ds.Tables[0].Rows[0]["App_ids"].ToString()!="")
				{
					model.App_ids=ds.Tables[0].Rows[0]["App_ids"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Menu_ids"]!=null && ds.Tables[0].Rows[0]["Menu_ids"].ToString()!="")
				{
					model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Button_ids"]!=null && ds.Tables[0].Rows[0]["Button_ids"].ToString()!="")
				{
					model.Button_ids=ds.Tables[0].Rows[0]["Button_ids"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Create_id"]!=null && ds.Tables[0].Rows[0]["Create_id"].ToString()!="")
				{
					model.Create_id=int.Parse(ds.Tables[0].Rows[0]["Create_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Create_date"]!=null && ds.Tables[0].Rows[0]["Create_date"].ToString()!="")
				{
					model.Create_date=DateTime.Parse(ds.Tables[0].Rows[0]["Create_date"].ToString());
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
			strSql.Append("select Role_id,App_ids,Menu_ids,Button_ids,Create_id,Create_date ");
			strSql.Append(" FROM Sys_authority ");
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
			strSql.Append(" Role_id,App_ids,Menu_ids,Button_ids,Create_id,Create_date ");
			strSql.Append(" FROM Sys_authority ");
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
            //strSql.Append(" top " + PageSize + " * FROM Sys_authority ");
            strSql.Append(" * FROM Sys_authority where 1=1 ");
            //strSql.Append(" WHERE id not in ( SELECT top " + (PageIndex - 1) * PageSize + " id FROM Sys_authority ");
            //strSql.Append(" where " + strWhere + " order by " + filedOrder +")");
            strSql1.Append(" select count(id) FROM Sys_authority ");
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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteWhere(string wherestr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_authority ");
            strSql.Append(" where " + wherestr + "  ");
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
		#endregion  Method
	}
}

