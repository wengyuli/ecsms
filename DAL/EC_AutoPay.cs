using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_AutoPay
	/// </summary>
	public partial class EC_AutoPay
	{
		public EC_AutoPay()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_AutoPay"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_AutoPay");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_AutoPay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_AutoPay(");
			strSql.Append("Name,Account,UserId,UserKey,Expenses,Enabled,PostUser)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Account,@UserId,@UserKey,@Expenses,@Enabled,@PostUser)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Decimal,9),
					new SqlParameter("@UserKey", SqlDbType.VarChar,50),
					new SqlParameter("@Expenses", SqlDbType.VarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Int,4),
					new SqlParameter("@PostUser", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.UserKey;
			parameters[4].Value = model.Expenses;
			parameters[5].Value = model.Enabled;
			parameters[6].Value = model.PostUser;

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
		public bool Update(ECSMS.Model.EC_AutoPay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_AutoPay set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Account=@Account,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("UserKey=@UserKey,");
			strSql.Append("Expenses=@Expenses,");
			strSql.Append("Enabled=@Enabled,");
			strSql.Append("PostUser=@PostUser");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Account", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Decimal,9),
					new SqlParameter("@UserKey", SqlDbType.VarChar,50),
					new SqlParameter("@Expenses", SqlDbType.VarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Int,4),
					new SqlParameter("@PostUser", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.UserKey;
			parameters[4].Value = model.Expenses;
			parameters[5].Value = model.Enabled;
			parameters[6].Value = model.PostUser;
			parameters[7].Value = model.Id;

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
			strSql.Append("delete from EC_AutoPay ");
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
			strSql.Append("delete from EC_AutoPay ");
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
		public ECSMS.Model.EC_AutoPay GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Name,Account,UserId,UserKey,Expenses,Enabled,PostUser from EC_AutoPay ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_AutoPay model=new ECSMS.Model.EC_AutoPay();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=decimal.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
				model.UserKey=ds.Tables[0].Rows[0]["UserKey"].ToString();
				model.Expenses=ds.Tables[0].Rows[0]["Expenses"].ToString();
				if(ds.Tables[0].Rows[0]["Enabled"].ToString()!="")
				{
					model.Enabled=int.Parse(ds.Tables[0].Rows[0]["Enabled"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PostUser"].ToString()!="")
				{
					model.PostUser=int.Parse(ds.Tables[0].Rows[0]["PostUser"].ToString());
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
			strSql.Append("select Id,Name,Account,UserId,UserKey,Expenses,Enabled,PostUser ");
			strSql.Append(" FROM EC_AutoPay ");
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
			strSql.Append(" Id,Name,Account,UserId,UserKey,Expenses,Enabled,PostUser ");
			strSql.Append(" FROM EC_AutoPay ");
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
			parameters[0].Value = "EC_AutoPay";
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

