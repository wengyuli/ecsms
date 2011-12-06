using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Numbers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Numbers
	{
		public EC_Numbers()
		{}
		#region Model
		private int _id;
		private string _number;
		private string _remark;
		private string _userid;
		private int? _groupid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		#endregion Model

	}
}

