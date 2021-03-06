using System;
using System.Data;
using System.Collections.Generic;
using Garfield.Common;
using Garfield.Model;
namespace Garfield.BLL
{
	/// <summary>
	/// Personal_notes
	/// </summary>
	public partial class Personal_notes
	{
		private readonly Garfield.DAL.Personal_notes dal=new Garfield.DAL.Personal_notes();
		public Personal_notes()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Garfield.Model.Personal_notes model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Garfield.Model.Personal_notes model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Garfield.Model.Personal_notes GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Garfield.Model.Personal_notes GetModelByCache(int id)
		{
			
			string CacheKey = "Personal_notesModel-" + id;
			object objModel = Garfield.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Garfield.Common.ConfigHelper.GetConfigInt("ModelCache");
						Garfield.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Garfield.Model.Personal_notes)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Garfield.Model.Personal_notes> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Garfield.Model.Personal_notes> DataTableToList(DataTable dt)
		{
			List<Garfield.Model.Personal_notes> modelList = new List<Garfield.Model.Personal_notes>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Garfield.Model.Personal_notes model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Garfield.Model.Personal_notes();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["emp_id"].ToString()!="")
					{
						model.emp_id=int.Parse(dt.Rows[n]["emp_id"].ToString());
					}
					model.emp_name=dt.Rows[n]["emp_name"].ToString();
					model.note_content=dt.Rows[n]["note_content"].ToString();
					model.note_color=dt.Rows[n]["note_color"].ToString();
					model.xyz=dt.Rows[n]["xyz"].ToString();
					if(dt.Rows[n]["note_time"].ToString()!="")
					{
						model.note_time=DateTime.Parse(dt.Rows[n]["note_time"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

