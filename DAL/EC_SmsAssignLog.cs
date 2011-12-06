using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_SmsAssignLog
	/// </summary>
	public partial class EC_SmsAssignLog
	{
		public EC_SmsAssignLog()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_SmsAssignLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_SmsAssignLog");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_SmsAssignLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_SmsAssignLog(");
			strSql.Append("ToUserId,ActType,SmsCount,SmsType,FromUserId,OperTime,IsPay,Remark,LeaveNum)");
			strSql.Append(" values (");
			strSql.Append("@ToUserId,@ActType,@SmsCount,@SmsType,@FromUserId,@OperTime,@IsPay,@Remark,@LeaveNum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ToUserId", SqlDbType.Int,4),
					new SqlParameter("@ActType", SqlDbType.VarChar,10),
					new SqlParameter("@SmsCount", SqlDbType.Int,4),
					new SqlParameter("@SmsType", SqlDbType.VarChar,10),
					new SqlParameter("@FromUserId", SqlDbType.Int,4),
					new SqlParameter("@OperTime", SqlDbType.DateTime),
					new SqlParameter("@IsPay", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@LeaveNum", SqlDbType.Int,4)};
			parameters[0].Value = model.ToUserId;
			parameters[1].Value = model.ActType;
			parameters[2].Value = model.SmsCount;
			parameters[3].Value = model.SmsType;
			parameters[4].Value = model.FromUserId;
			parameters[5].Value = model.OperTime;
			parameters[6].Value = model.IsPay;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.LeaveNum;

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
		public bool Update(ECSMS.Model.EC_SmsAssignLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_SmsAssignLog set ");
			strSql.Append("ToUserId=@ToUserId,");
			strSql.Append("ActType=@ActType,");
			strSql.Append("SmsCount=@SmsCount,");
			strSql.Append("SmsType=@SmsType,");
			strSql.Append("FromUserId=@FromUserId,");
			strSql.Append("OperTime=@OperTime,");
			strSql.Append("IsPay=@IsPay,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("LeaveNum=@LeaveNum");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ToUserId", SqlDbType.Int,4),
					new SqlParameter("@ActType", SqlDbType.VarChar,10),
					new SqlParameter("@SmsCount", SqlDbType.Int,4),
					new SqlParameter("@SmsType", SqlDbType.VarChar,10),
					new SqlParameter("@FromUserId", SqlDbType.Int,4),
					new SqlParameter("@OperTime", SqlDbType.DateTime),
					new SqlParameter("@IsPay", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@LeaveNum", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ToUserId;
			parameters[1].Value = model.ActType;
			parameters[2].Value = model.SmsCount;
			parameters[3].Value = model.SmsType;
			parameters[4].Value = model.FromUserId;
			parameters[5].Value = model.OperTime;
			parameters[6].Value = model.IsPay;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.LeaveNum;
			parameters[9].Value = model.Id;

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
			strSql.Append("delete from EC_SmsAssignLog ");
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
			strSql.Append("delete from EC_SmsAssignLog ");
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
		public ECSMS.Model.EC_SmsAssignLog GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ToUserId,ActType,SmsCount,SmsType,FromUserId,OperTime,IsPay,Remark,LeaveNum from EC_SmsAssignLog ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_SmsAssignLog model=new ECSMS.Model.EC_SmsAssignLog();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserId"].ToString()!="")
				{
					model.ToUserId=int.Parse(ds.Tables[0].Rows[0]["ToUserId"].ToString());
				}
				model.ActType=ds.Tables[0].Rows[0]["ActType"].ToString();
				if(ds.Tables[0].Rows[0]["SmsCount"].ToString()!="")
				{
					model.SmsCount=int.Parse(ds.Tables[0].Rows[0]["SmsCount"].ToString());
				}
				model.SmsType=ds.Tables[0].Rows[0]["SmsType"].ToString();
				if(ds.Tables[0].Rows[0]["FromUserId"].ToString()!="")
				{
					model.FromUserId=int.Parse(ds.Tables[0].Rows[0]["FromUserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OperTime"].ToString()!="")
				{
					model.OperTime=DateTime.Parse(ds.Tables[0].Rows[0]["OperTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPay"].ToString()!="")
				{
					model.IsPay=int.Parse(ds.Tables[0].Rows[0]["IsPay"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["LeaveNum"].ToString()!="")
				{
					model.LeaveNum=int.Parse(ds.Tables[0].Rows[0]["LeaveNum"].ToString());
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
			strSql.Append("select Id,ToUserId,ActType,SmsCount,SmsType,FromUserId,OperTime,IsPay,Remark,LeaveNum ");
			strSql.Append(" FROM EC_SmsAssignLog ");
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
			strSql.Append(" Id,ToUserId,ActType,SmsCount,SmsType,FromUserId,OperTime,IsPay,Remark,LeaveNum ");
			strSql.Append(" FROM EC_SmsAssignLog ");
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
			parameters[0].Value = "EC_SmsAssignLog";
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

