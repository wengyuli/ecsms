using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_UserSmsAccount:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_UserSmsAccount
	{
		public EC_UserSmsAccount()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private string _smstype;
		private int? _initnum=0;
		private int? _largessnum=0;
		private int? _leavenum=0;
		private int? _awokenum=0;
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
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SmsType
		{
			set{ _smstype=value;}
			get{return _smstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InitNum
		{
			set{ _initnum=value;}
			get{return _initnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LargessNum
		{
			set{ _largessnum=value;}
			get{return _largessnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LeaveNum
		{
			set{ _leavenum=value;}
			get{return _leavenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AwokeNum
		{
			set{ _awokenum=value;}
			get{return _awokenum;}
		}
		#endregion Model

	}
}

