using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ECSMS.Model;
namespace ECSMS.BLL
{
	/// <summary>
	/// EC_SmsChannel
	/// </summary>
	public partial class EC_SmsChannel
	{
		private readonly ECSMS.DAL.EC_SmsChannel dal=new ECSMS.DAL.EC_SmsChannel();
		public EC_SmsChannel()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Code)
		{
			return dal.Exists(Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ECSMS.Model.EC_SmsChannel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_SmsChannel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Code)
		{
			
			return dal.Delete(Code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Codelist )
		{
			return dal.DeleteList(Codelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECSMS.Model.EC_SmsChannel GetModel(string Code)
		{
			
			return dal.GetModel(Code);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ECSMS.Model.EC_SmsChannel GetModelByCache(string Code)
		{
			
			string CacheKey = "EC_SmsChannelModel-" + Code;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Code);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ECSMS.Model.EC_SmsChannel)objModel;
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
		public List<ECSMS.Model.EC_SmsChannel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ECSMS.Model.EC_SmsChannel> DataTableToList(DataTable dt)
		{
			List<ECSMS.Model.EC_SmsChannel> modelList = new List<ECSMS.Model.EC_SmsChannel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ECSMS.Model.EC_SmsChannel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ECSMS.Model.EC_SmsChannel();
					model.Code=dt.Rows[n]["Code"].ToString();
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Account=dt.Rows[n]["Account"].ToString();
					model.Pwd=dt.Rows[n]["Pwd"].ToString();
					if(dt.Rows[n]["CorpId"].ToString()!="")
					{
						model.CorpId=int.Parse(dt.Rows[n]["CorpId"].ToString());
					}
					model.ProductCode=dt.Rows[n]["ProductCode"].ToString();
					model.OtherPara=dt.Rows[n]["OtherPara"].ToString();
					if(dt.Rows[n]["TotalNum"].ToString()!="")
					{
						model.TotalNum=int.Parse(dt.Rows[n]["TotalNum"].ToString());
					}
					if(dt.Rows[n]["MaxSendNum"].ToString()!="")
					{
						model.MaxSendNum=int.Parse(dt.Rows[n]["MaxSendNum"].ToString());
					}
					if(dt.Rows[n]["AwokeNum"].ToString()!="")
					{
						model.AwokeNum=int.Parse(dt.Rows[n]["AwokeNum"].ToString());
					}
					if(dt.Rows[n]["State"].ToString()!="")
					{
						model.State=int.Parse(dt.Rows[n]["State"].ToString());
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

