using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_User
	/// </summary>
	public partial class EC_User
	{
		public EC_User()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_User"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_User");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_User(");
			strSql.Append("Account,Pwd,Name,Sex,Telephone,Mobile,Email,Fax,QQ,MSN,CompanyName,Department,CompanyaCity,CompanyAddress,WebSite,PostCode,Sign,SignLock,AwokeNum,MaxSendNum,Role,GroupId,State,UserId,Operater,OnLine,TrySmsType,RegFor,CertificateType,CertificateNumbers,Mobile2,Positions,BirthDay,CardNumber,Servicer,StartDate,EndDate,Favirate,RelationLevel,Remark,IsLock,LastUpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@Account,@Pwd,@Name,@Sex,@Telephone,@Mobile,@Email,@Fax,@QQ,@MSN,@CompanyName,@Department,@CompanyaCity,@CompanyAddress,@WebSite,@PostCode,@Sign,@SignLock,@AwokeNum,@MaxSendNum,@Role,@GroupId,@State,@UserId,@Operater,@OnLine,@TrySmsType,@RegFor,@CertificateType,@CertificateNumbers,@Mobile2,@Positions,@BirthDay,@CardNumber,@Servicer,@StartDate,@EndDate,@Favirate,@RelationLevel,@Remark,@IsLock,@LastUpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Account", SqlDbType.VarChar,30),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Telephone", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,20),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyaCity", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyAddress", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,30),
					new SqlParameter("@PostCode", SqlDbType.VarChar,20),
					new SqlParameter("@Sign", SqlDbType.VarChar,50),
					new SqlParameter("@SignLock", SqlDbType.Int,4),
					new SqlParameter("@AwokeNum", SqlDbType.Int,4),
					new SqlParameter("@MaxSendNum", SqlDbType.Int,4),
					new SqlParameter("@Role", SqlDbType.Int,4),
					new SqlParameter("@GroupId", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Operater", SqlDbType.Int,4),
					new SqlParameter("@OnLine", SqlDbType.Int,4),
					new SqlParameter("@TrySmsType", SqlDbType.VarChar,50),
					new SqlParameter("@RegFor", SqlDbType.VarChar,50),
					new SqlParameter("@CertificateType", SqlDbType.VarChar,50),
					new SqlParameter("@CertificateNumbers", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile2", SqlDbType.VarChar,50),
					new SqlParameter("@Positions", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDay", SqlDbType.VarChar,50),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Servicer", SqlDbType.VarChar,50),
					new SqlParameter("@StartDate", SqlDbType.VarChar,50),
					new SqlParameter("@EndDate", SqlDbType.VarChar,50),
					new SqlParameter("@Favirate", SqlDbType.VarChar,50),
					new SqlParameter("@RelationLevel", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@LastUpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Account;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Telephone;
			parameters[5].Value = model.Mobile;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Fax;
			parameters[8].Value = model.QQ;
			parameters[9].Value = model.MSN;
			parameters[10].Value = model.CompanyName;
			parameters[11].Value = model.Department;
			parameters[12].Value = model.CompanyaCity;
			parameters[13].Value = model.CompanyAddress;
			parameters[14].Value = model.WebSite;
			parameters[15].Value = model.PostCode;
			parameters[16].Value = model.Sign;
			parameters[17].Value = model.SignLock;
			parameters[18].Value = model.AwokeNum;
			parameters[19].Value = model.MaxSendNum;
			parameters[20].Value = model.Role;
			parameters[21].Value = model.GroupId;
			parameters[22].Value = model.State;
			parameters[23].Value = model.UserId;
			parameters[24].Value = model.Operater;
			parameters[25].Value = model.OnLine;
			parameters[26].Value = model.TrySmsType;
			parameters[27].Value = model.RegFor;
			parameters[28].Value = model.CertificateType;
			parameters[29].Value = model.CertificateNumbers;
			parameters[30].Value = model.Mobile2;
			parameters[31].Value = model.Positions;
			parameters[32].Value = model.BirthDay;
			parameters[33].Value = model.CardNumber;
			parameters[34].Value = model.Servicer;
			parameters[35].Value = model.StartDate;
			parameters[36].Value = model.EndDate;
			parameters[37].Value = model.Favirate;
			parameters[38].Value = model.RelationLevel;
			parameters[39].Value = model.Remark;
			parameters[40].Value = model.IsLock;
			parameters[41].Value = model.LastUpdateTime;

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
		public bool Update(ECSMS.Model.EC_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_User set ");
			strSql.Append("Account=@Account,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("Name=@Name,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Email=@Email,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("MSN=@MSN,");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("Department=@Department,");
			strSql.Append("CompanyaCity=@CompanyaCity,");
			strSql.Append("CompanyAddress=@CompanyAddress,");
			strSql.Append("WebSite=@WebSite,");
			strSql.Append("PostCode=@PostCode,");
			strSql.Append("Sign=@Sign,");
			strSql.Append("SignLock=@SignLock,");
			strSql.Append("AwokeNum=@AwokeNum,");
			strSql.Append("MaxSendNum=@MaxSendNum,");
			strSql.Append("Role=@Role,");
			strSql.Append("GroupId=@GroupId,");
			strSql.Append("State=@State,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Operater=@Operater,");
			strSql.Append("OnLine=@OnLine,");
			strSql.Append("TrySmsType=@TrySmsType,");
			strSql.Append("RegFor=@RegFor,");
			strSql.Append("CertificateType=@CertificateType,");
			strSql.Append("CertificateNumbers=@CertificateNumbers,");
			strSql.Append("Mobile2=@Mobile2,");
			strSql.Append("Positions=@Positions,");
			strSql.Append("BirthDay=@BirthDay,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("Servicer=@Servicer,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Favirate=@Favirate,");
			strSql.Append("RelationLevel=@RelationLevel,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("LastUpdateTime=@LastUpdateTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Account", SqlDbType.VarChar,30),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Telephone", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,20),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyaCity", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyAddress", SqlDbType.VarChar,50),
					new SqlParameter("@WebSite", SqlDbType.VarChar,30),
					new SqlParameter("@PostCode", SqlDbType.VarChar,20),
					new SqlParameter("@Sign", SqlDbType.VarChar,50),
					new SqlParameter("@SignLock", SqlDbType.Int,4),
					new SqlParameter("@AwokeNum", SqlDbType.Int,4),
					new SqlParameter("@MaxSendNum", SqlDbType.Int,4),
					new SqlParameter("@Role", SqlDbType.Int,4),
					new SqlParameter("@GroupId", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Operater", SqlDbType.Int,4),
					new SqlParameter("@OnLine", SqlDbType.Int,4),
					new SqlParameter("@TrySmsType", SqlDbType.VarChar,50),
					new SqlParameter("@RegFor", SqlDbType.VarChar,50),
					new SqlParameter("@CertificateType", SqlDbType.VarChar,50),
					new SqlParameter("@CertificateNumbers", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile2", SqlDbType.VarChar,50),
					new SqlParameter("@Positions", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDay", SqlDbType.VarChar,50),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Servicer", SqlDbType.VarChar,50),
					new SqlParameter("@StartDate", SqlDbType.VarChar,50),
					new SqlParameter("@EndDate", SqlDbType.VarChar,50),
					new SqlParameter("@Favirate", SqlDbType.VarChar,50),
					new SqlParameter("@RelationLevel", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@LastUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Account;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Telephone;
			parameters[5].Value = model.Mobile;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Fax;
			parameters[8].Value = model.QQ;
			parameters[9].Value = model.MSN;
			parameters[10].Value = model.CompanyName;
			parameters[11].Value = model.Department;
			parameters[12].Value = model.CompanyaCity;
			parameters[13].Value = model.CompanyAddress;
			parameters[14].Value = model.WebSite;
			parameters[15].Value = model.PostCode;
			parameters[16].Value = model.Sign;
			parameters[17].Value = model.SignLock;
			parameters[18].Value = model.AwokeNum;
			parameters[19].Value = model.MaxSendNum;
			parameters[20].Value = model.Role;
			parameters[21].Value = model.GroupId;
			parameters[22].Value = model.State;
			parameters[23].Value = model.UserId;
			parameters[24].Value = model.Operater;
			parameters[25].Value = model.OnLine;
			parameters[26].Value = model.TrySmsType;
			parameters[27].Value = model.RegFor;
			parameters[28].Value = model.CertificateType;
			parameters[29].Value = model.CertificateNumbers;
			parameters[30].Value = model.Mobile2;
			parameters[31].Value = model.Positions;
			parameters[32].Value = model.BirthDay;
			parameters[33].Value = model.CardNumber;
			parameters[34].Value = model.Servicer;
			parameters[35].Value = model.StartDate;
			parameters[36].Value = model.EndDate;
			parameters[37].Value = model.Favirate;
			parameters[38].Value = model.RelationLevel;
			parameters[39].Value = model.Remark;
			parameters[40].Value = model.IsLock;
			parameters[41].Value = model.LastUpdateTime;
			parameters[42].Value = model.Id;

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
			strSql.Append("delete from EC_User ");
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
			strSql.Append("delete from EC_User ");
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
		public ECSMS.Model.EC_User GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Account,Pwd,Name,Sex,Telephone,Mobile,Email,Fax,QQ,MSN,CompanyName,Department,CompanyaCity,CompanyAddress,WebSite,PostCode,Sign,SignLock,AwokeNum,MaxSendNum,Role,GroupId,State,UserId,Operater,OnLine,TrySmsType,RegFor,CertificateType,CertificateNumbers,Mobile2,Positions,BirthDay,CardNumber,Servicer,StartDate,EndDate,Favirate,RelationLevel,Remark,IsLock,LastUpdateTime from EC_User ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_User model=new ECSMS.Model.EC_User();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				model.Pwd=ds.Tables[0].Rows[0]["Pwd"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
				}
				model.Telephone=ds.Tables[0].Rows[0]["Telephone"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.MSN=ds.Tables[0].Rows[0]["MSN"].ToString();
				model.CompanyName=ds.Tables[0].Rows[0]["CompanyName"].ToString();
				model.Department=ds.Tables[0].Rows[0]["Department"].ToString();
				model.CompanyaCity=ds.Tables[0].Rows[0]["CompanyaCity"].ToString();
				model.CompanyAddress=ds.Tables[0].Rows[0]["CompanyAddress"].ToString();
				model.WebSite=ds.Tables[0].Rows[0]["WebSite"].ToString();
				model.PostCode=ds.Tables[0].Rows[0]["PostCode"].ToString();
				model.Sign=ds.Tables[0].Rows[0]["Sign"].ToString();
				if(ds.Tables[0].Rows[0]["SignLock"].ToString()!="")
				{
					model.SignLock=int.Parse(ds.Tables[0].Rows[0]["SignLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AwokeNum"].ToString()!="")
				{
					model.AwokeNum=int.Parse(ds.Tables[0].Rows[0]["AwokeNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaxSendNum"].ToString()!="")
				{
					model.MaxSendNum=int.Parse(ds.Tables[0].Rows[0]["MaxSendNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Role"].ToString()!="")
				{
					model.Role=int.Parse(ds.Tables[0].Rows[0]["Role"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GroupId"].ToString()!="")
				{
					model.GroupId=int.Parse(ds.Tables[0].Rows[0]["GroupId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Operater"].ToString()!="")
				{
					model.Operater=int.Parse(ds.Tables[0].Rows[0]["Operater"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OnLine"].ToString()!="")
				{
					model.OnLine=int.Parse(ds.Tables[0].Rows[0]["OnLine"].ToString());
				}
				model.TrySmsType=ds.Tables[0].Rows[0]["TrySmsType"].ToString();
				model.RegFor=ds.Tables[0].Rows[0]["RegFor"].ToString();
				model.CertificateType=ds.Tables[0].Rows[0]["CertificateType"].ToString();
				model.CertificateNumbers=ds.Tables[0].Rows[0]["CertificateNumbers"].ToString();
				model.Mobile2=ds.Tables[0].Rows[0]["Mobile2"].ToString();
				model.Positions=ds.Tables[0].Rows[0]["Positions"].ToString();
				model.BirthDay=ds.Tables[0].Rows[0]["BirthDay"].ToString();
				model.CardNumber=ds.Tables[0].Rows[0]["CardNumber"].ToString();
				model.Servicer=ds.Tables[0].Rows[0]["Servicer"].ToString();
				model.StartDate=ds.Tables[0].Rows[0]["StartDate"].ToString();
				model.EndDate=ds.Tables[0].Rows[0]["EndDate"].ToString();
				model.Favirate=ds.Tables[0].Rows[0]["Favirate"].ToString();
				model.RelationLevel=ds.Tables[0].Rows[0]["RelationLevel"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString()!="")
				{
					model.LastUpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
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
			strSql.Append("select Id,Account,Pwd,Name,Sex,Telephone,Mobile,Email,Fax,QQ,MSN,CompanyName,Department,CompanyaCity,CompanyAddress,WebSite,PostCode,Sign,SignLock,AwokeNum,MaxSendNum,Role,GroupId,State,UserId,Operater,OnLine,TrySmsType,RegFor,CertificateType,CertificateNumbers,Mobile2,Positions,BirthDay,CardNumber,Servicer,StartDate,EndDate,Favirate,RelationLevel,Remark,IsLock,LastUpdateTime ");
			strSql.Append(" FROM EC_User ");
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
			strSql.Append(" Id,Account,Pwd,Name,Sex,Telephone,Mobile,Email,Fax,QQ,MSN,CompanyName,Department,CompanyaCity,CompanyAddress,WebSite,PostCode,Sign,SignLock,AwokeNum,MaxSendNum,Role,GroupId,State,UserId,Operater,OnLine,TrySmsType,RegFor,CertificateType,CertificateNumbers,Mobile2,Positions,BirthDay,CardNumber,Servicer,StartDate,EndDate,Favirate,RelationLevel,Remark,IsLock,LastUpdateTime ");
			strSql.Append(" FROM EC_User ");
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
			parameters[0].Value = "EC_User";
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

