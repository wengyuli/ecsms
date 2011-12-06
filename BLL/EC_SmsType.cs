using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ECSMS.Model;
namespace ECSMS.BLL
{
	/// <summary>
	/// EC_SmsType
	/// </summary>
	public partial class EC_SmsType
	{
		private readonly ECSMS.DAL.EC_SmsType dal=new ECSMS.DAL.EC_SmsType();
		public EC_SmsType()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Type)
		{
			return dal.Exists(Type);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ECSMS.Model.EC_SmsType model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_SmsType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Type)
		{
			
			return dal.Delete(Type);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Typelist )
		{
			return dal.DeleteList(Typelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECSMS.Model.EC_SmsType GetModel(string Type)
		{
			
			return dal.GetModel(Type);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ECSMS.Model.EC_SmsType GetModelByCache(string Type)
		{
			
			string CacheKey = "EC_SmsTypeModel-" + Type;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Type);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ECSMS.Model.EC_SmsType)objModel;
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
		public List<ECSMS.Model.EC_SmsType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ECSMS.Model.EC_SmsType> DataTableToList(DataTable dt)
		{
			List<ECSMS.Model.EC_SmsType> modelList = new List<ECSMS.Model.EC_SmsType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ECSMS.Model.EC_SmsType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ECSMS.Model.EC_SmsType();
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					model.ChannelCode=dt.Rows[n]["ChannelCode"].ToString();
					model.Price=dt.Rows[n]["Price"].ToString();
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

