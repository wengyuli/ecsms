using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_SmsChannel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_SmsChannel
	{
		public EC_SmsChannel()
		{}
		#region Model
		private string _code;
		private string _name;
		private string _account;
		private string _pwd;
		private int? _corpid;
		private string _productcode;
		private string _otherpara;
		private int? _totalnum;
		private int? _maxsendnum;
		private int? _awokenum;
		private int? _state;
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CorpId
		{
			set{ _corpid=value;}
			get{return _corpid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductCode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherPara
		{
			set{ _otherpara=value;}
			get{return _otherpara;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TotalNum
		{
			set{ _totalnum=value;}
			get{return _totalnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MaxSendNum
		{
			set{ _maxsendnum=value;}
			get{return _maxsendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AwokeNum
		{
			set{ _awokenum=value;}
			get{return _awokenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

