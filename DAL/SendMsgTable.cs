using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:SendMsgTable
	/// </summary>
	public partial class SendMsgTable
	{
		public SendMsgTable()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MsgIndex", "SendMsgTable"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MsgIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SendMsgTable");
			strSql.Append(" where MsgIndex=@MsgIndex ");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)};
			parameters[0].Value = MsgIndex;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.SendMsgTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SendMsgTable(");
			strSql.Append("PhoneNumber,MsgTitle,MMSInfoFile,TimeSend,MsgStatus,MsgType,SentTime,RunInfo,SendReport,ServerMsgID,SpId,UserId,IsExperNum,SendNum,SendTime,ExerNumbers,NumbersCount,ServerID)");
			strSql.Append(" values (");
			strSql.Append("@PhoneNumber,@MsgTitle,@MMSInfoFile,@TimeSend,@MsgStatus,@MsgType,@SentTime,@RunInfo,@SendReport,@ServerMsgID,@SpId,@UserId,@IsExperNum,@SendNum,@SendTime,@ExerNumbers,@NumbersCount,@ServerID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PhoneNumber", SqlDbType.Text),
					new SqlParameter("@MsgTitle", SqlDbType.VarChar,500),
					new SqlParameter("@MMSInfoFile", SqlDbType.VarChar,100),
					new SqlParameter("@TimeSend", SqlDbType.VarChar,50),
					new SqlParameter("@MsgStatus", SqlDbType.Int,4),
					new SqlParameter("@MsgType", SqlDbType.VarChar,50),
					new SqlParameter("@SentTime", SqlDbType.VarChar,50),
					new SqlParameter("@RunInfo", SqlDbType.VarChar,50),
					new SqlParameter("@SendReport", SqlDbType.VarChar,50),
					new SqlParameter("@ServerMsgID", SqlDbType.VarChar,50),
					new SqlParameter("@SpId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@IsExperNum", SqlDbType.Int,4),
					new SqlParameter("@SendNum", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@ExerNumbers", SqlDbType.Int,4),
					new SqlParameter("@NumbersCount", SqlDbType.Int,4),
					new SqlParameter("@ServerID", SqlDbType.VarChar,80)};
			parameters[0].Value = model.PhoneNumber;
			parameters[1].Value = model.MsgTitle;
			parameters[2].Value = model.MMSInfoFile;
			parameters[3].Value = model.TimeSend;
			parameters[4].Value = model.MsgStatus;
			parameters[5].Value = model.MsgType;
			parameters[6].Value = model.SentTime;
			parameters[7].Value = model.RunInfo;
			parameters[8].Value = model.SendReport;
			parameters[9].Value = model.ServerMsgID;
			parameters[10].Value = model.SpId;
			parameters[11].Value = model.UserId;
			parameters[12].Value = model.IsExperNum;
			parameters[13].Value = model.SendNum;
			parameters[14].Value = model.SendTime;
			parameters[15].Value = model.ExerNumbers;
			parameters[16].Value = model.NumbersCount;
			parameters[17].Value = model.ServerID;

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
		public bool Update(ECSMS.Model.SendMsgTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SendMsgTable set ");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("MsgTitle=@MsgTitle,");
			strSql.Append("MMSInfoFile=@MMSInfoFile,");
			strSql.Append("TimeSend=@TimeSend,");
			strSql.Append("MsgStatus=@MsgStatus,");
			strSql.Append("MsgType=@MsgType,");
			strSql.Append("SentTime=@SentTime,");
			strSql.Append("RunInfo=@RunInfo,");
			strSql.Append("SendReport=@SendReport,");
			strSql.Append("ServerMsgID=@ServerMsgID,");
			strSql.Append("SpId=@SpId,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("IsExperNum=@IsExperNum,");
			strSql.Append("SendNum=@SendNum,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("ExerNumbers=@ExerNumbers,");
			strSql.Append("NumbersCount=@NumbersCount,");
			strSql.Append("ServerID=@ServerID");
			strSql.Append(" where MsgIndex=@MsgIndex");
			SqlParameter[] parameters = {
					new SqlParameter("@PhoneNumber", SqlDbType.Text),
					new SqlParameter("@MsgTitle", SqlDbType.VarChar,500),
					new SqlParameter("@MMSInfoFile", SqlDbType.VarChar,100),
					new SqlParameter("@TimeSend", SqlDbType.VarChar,50),
					new SqlParameter("@MsgStatus", SqlDbType.Int,4),
					new SqlParameter("@MsgType", SqlDbType.VarChar,50),
					new SqlParameter("@SentTime", SqlDbType.VarChar,50),
					new SqlParameter("@RunInfo", SqlDbType.VarChar,50),
					new SqlParameter("@SendReport", SqlDbType.VarChar,50),
					new SqlParameter("@ServerMsgID", SqlDbType.VarChar,50),
					new SqlParameter("@SpId", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@IsExperNum", SqlDbType.Int,4),
					new SqlParameter("@SendNum", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@ExerNumbers", SqlDbType.Int,4),
					new SqlParameter("@NumbersCount", SqlDbType.Int,4),
					new SqlParameter("@ServerID", SqlDbType.VarChar,80),
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)};
			parameters[0].Value = model.PhoneNumber;
			parameters[1].Value = model.MsgTitle;
			parameters[2].Value = model.MMSInfoFile;
			parameters[3].Value = model.TimeSend;
			parameters[4].Value = model.MsgStatus;
			parameters[5].Value = model.MsgType;
			parameters[6].Value = model.SentTime;
			parameters[7].Value = model.RunInfo;
			parameters[8].Value = model.SendReport;
			parameters[9].Value = model.ServerMsgID;
			parameters[10].Value = model.SpId;
			parameters[11].Value = model.UserId;
			parameters[12].Value = model.IsExperNum;
			parameters[13].Value = model.SendNum;
			parameters[14].Value = model.SendTime;
			parameters[15].Value = model.ExerNumbers;
			parameters[16].Value = model.NumbersCount;
			parameters[17].Value = model.ServerID;
			parameters[18].Value = model.MsgIndex;

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
		public bool Delete(int MsgIndex)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SendMsgTable ");
			strSql.Append(" where MsgIndex=@MsgIndex");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)
};
			parameters[0].Value = MsgIndex;

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
		public bool DeleteList(string MsgIndexlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SendMsgTable ");
			strSql.Append(" where MsgIndex in ("+MsgIndexlist + ")  ");
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
		public ECSMS.Model.SendMsgTable GetModel(int MsgIndex)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MsgIndex,PhoneNumber,MsgTitle,MMSInfoFile,TimeSend,MsgStatus,MsgType,SentTime,RunInfo,SendReport,ServerMsgID,SpId,UserId,IsExperNum,SendNum,SendTime,ExerNumbers,NumbersCount,ServerID from SendMsgTable ");
			strSql.Append(" where MsgIndex=@MsgIndex");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)
};
			parameters[0].Value = MsgIndex;

			ECSMS.Model.SendMsgTable model=new ECSMS.Model.SendMsgTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MsgIndex"].ToString()!="")
				{
					model.MsgIndex=int.Parse(ds.Tables[0].Rows[0]["MsgIndex"].ToString());
				}
				model.PhoneNumber=ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
				model.MsgTitle=ds.Tables[0].Rows[0]["MsgTitle"].ToString();
				model.MMSInfoFile=ds.Tables[0].Rows[0]["MMSInfoFile"].ToString();
				model.TimeSend=ds.Tables[0].Rows[0]["TimeSend"].ToString();
				if(ds.Tables[0].Rows[0]["MsgStatus"].ToString()!="")
				{
					model.MsgStatus=int.Parse(ds.Tables[0].Rows[0]["MsgStatus"].ToString());
				}
				model.MsgType=ds.Tables[0].Rows[0]["MsgType"].ToString();
				model.SentTime=ds.Tables[0].Rows[0]["SentTime"].ToString();
				model.RunInfo=ds.Tables[0].Rows[0]["RunInfo"].ToString();
				model.SendReport=ds.Tables[0].Rows[0]["SendReport"].ToString();
				model.ServerMsgID=ds.Tables[0].Rows[0]["ServerMsgID"].ToString();
				if(ds.Tables[0].Rows[0]["SpId"].ToString()!="")
				{
					model.SpId=int.Parse(ds.Tables[0].Rows[0]["SpId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsExperNum"].ToString()!="")
				{
					model.IsExperNum=int.Parse(ds.Tables[0].Rows[0]["IsExperNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendNum"].ToString()!="")
				{
					model.SendNum=int.Parse(ds.Tables[0].Rows[0]["SendNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExerNumbers"].ToString()!="")
				{
					model.ExerNumbers=int.Parse(ds.Tables[0].Rows[0]["ExerNumbers"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NumbersCount"].ToString()!="")
				{
					model.NumbersCount=int.Parse(ds.Tables[0].Rows[0]["NumbersCount"].ToString());
				}
				model.ServerID=ds.Tables[0].Rows[0]["ServerID"].ToString();
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
			strSql.Append("select MsgIndex,PhoneNumber,MsgTitle,MMSInfoFile,TimeSend,MsgStatus,MsgType,SentTime,RunInfo,SendReport,ServerMsgID,SpId,UserId,IsExperNum,SendNum,SendTime,ExerNumbers,NumbersCount,ServerID ");
			strSql.Append(" FROM SendMsgTable ");
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
			strSql.Append(" MsgIndex,PhoneNumber,MsgTitle,MMSInfoFile,TimeSend,MsgStatus,MsgType,SentTime,RunInfo,SendReport,ServerMsgID,SpId,UserId,IsExperNum,SendNum,SendTime,ExerNumbers,NumbersCount,ServerID ");
			strSql.Append(" FROM SendMsgTable ");
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
			parameters[0].Value = "SendMsgTable";
			parameters[1].Value = "MsgIndex";
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

