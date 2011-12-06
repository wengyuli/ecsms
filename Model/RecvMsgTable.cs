using System;
namespace ECSMS.Model
{
	/// <summary>
	/// RecvMsgTable:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RecvMsgTable
	{
		public RecvMsgTable()
		{}
		#region Model
		private int _msgindex;
		private string _phonenumber;
		private string _msgtilte;
		private string _recvmmsfiledir;
		private int? _msgstatus;
		private int? _msgtype;
		private DateTime? _recvtime= DateTime.Now;
		private string _resfile1;
		private string _resfile2;
		private string _resfile3;
		private string _resfile4;
		private string _resfile5;
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
		public string MsgTilte
		{
			set{ _msgtilte=value;}
			get{return _msgtilte;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecvMMSFileDir
		{
			set{ _recvmmsfiledir=value;}
			get{return _recvmmsfiledir;}
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
		public int? MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RecvTime
		{
			set{ _recvtime=value;}
			get{return _recvtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResFile1
		{
			set{ _resfile1=value;}
			get{return _resfile1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResFile2
		{
			set{ _resfile2=value;}
			get{return _resfile2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResFile3
		{
			set{ _resfile3=value;}
			get{return _resfile3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResFile4
		{
			set{ _resfile4=value;}
			get{return _resfile4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResFile5
		{
			set{ _resfile5=value;}
			get{return _resfile5;}
		}
		#endregion Model

	}
}

