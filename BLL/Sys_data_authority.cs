using System;
using System.Data;
using System.Collections.Generic;
using Garfield.Common;
using Garfield.Model;
namespace Garfield.BLL
{
	/// <summary>
	/// Sys_data_authority
	/// </summary>
	public partial class Sys_data_authority
	{
		private readonly Garfield.DAL.Sys_data_authority dal=new Garfield.DAL.Sys_data_authority();
		public Sys_data_authority()
		{}
		#region  Method

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Garfield.Model.Sys_data_authority model)
		{
			dal.Add(model);
		}

	

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string where)
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			return dal.Delete(where);
		}

		
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
	

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		

		#endregion  Method
	}
}
