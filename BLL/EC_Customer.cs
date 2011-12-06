using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ECSMS.Model;
namespace ECSMS.BLL
{
	/// <summary>
	/// EC_Customer
	/// </summary>
	public partial class EC_Customer
	{
		private readonly ECSMS.DAL.EC_Customer dal=new ECSMS.DAL.EC_Customer();
		public EC_Customer()
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
		public int  Add(ECSMS.Model.EC_Customer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_Customer model)
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
		public ECSMS.Model.EC_Customer GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ECSMS.Model.EC_Customer GetModelByCache(int Id)
		{
			
			string CacheKey = "EC_CustomerModel-" + Id;
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
			return (ECSMS.Model.EC_Customer)objModel;
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
		public List<ECSMS.Model.EC_Customer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ECSMS.Model.EC_Customer> DataTableToList(DataTable dt)
		{
			List<ECSMS.Model.EC_Customer> modelList = new List<ECSMS.Model.EC_Customer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ECSMS.Model.EC_Customer model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ECSMS.Model.EC_Customer();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.Name=dt.Rows[n]["Name"].ToString();
					model.NickName=dt.Rows[n]["NickName"].ToString();
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					model.Sex=dt.Rows[n]["Sex"].ToString();
					model.CompanyName=dt.Rows[n]["CompanyName"].ToString();
					model.Partment=dt.Rows[n]["Partment"].ToString();
					model.Positions=dt.Rows[n]["Positions"].ToString();
					model.CompanyAddress=dt.Rows[n]["CompanyAddress"].ToString();
					model.Website=dt.Rows[n]["Website"].ToString();
					model.Telephone=dt.Rows[n]["Telephone"].ToString();
					model.Fax=dt.Rows[n]["Fax"].ToString();
					model.QQ=dt.Rows[n]["QQ"].ToString();
					model.mobile2=dt.Rows[n]["mobile2"].ToString();
					model.HomeTel=dt.Rows[n]["HomeTel"].ToString();
					model.HomeAddress=dt.Rows[n]["HomeAddress"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.Birthday=dt.Rows[n]["Birthday"].ToString();
					model.CardNumber=dt.Rows[n]["CardNumber"].ToString();
					model.Servicer=dt.Rows[n]["Servicer"].ToString();
					if(dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					model.Favrate=dt.Rows[n]["Favrate"].ToString();
					model.RelationLevel=dt.Rows[n]["RelationLevel"].ToString();
					model.PostCode=dt.Rows[n]["PostCode"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					if(dt.Rows[n]["GroupId"].ToString()!="")
					{
						model.GroupId=int.Parse(dt.Rows[n]["GroupId"].ToString());
					}
					if(dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
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

