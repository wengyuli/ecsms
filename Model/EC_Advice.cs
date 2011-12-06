using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Advice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Advice
	{
		public EC_Advice()
		{}
		#region Model
		private int _id;
		private string _content;
		private int? _state=0;
		private DateTime? _submittime= DateTime.Now;
		private int? _userid=0;
		private DateTime? _donetime= DateTime.Now;
		private int? _doneuserid=0;
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
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SubmitTime
		{
			set{ _submittime=value;}
			get{return _submittime;}
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
		public DateTime? DoneTime
		{
			set{ _donetime=value;}
			get{return _donetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DoneUserId
		{
			set{ _doneuserid=value;}
			get{return _doneuserid;}
		}
		#endregion Model

	}
}

