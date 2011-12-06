using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_Bank
	/// </summary>
	public partial class EC_Bank
	{
		public EC_Bank()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_Bank"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_Bank");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_Bank model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_Bank(");
			strSql.Append("BankName,BankAccount,UserId,IconUrl,Name,Remark,PayUrl)");
			strSql.Append(" values (");
			strSql.Append("@BankName,@BankAccount,@UserId,@IconUrl,@Name,@Remark,@PayUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@IconUrl", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@PayUrl", SqlDbType.VarChar,50)};
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.BankAccount;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.IconUrl;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.PayUrl;

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
		public bool Update(ECSMS.Model.EC_Bank model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_Bank set ");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankAccount=@BankAccount,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("IconUrl=@IconUrl,");
			strSql.Append("Name=@Name,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("PayUrl=@PayUrl");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@IconUrl", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@PayUrl", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.BankAccount;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.IconUrl;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.PayUrl;
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
			strSql.Append("delete from EC_Bank ");
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
			strSql.Append("delete from EC_Bank ");
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
		public ECSMS.Model.EC_Bank GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,BankName,BankAccount,UserId,IconUrl,Name,Remark,PayUrl from EC_Bank ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_Bank model=new ECSMS.Model.EC_Bank();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.BankName=ds.Tables[0].Rows[0]["BankName"].ToString();
				model.BankAccount=ds.Tables[0].Rows[0]["BankAccount"].ToString();
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
				model.IconUrl=ds.Tables[0].Rows[0]["IconUrl"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.PayUrl=ds.Tables[0].Rows[0]["PayUrl"].ToString();
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
			strSql.Append("select Id,BankName,BankAccount,UserId,IconUrl,Name,Remark,PayUrl ");
			strSql.Append(" FROM EC_Bank ");
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
			strSql.Append(" Id,BankName,BankAccount,UserId,IconUrl,Name,Remark,PayUrl ");
			strSql.Append(" FROM EC_Bank ");
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
			parameters[0].Value = "EC_Bank";
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

