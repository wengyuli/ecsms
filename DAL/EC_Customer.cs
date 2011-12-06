using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_Customer
	/// </summary>
	public partial class EC_Customer
	{
		public EC_Customer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_Customer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_Customer");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_Customer(");
			strSql.Append("Name,NickName,Mobile,Sex,CompanyName,Partment,Positions,CompanyAddress,Website,Telephone,Fax,QQ,mobile2,HomeTel,HomeAddress,Email,Birthday,CardNumber,Servicer,StartDate,EndDate,Favrate,RelationLevel,PostCode,Remark,GroupId,UserId)");
			strSql.Append(" values (");
			strSql.Append("@Name,@NickName,@Mobile,@Sex,@CompanyName,@Partment,@Positions,@CompanyAddress,@Website,@Telephone,@Fax,@QQ,@mobile2,@HomeTel,@HomeAddress,@Email,@Birthday,@CardNumber,@Servicer,@StartDate,@EndDate,@Favrate,@RelationLevel,@PostCode,@Remark,@GroupId,@UserId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,10),
					new SqlParameter("@NickName", SqlDbType.VarChar,10),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Partment", SqlDbType.VarChar,50),
					new SqlParameter("@Positions", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyAddress", SqlDbType.VarChar,100),
					new SqlParameter("@Website", SqlDbType.VarChar,50),
					new SqlParameter("@Telephone", SqlDbType.VarChar,15),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@mobile2", SqlDbType.VarChar,50),
					new SqlParameter("@HomeTel", SqlDbType.VarChar,50),
					new SqlParameter("@HomeAddress", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@Birthday", SqlDbType.VarChar,30),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Servicer", SqlDbType.VarChar,50),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Favrate", SqlDbType.VarChar,50),
					new SqlParameter("@RelationLevel", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@GroupId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.NickName;
			parameters[2].Value = model.Mobile;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.CompanyName;
			parameters[5].Value = model.Partment;
			parameters[6].Value = model.Positions;
			parameters[7].Value = model.CompanyAddress;
			parameters[8].Value = model.Website;
			parameters[9].Value = model.Telephone;
			parameters[10].Value = model.Fax;
			parameters[11].Value = model.QQ;
			parameters[12].Value = model.mobile2;
			parameters[13].Value = model.HomeTel;
			parameters[14].Value = model.HomeAddress;
			parameters[15].Value = model.Email;
			parameters[16].Value = model.Birthday;
			parameters[17].Value = model.CardNumber;
			parameters[18].Value = model.Servicer;
			parameters[19].Value = model.StartDate;
			parameters[20].Value = model.EndDate;
			parameters[21].Value = model.Favrate;
			parameters[22].Value = model.RelationLevel;
			parameters[23].Value = model.PostCode;
			parameters[24].Value = model.Remark;
			parameters[25].Value = model.GroupId;
			parameters[26].Value = model.UserId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(ECSMS.Model.EC_Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_Customer set ");
			strSql.Append("Name=@Name,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("Partment=@Partment,");
			strSql.Append("Positions=@Positions,");
			strSql.Append("CompanyAddress=@CompanyAddress,");
			strSql.Append("Website=@Website,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("mobile2=@mobile2,");
			strSql.Append("HomeTel=@HomeTel,");
			strSql.Append("HomeAddress=@HomeAddress,");
			strSql.Append("Email=@Email,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("Servicer=@Servicer,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Favrate=@Favrate,");
			strSql.Append("RelationLevel=@RelationLevel,");
			strSql.Append("PostCode=@PostCode,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("GroupId=@GroupId,");
			strSql.Append("UserId=@UserId");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,10),
					new SqlParameter("@NickName", SqlDbType.VarChar,10),
					new SqlParameter("@Mobile", SqlDbType.VarChar,15),
					new SqlParameter("@Sex", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Partment", SqlDbType.VarChar,50),
					new SqlParameter("@Positions", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyAddress", SqlDbType.VarChar,100),
					new SqlParameter("@Website", SqlDbType.VarChar,50),
					new SqlParameter("@Telephone", SqlDbType.VarChar,15),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@mobile2", SqlDbType.VarChar,50),
					new SqlParameter("@HomeTel", SqlDbType.VarChar,50),
					new SqlParameter("@HomeAddress", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@Birthday", SqlDbType.VarChar,30),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Servicer", SqlDbType.VarChar,50),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Favrate", SqlDbType.VarChar,50),
					new SqlParameter("@RelationLevel", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@GroupId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.NickName;
			parameters[2].Value = model.Mobile;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.CompanyName;
			parameters[5].Value = model.Partment;
			parameters[6].Value = model.Positions;
			parameters[7].Value = model.CompanyAddress;
			parameters[8].Value = model.Website;
			parameters[9].Value = model.Telephone;
			parameters[10].Value = model.Fax;
			parameters[11].Value = model.QQ;
			parameters[12].Value = model.mobile2;
			parameters[13].Value = model.HomeTel;
			parameters[14].Value = model.HomeAddress;
			parameters[15].Value = model.Email;
			parameters[16].Value = model.Birthday;
			parameters[17].Value = model.CardNumber;
			parameters[18].Value = model.Servicer;
			parameters[19].Value = model.StartDate;
			parameters[20].Value = model.EndDate;
			parameters[21].Value = model.Favrate;
			parameters[22].Value = model.RelationLevel;
			parameters[23].Value = model.PostCode;
			parameters[24].Value = model.Remark;
			parameters[25].Value = model.GroupId;
			parameters[26].Value = model.UserId;
			parameters[27].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EC_Customer ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EC_Customer ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ECSMS.Model.EC_Customer GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Name,NickName,Mobile,Sex,CompanyName,Partment,Positions,CompanyAddress,Website,Telephone,Fax,QQ,mobile2,HomeTel,HomeAddress,Email,Birthday,CardNumber,Servicer,StartDate,EndDate,Favrate,RelationLevel,PostCode,Remark,GroupId,UserId from EC_Customer ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_Customer model=new ECSMS.Model.EC_Customer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.NickName=ds.Tables[0].Rows[0]["NickName"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.CompanyName=ds.Tables[0].Rows[0]["CompanyName"].ToString();
				model.Partment=ds.Tables[0].Rows[0]["Partment"].ToString();
				model.Positions=ds.Tables[0].Rows[0]["Positions"].ToString();
				model.CompanyAddress=ds.Tables[0].Rows[0]["CompanyAddress"].ToString();
				model.Website=ds.Tables[0].Rows[0]["Website"].ToString();
				model.Telephone=ds.Tables[0].Rows[0]["Telephone"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.mobile2=ds.Tables[0].Rows[0]["mobile2"].ToString();
				model.HomeTel=ds.Tables[0].Rows[0]["HomeTel"].ToString();
				model.HomeAddress=ds.Tables[0].Rows[0]["HomeAddress"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Birthday=ds.Tables[0].Rows[0]["Birthday"].ToString();
				model.CardNumber=ds.Tables[0].Rows[0]["CardNumber"].ToString();
				model.Servicer=ds.Tables[0].Rows[0]["Servicer"].ToString();
				if(ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				model.Favrate=ds.Tables[0].Rows[0]["Favrate"].ToString();
				model.RelationLevel=ds.Tables[0].Rows[0]["RelationLevel"].ToString();
				model.PostCode=ds.Tables[0].Rows[0]["PostCode"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["GroupId"].ToString()!="")
				{
					model.GroupId=int.Parse(ds.Tables[0].Rows[0]["GroupId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
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
			strSql.Append("select Id,Name,NickName,Mobile,Sex,CompanyName,Partment,Positions,CompanyAddress,Website,Telephone,Fax,QQ,mobile2,HomeTel,HomeAddress,Email,Birthday,CardNumber,Servicer,StartDate,EndDate,Favrate,RelationLevel,PostCode,Remark,GroupId,UserId ");
			strSql.Append(" FROM EC_Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Name,NickName,Mobile,Sex,CompanyName,Partment,Positions,CompanyAddress,Website,Telephone,Fax,QQ,mobile2,HomeTel,HomeAddress,Email,Birthday,CardNumber,Servicer,StartDate,EndDate,Favrate,RelationLevel,PostCode,Remark,GroupId,UserId ");
			strSql.Append(" FROM EC_Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "EC_Customer";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

