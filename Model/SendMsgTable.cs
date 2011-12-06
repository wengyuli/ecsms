using System;
namespace ECSMS.Model
{
	/// <summary>
	/// SendMsgTable:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SendMsgTable
	{
		public SendMsgTable()
		{}
		#region Model
		private int _msgindex;
		private string _phonenumber;
		private string _msgtitle;
		private string _mmsinfofile;
		private string _timesend;
		private int? _msgstatus;
		private string _msgtype;
		private string _senttime;
		private string _runinfo;
		private string _sendreport;
		private string _servermsgid;
		private int? _spid=0;
		private int? _userid;
		private int? _isexpernum=0;
		private int? _sendnum=1;
		private DateTime? _sendtime= DateTime.Now;
		private int? _exernumbers=0;
		private int? _numberscount;
		private string _serverid;
		/// <summary>
		/// 
		/// </summary>
		public int MsgIndex
		{
			set{ _msgindex=value;}
			get{return _msgindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhoneNumber
		{
			set{ _phonenumber=value;}
			get{return _phonenumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgTitle
		{
			set{ _msgtitle=value;}
			get{return _msgtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MMSInfoFile
		{
			set{ _mmsinfofile=value;}
			get{return _mmsinfofile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TimeSend
		{
			set{ _timesend=value;}
			get{return _timesend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MsgStatus
		{
			set{ _msgstatus=value;}
			get{return _msgstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SentTime
		{
			set{ _senttime=value;}
			get{return _senttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RunInfo
		{
			set{ _runinfo=value;}
			get{return _runinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendReport
		{
			set{ _sendreport=value;}
			get{return _sendreport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerMsgID
		{
			set{ _servermsgid=value;}
			get{return _servermsgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpId
		{
			set{ _spid=value;}
			get{return _spid;}
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
		public int? IsExperNum
		{
			set{ _isexpernum=value;}
			get{return _isexpernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SendNum
		{
			set{ _sendnum=value;}
			get{return _sendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExerNumbers
		{
			set{ _exernumbers=value;}
			get{return _exernumbers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NumbersCount
		{
			set{ _numberscount=value;}
			get{return _numberscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerID
		{
			set{ _serverid=value;}
			get{return _serverid;}
		}
		#endregion Model

	}
}

