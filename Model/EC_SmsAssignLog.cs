using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_SmsAssignLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_SmsAssignLog
	{
		public EC_SmsAssignLog()
		{}
		#region Model
		private int _id;
		private int? _touserid;
		private string _acttype;
		private int? _smscount;
		private string _smstype;
		private int? _fromuserid;
		private DateTime? _opertime= DateTime.Now;
		private int? _ispay;
		private string _remark;
		private int? _leavenum;
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
		public int? ToUserId
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActType
		{
			set{ _acttype=value;}
			get{return _acttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SmsCount
		{
			set{ _smscount=value;}
			get{return _smscount;}
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
		public int? FromUserId
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OperTime
		{
			set{ _opertime=value;}
			get{return _opertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsPay
		{
			set{ _ispay=value;}
			get{return _ispay;}
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
		public int? LeaveNum
		{
			set{ _leavenum=value;}
			get{return _leavenum;}
		}
		#endregion Model

	}
}

