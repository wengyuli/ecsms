using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_Broadcast
	/// </summary>
	public partial class EC_Broadcast
	{
		public EC_Broadcast()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_Broadcast"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_Broadcast");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_Broadcast model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_Broadcast(");
			strSql.Append("Title,Content,PostTime,ShowName,UserId,State)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Content,@PostTime,@ShowName,@UserId,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,1000),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@ShowName", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.PostTime;
			parameters[3].Value = model.ShowName;
			parameters[4].Value = model.UserId;
			parameters[5].Value = model.State;

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
		public bool Update(ECSMS.Model.EC_Broadcast model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_Broadcast set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("ShowName=@ShowName,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("State=@State");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,1000),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@ShowName", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.PostTime;
			parameters[3].Value = model.ShowName;
			parameters[4].Value = model.UserId;
			parameters[5].Value = model.State;
			parameters[6].Value = model.Id;

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
			strSql.Append("delete from EC_Broadcast ");
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
			strSql.Append("delete from EC_Broadcast ");
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
		public ECSMS.Model.EC_Broadcast GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,Content,PostTime,ShowName,UserId,State from EC_Broadcast ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_Broadcast model=new ECSMS.Model.EC_Broadcast();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				model.ShowName=ds.Tables[0].Rows[0]["ShowName"].ToString();
				if(ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
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
			strSql.Append("select Id,Title,Content,PostTime,ShowName,UserId,State ");
			strSql.Append(" FROM EC_Broadcast ");
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
			strSql.Append(" Id,Title,Content,PostTime,ShowName,UserId,State ");
			strSql.Append(" FROM EC_Broadcast ");
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
			parameters[0].Value = "EC_Broadcast";
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

