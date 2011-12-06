using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ECSMS.DAL
{
	/// <summary>
	/// 数据访问类:EC_DownLoad
	/// </summary>
	public partial class EC_DownLoad
	{
		public EC_DownLoad()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "EC_DownLoad"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EC_DownLoad");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECSMS.Model.EC_DownLoad model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EC_DownLoad(");
			strSql.Append("FullFileName,ShowName,Remark,PostTime,Price)");
			strSql.Append(" values (");
			strSql.Append("@FullFileName,@ShowName,@Remark,@PostTime,@Price)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FullFileName", SqlDbType.VarChar,50),
					new SqlParameter("@ShowName", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Price", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FullFileName;
			parameters[1].Value = model.ShowName;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.PostTime;
			parameters[4].Value = model.Price;

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
		public bool Update(ECSMS.Model.EC_DownLoad model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EC_DownLoad set ");
			strSql.Append("FullFileName=@FullFileName,");
			strSql.Append("ShowName=@ShowName,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("Price=@Price");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@FullFileName", SqlDbType.VarChar,50),
					new SqlParameter("@ShowName", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Price", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.FullFileName;
			parameters[1].Value = model.ShowName;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.PostTime;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Id;

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
			strSql.Append("delete from EC_DownLoad ");
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
			strSql.Append("delete from EC_DownLoad ");
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
		public ECSMS.Model.EC_DownLoad GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,FullFileName,ShowName,Remark,PostTime,Price from EC_DownLoad ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			ECSMS.Model.EC_DownLoad model=new ECSMS.Model.EC_DownLoad();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.FullFileName=ds.Tables[0].Rows[0]["FullFileName"].ToString();
				model.ShowName=ds.Tables[0].Rows[0]["ShowName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
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
			strSql.Append("select Id,FullFileName,ShowName,Remark,PostTime,Price ");
			strSql.Append(" FROM EC_DownLoad ");
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
			strSql.Append(" Id,FullFileName,ShowName,Remark,PostTime,Price ");
			strSql.Append(" FROM EC_DownLoad ");
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
			parameters[0].Value = "EC_DownLoad";
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

