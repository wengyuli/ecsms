using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_SmsType
	/// </summary>
	public partial class EC_SmsType
	{
		public EC_SmsType()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Type)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_SmsType");
			strSql.Append(" where Type=@Type ");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,50)};
			parameters[0].Value = Type;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ECSMS.Model.EC_SmsType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_SmsType(");
			strSql.Append("Type,Name,Remark,ChannelCode,Price)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Name,@Remark,@ChannelCode,@Price)");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,10),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@ChannelCode", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.ChannelCode;
			parameters[4].Value = model.Price;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECSMS.Model.EC_SmsType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_SmsType set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("ChannelCode=@ChannelCode,");
			strSql.Append("Price=@Price");
			strSql.Append(" where Type=@Type ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@ChannelCode", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.VarChar,50),
					new SqlParameter("@Type", SqlDbType.VarChar,10)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Remark;
			parameters[2].Value = model.ChannelCode;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Type;

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
		public bool Delete(string Type)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EC_SmsType ");
			strSql.Append(" where Type=@Type ");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,50)};
			parameters[0].Value = Type;

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
		public bool DeleteList(string Typelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EC_SmsType ");
			strSql.Append(" where Type in ("+Typelist + ")  ");
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
		public ECSMS.Model.EC_SmsType GetModel(string Type)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Type,Name,Remark,ChannelCode,Price from EC_SmsType ");
			strSql.Append(" where Type=@Type ");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,50)};
			parameters[0].Value = Type;

			ECSMS.Model.EC_SmsType model=new ECSMS.Model.EC_SmsType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.ChannelCode=ds.Tables[0].Rows[0]["ChannelCode"].ToString();
				model.Price=ds.Tables[0].Rows[0]["Price"].ToString();
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
			strSql.Append("select Type,Name,Remark,ChannelCode,Price ");
			strSql.Append(" FROM EC_SmsType ");
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
			strSql.Append(" Type,Name,Remark,ChannelCode,Price ");
			strSql.Append(" FROM EC_SmsType ");
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
			parameters[0].Value = "EC_SmsType";
			parameters[1].Value = "Type";
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

