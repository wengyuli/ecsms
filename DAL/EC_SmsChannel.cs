using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_SmsChannel
	/// </summary>
	public partial class EC_SmsChannel
	{
		public EC_SmsChannel()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_SmsChannel");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50)};
			parameters[0].Value = Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ECSMS.Model.EC_SmsChannel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_SmsChannel(");
			strSql.Append("Code,Name,Account,Pwd,CorpId,ProductCode,OtherPara,TotalNum,MaxSendNum,AwokeNum,State)");
			strSql.Append(" values (");
			strSql.Append("@Code,@Name,@Account,@Pwd,@CorpId,@ProductCode,@OtherPara,@TotalNum,@MaxSendNum,@AwokeNum,@State)");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@CorpId", SqlDbType.Int,4),
					new SqlParameter("@ProductCode", SqlDbType.VarChar,20),
					new SqlParameter("@OtherPara", SqlDbType.VarChar,50),
					new SqlParameter("@TotalNum", SqlDbType.Int,4),
					new SqlParameter("@MaxSendNum", SqlDbType.Int,4),
					new SqlParameter("@AwokeNum", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Account;
			parameters[3].Value = model.Pwd;
			parameters[4].Value = model.CorpId;
			parameters[5].Value = model.ProductCode;
			parameters[6].Value = model.OtherPara;
			parameters[7].Value = model.TotalNum;
			parameters[8].Value = model.MaxSendNum;
			parameters[9].Value = model.AwokeNum;
			parameters[10].Value = model.State;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_SmsChannel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_SmsChannel set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Account=@Account,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("CorpId=@CorpId,");
			strSql.Append("ProductCode=@ProductCode,");
			strSql.Append("OtherPara=@OtherPara,");
			strSql.Append("TotalNum=@TotalNum,");
			strSql.Append("MaxSendNum=@MaxSendNum,");
			strSql.Append("AwokeNum=@AwokeNum,");
			strSql.Append("State=@State");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@CorpId", SqlDbType.Int,4),
					new SqlParameter("@ProductCode", SqlDbType.VarChar,20),
					new SqlParameter("@OtherPara", SqlDbType.VarChar,50),
					new SqlParameter("@TotalNum", SqlDbType.Int,4),
					new SqlParameter("@MaxSendNum", SqlDbType.Int,4),
					new SqlParameter("@AwokeNum", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.Pwd;
			parameters[3].Value = model.CorpId;
			parameters[4].Value = model.ProductCode;
			parameters[5].Value = model.OtherPara;
			parameters[6].Value = model.TotalNum;
			parameters[7].Value = model.MaxSendNum;
			parameters[8].Value = model.AwokeNum;
			parameters[9].Value = model.State;
			parameters[10].Value = model.Code;

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
		public bool Delete(string Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EC_SmsChannel ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50)};
			parameters[0].Value = Code;

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
		public bool DeleteList(string Codelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EC_SmsChannel ");
			strSql.Append(" where Code in ("+Codelist + ")  ");
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
		public ECSMS.Model.EC_SmsChannel GetModel(string Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Code,Name,Account,Pwd,CorpId,ProductCode,OtherPara,TotalNum,MaxSendNum,AwokeNum,State from EC_SmsChannel ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50)};
			parameters[0].Value = Code;

			ECSMS.Model.EC_SmsChannel model=new ECSMS.Model.EC_SmsChannel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				model.Pwd=ds.Tables[0].Rows[0]["Pwd"].ToString();
				if(ds.Tables[0].Rows[0]["CorpId"].ToString()!="")
				{
					model.CorpId=int.Parse(ds.Tables[0].Rows[0]["CorpId"].ToString());
				}
				model.ProductCode=ds.Tables[0].Rows[0]["ProductCode"].ToString();
				model.OtherPara=ds.Tables[0].Rows[0]["OtherPara"].ToString();
				if(ds.Tables[0].Rows[0]["TotalNum"].ToString()!="")
				{
					model.TotalNum=int.Parse(ds.Tables[0].Rows[0]["TotalNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaxSendNum"].ToString()!="")
				{
					model.MaxSendNum=int.Parse(ds.Tables[0].Rows[0]["MaxSendNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AwokeNum"].ToString()!="")
				{
					model.AwokeNum=int.Parse(ds.Tables[0].Rows[0]["AwokeNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
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
			strSql.Append("select Code,Name,Account,Pwd,CorpId,ProductCode,OtherPara,TotalNum,MaxSendNum,AwokeNum,State ");
			strSql.Append(" FROM EC_SmsChannel ");
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
			strSql.Append(" Code,Name,Account,Pwd,CorpId,ProductCode,OtherPara,TotalNum,MaxSendNum,AwokeNum,State ");
			strSql.Append(" FROM EC_SmsChannel ");
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
			parameters[0].Value = "EC_SmsChannel";
			parameters[1].Value = "Code";
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

