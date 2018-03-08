using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Garfield.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace Garfield.DAL
{
	/// <summary>
	/// 数据访问类:CRM_order_details
	/// </summary>
	public partial class CRM_order_details
	{
		public CRM_order_details()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Garfield.Model.CRM_order_details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CRM_order_details(");
			strSql.Append("order_id,product_id,product_name,price,quantity,unit,amount)");
			strSql.Append(" values (");
			strSql.Append("@order_id,@product_id,@product_name,@price,@quantity,@unit,@amount)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@order_id", MySqlDbType.Int32,4),
					new MySqlParameter("@product_id", MySqlDbType.Int32,4),
					new MySqlParameter("@product_name", MySqlDbType.VarChar,250),
					new MySqlParameter("@price", MySqlDbType.Float,8),
					new MySqlParameter("@quantity", MySqlDbType.Int32,4),
					new MySqlParameter("@unit", MySqlDbType.VarChar,250),
					new MySqlParameter("@amount", MySqlDbType.Float,8)};
			parameters[0].Value = model.order_id;
			parameters[1].Value = model.product_id;
			parameters[2].Value = model.product_name;
			parameters[3].Value = model.price;
			parameters[4].Value = model.quantity;
			parameters[5].Value = model.unit;
			parameters[6].Value = model.amount;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Garfield.Model.CRM_order_details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CRM_order_details set ");
			strSql.Append("order_id=@order_id,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("product_name=@product_name,");
			strSql.Append("price=@price,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("unit=@unit,");
			strSql.Append("amount=@amount");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@order_id", MySqlDbType.Int32,4),
					new MySqlParameter("@product_id", MySqlDbType.Int32,4),
					new MySqlParameter("@product_name", MySqlDbType.VarChar,250),
					new MySqlParameter("@price", MySqlDbType.Float,8),
					new MySqlParameter("@quantity", MySqlDbType.Int32,4),
					new MySqlParameter("@unit", MySqlDbType.VarChar,250),
					new MySqlParameter("@amount", MySqlDbType.Float,8)};
			parameters[0].Value = model.order_id;
			parameters[1].Value = model.product_id;
			parameters[2].Value = model.product_name;
			parameters[3].Value = model.price;
			parameters[4].Value = model.quantity;
			parameters[5].Value = model.unit;
			parameters[6].Value = model.amount;

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
		public bool Delete(string wherestr)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CRM_order_details ");
			strSql.Append(" where "+wherestr);
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select order_id,product_id,product_name,price,quantity,unit,amount ");
			strSql.Append(" FROM CRM_order_details ");
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
			strSql.Append(" order_id,product_id,product_name,price,quantity,unit,amount ");
			strSql.Append(" FROM CRM_order_details ");
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

