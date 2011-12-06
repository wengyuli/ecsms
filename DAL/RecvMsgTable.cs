using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:RecvMsgTable
	/// </summary>
	public partial class RecvMsgTable
	{
		public RecvMsgTable()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MsgIndex", "RecvMsgTable"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MsgIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RecvMsgTable");
			strSql.Append(" where MsgIndex=@MsgIndex ");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)};
			parameters[0].Value = MsgIndex;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.RecvMsgTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RecvMsgTable(");
			strSql.Append("PhoneNumber,MsgTilte,RecvMMSFileDir,MsgStatus,MsgType,RecvTime,ResFile1,ResFile2,ResFile3,ResFile4,ResFile5)");
			strSql.Append(" values (");
			strSql.Append("@PhoneNumber,@MsgTilte,@RecvMMSFileDir,@MsgStatus,@MsgType,@RecvTime,@ResFile1,@ResFile2,@ResFile3,@ResFile4,@ResFile5)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PhoneNumber", SqlDbType.VarChar,50),
					new SqlParameter("@MsgTilte", SqlDbType.VarChar,500),
					new SqlParameter("@RecvMMSFileDir", SqlDbType.VarChar,50),
					new SqlParameter("@MsgStatus", SqlDbType.Int,4),
					new SqlParameter("@MsgType", SqlDbType.Int,4),
					new SqlParameter("@RecvTime", SqlDbType.DateTime),
					new SqlParameter("@ResFile1", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile2", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile3", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile4", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile5", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PhoneNumber;
			parameters[1].Value = model.MsgTilte;
			parameters[2].Value = model.RecvMMSFileDir;
			parameters[3].Value = model.MsgStatus;
			parameters[4].Value = model.MsgType;
			parameters[5].Value = model.RecvTime;
			parameters[6].Value = model.ResFile1;
			parameters[7].Value = model.ResFile2;
			parameters[8].Value = model.ResFile3;
			parameters[9].Value = model.ResFile4;
			parameters[10].Value = model.ResFile5;

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
		public bool Update(ECSMS.Model.RecvMsgTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RecvMsgTable set ");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("MsgTilte=@MsgTilte,");
			strSql.Append("RecvMMSFileDir=@RecvMMSFileDir,");
			strSql.Append("MsgStatus=@MsgStatus,");
			strSql.Append("MsgType=@MsgType,");
			strSql.Append("RecvTime=@RecvTime,");
			strSql.Append("ResFile1=@ResFile1,");
			strSql.Append("ResFile2=@ResFile2,");
			strSql.Append("ResFile3=@ResFile3,");
			strSql.Append("ResFile4=@ResFile4,");
			strSql.Append("ResFile5=@ResFile5");
			strSql.Append(" where MsgIndex=@MsgIndex");
			SqlParameter[] parameters = {
					new SqlParameter("@PhoneNumber", SqlDbType.VarChar,50),
					new SqlParameter("@MsgTilte", SqlDbType.VarChar,500),
					new SqlParameter("@RecvMMSFileDir", SqlDbType.VarChar,50),
					new SqlParameter("@MsgStatus", SqlDbType.Int,4),
					new SqlParameter("@MsgType", SqlDbType.Int,4),
					new SqlParameter("@RecvTime", SqlDbType.DateTime),
					new SqlParameter("@ResFile1", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile2", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile3", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile4", SqlDbType.VarChar,50),
					new SqlParameter("@ResFile5", SqlDbType.VarChar,50),
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)};
			parameters[0].Value = model.PhoneNumber;
			parameters[1].Value = model.MsgTilte;
			parameters[2].Value = model.RecvMMSFileDir;
			parameters[3].Value = model.MsgStatus;
			parameters[4].Value = model.MsgType;
			parameters[5].Value = model.RecvTime;
			parameters[6].Value = model.ResFile1;
			parameters[7].Value = model.ResFile2;
			parameters[8].Value = model.ResFile3;
			parameters[9].Value = model.ResFile4;
			parameters[10].Value = model.ResFile5;
			parameters[11].Value = model.MsgIndex;

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
			strSql.Append("delete from RecvMsgTable ");
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
			strSql.Append("delete from RecvMsgTable ");
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
		public ECSMS.Model.RecvMsgTable GetModel(int MsgIndex)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MsgIndex,PhoneNumber,MsgTilte,RecvMMSFileDir,MsgStatus,MsgType,RecvTime,ResFile1,ResFile2,ResFile3,ResFile4,ResFile5 from RecvMsgTable ");
			strSql.Append(" where MsgIndex=@MsgIndex");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgIndex", SqlDbType.Int,4)
};
			parameters[0].Value = MsgIndex;

			ECSMS.Model.RecvMsgTable model=new ECSMS.Model.RecvMsgTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MsgIndex"].ToString()!="")
				{
					model.MsgIndex=int.Parse(ds.Tables[0].Rows[0]["MsgIndex"].ToString());
				}
				model.PhoneNumber=ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
				model.MsgTilte=ds.Tables[0].Rows[0]["MsgTilte"].ToString();
				model.RecvMMSFileDir=ds.Tables[0].Rows[0]["RecvMMSFileDir"].ToString();
				if(ds.Tables[0].Rows[0]["MsgStatus"].ToString()!="")
				{
					model.MsgStatus=int.Parse(ds.Tables[0].Rows[0]["MsgStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MsgType"].ToString()!="")
				{
					model.MsgType=int.Parse(ds.Tables[0].Rows[0]["MsgType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RecvTime"].ToString()!="")
				{
					model.RecvTime=DateTime.Parse(ds.Tables[0].Rows[0]["RecvTime"].ToString());
				}
				model.ResFile1=ds.Tables[0].Rows[0]["ResFile1"].ToString();
				model.ResFile2=ds.Tables[0].Rows[0]["ResFile2"].ToString();
				model.ResFile3=ds.Tables[0].Rows[0]["ResFile3"].ToString();
				model.ResFile4=ds.Tables[0].Rows[0]["ResFile4"].ToString();
				model.ResFile5=ds.Tables[0].Rows[0]["ResFile5"].ToString();
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
			strSql.Append("select MsgIndex,PhoneNumber,MsgTilte,RecvMMSFileDir,MsgStatus,MsgType,RecvTime,ResFile1,ResFile2,ResFile3,ResFile4,ResFile5 ");
			strSql.Append(" FROM RecvMsgTable ");
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
			strSql.Append(" MsgIndex,PhoneNumber,MsgTilte,RecvMMSFileDir,MsgStatus,MsgType,RecvTime,ResFile1,ResFile2,ResFile3,ResFile4,ResFile5 ");
			strSql.Append(" FROM RecvMsgTable ");
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
			parameters[0].Value = "RecvMsgTable";
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

