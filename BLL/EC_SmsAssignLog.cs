using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ECSMS.Model;
namespace ECSMS.BLL
{
	/// <summary>
	/// EC_SmsAssignLog
	/// </summary>
	public partial class EC_SmsAssignLog
	{
		private readonly ECSMS.DAL.EC_SmsAssignLog dal=new ECSMS.DAL.EC_SmsAssignLog();
		public EC_SmsAssignLog()
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
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ECSMS.Model.EC_SmsAssignLog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_SmsAssignLog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECSMS.Model.EC_SmsAssignLog GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ECSMS.Model.EC_SmsAssignLog GetModelByCache(int Id)
		{
			
			string CacheKey = "EC_SmsAssignLogModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ECSMS.Model.EC_SmsAssignLog)objModel;
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
		public List<ECSMS.Model.EC_SmsAssignLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ECSMS.Model.EC_SmsAssignLog> DataTableToList(DataTable dt)
		{
			List<ECSMS.Model.EC_SmsAssignLog> modelList = new List<ECSMS.Model.EC_SmsAssignLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ECSMS.Model.EC_SmsAssignLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ECSMS.Model.EC_SmsAssignLog();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["ToUserId"].ToString()!="")
					{
						model.ToUserId=int.Parse(dt.Rows[n]["ToUserId"].ToString());
					}
					model.ActType=dt.Rows[n]["ActType"].ToString();
					if(dt.Rows[n]["SmsCount"].ToString()!="")
					{
						model.SmsCount=int.Parse(dt.Rows[n]["SmsCount"].ToString());
					}
					model.SmsType=dt.Rows[n]["SmsType"].ToString();
					if(dt.Rows[n]["FromUserId"].ToString()!="")
					{
						model.FromUserId=int.Parse(dt.Rows[n]["FromUserId"].ToString());
					}
					if(dt.Rows[n]["OperTime"].ToString()!="")
					{
						model.OperTime=DateTime.Parse(dt.Rows[n]["OperTime"].ToString());
					}
					if(dt.Rows[n]["IsPay"].ToString()!="")
					{
						model.IsPay=int.Parse(dt.Rows[n]["IsPay"].ToString());
					}
					model.Remark=dt.Rows[n]["Remark"].ToString();
					if(dt.Rows[n]["LeaveNum"].ToString()!="")
					{
						model.LeaveNum=int.Parse(dt.Rows[n]["LeaveNum"].ToString());
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

