using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ECSMS.Model;
namespace ECSMS.BLL
{
	/// <summary>
	/// EC_User
	/// </summary>
	public partial class EC_User
	{
		private readonly ECSMS.DAL.EC_User dal=new ECSMS.DAL.EC_User();
		public EC_User()
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
		public int  Add(ECSMS.Model.EC_User model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_User model)
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
		public ECSMS.Model.EC_User GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ECSMS.Model.EC_User GetModelByCache(int Id)
		{
			
			string CacheKey = "EC_UserModel-" + Id;
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
			return (ECSMS.Model.EC_User)objModel;
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
		public List<ECSMS.Model.EC_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ECSMS.Model.EC_User> DataTableToList(DataTable dt)
		{
			List<ECSMS.Model.EC_User> modelList = new List<ECSMS.Model.EC_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ECSMS.Model.EC_User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ECSMS.Model.EC_User();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.Account=dt.Rows[n]["Account"].ToString();
					model.Pwd=dt.Rows[n]["Pwd"].ToString();
					model.Name=dt.Rows[n]["Name"].ToString();
					if(dt.Rows[n]["Sex"].ToString()!="")
					{
						model.Sex=int.Parse(dt.Rows[n]["Sex"].ToString());
					}
					model.Telephone=dt.Rows[n]["Telephone"].ToString();
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.Fax=dt.Rows[n]["Fax"].ToString();
					model.QQ=dt.Rows[n]["QQ"].ToString();
					model.MSN=dt.Rows[n]["MSN"].ToString();
					model.CompanyName=dt.Rows[n]["CompanyName"].ToString();
					model.Department=dt.Rows[n]["Department"].ToString();
					model.CompanyaCity=dt.Rows[n]["CompanyaCity"].ToString();
					model.CompanyAddress=dt.Rows[n]["CompanyAddress"].ToString();
					model.WebSite=dt.Rows[n]["WebSite"].ToString();
					model.PostCode=dt.Rows[n]["PostCode"].ToString();
					model.Sign=dt.Rows[n]["Sign"].ToString();
					if(dt.Rows[n]["SignLock"].ToString()!="")
					{
						model.SignLock=int.Parse(dt.Rows[n]["SignLock"].ToString());
					}
					if(dt.Rows[n]["AwokeNum"].ToString()!="")
					{
						model.AwokeNum=int.Parse(dt.Rows[n]["AwokeNum"].ToString());
					}
					if(dt.Rows[n]["MaxSendNum"].ToString()!="")
					{
						model.MaxSendNum=int.Parse(dt.Rows[n]["MaxSendNum"].ToString());
					}
					if(dt.Rows[n]["Role"].ToString()!="")
					{
						model.Role=int.Parse(dt.Rows[n]["Role"].ToString());
					}
					if(dt.Rows[n]["GroupId"].ToString()!="")
					{
						model.GroupId=int.Parse(dt.Rows[n]["GroupId"].ToString());
					}
					if(dt.Rows[n]["State"].ToString()!="")
					{
						model.State=int.Parse(dt.Rows[n]["State"].ToString());
					}
					if(dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
					}
					if(dt.Rows[n]["Operater"].ToString()!="")
					{
						model.Operater=int.Parse(dt.Rows[n]["Operater"].ToString());
					}
					if(dt.Rows[n]["OnLine"].ToString()!="")
					{
						model.OnLine=int.Parse(dt.Rows[n]["OnLine"].ToString());
					}
					model.TrySmsType=dt.Rows[n]["TrySmsType"].ToString();
					model.RegFor=dt.Rows[n]["RegFor"].ToString();
					model.CertificateType=dt.Rows[n]["CertificateType"].ToString();
					model.CertificateNumbers=dt.Rows[n]["CertificateNumbers"].ToString();
					model.Mobile2=dt.Rows[n]["Mobile2"].ToString();
					model.Positions=dt.Rows[n]["Positions"].ToString();
					model.BirthDay=dt.Rows[n]["BirthDay"].ToString();
					model.CardNumber=dt.Rows[n]["CardNumber"].ToString();
					model.Servicer=dt.Rows[n]["Servicer"].ToString();
					model.StartDate=dt.Rows[n]["StartDate"].ToString();
					model.EndDate=dt.Rows[n]["EndDate"].ToString();
					model.Favirate=dt.Rows[n]["Favirate"].ToString();
					model.RelationLevel=dt.Rows[n]["RelationLevel"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					if(dt.Rows[n]["IsLock"].ToString()!="")
					{
						model.IsLock=int.Parse(dt.Rows[n]["IsLock"].ToString());
					}
					if(dt.Rows[n]["LastUpdateTime"].ToString()!="")
					{
						model.LastUpdateTime=DateTime.Parse(dt.Rows[n]["LastUpdateTime"].ToString());
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

