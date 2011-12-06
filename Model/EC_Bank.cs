using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Bank:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Bank
	{
		public EC_Bank()
		{}
		#region Model
		private int _id;
		private string _bankname;
		private string _bankaccount;
		private int? _userid;
		private string _iconurl;
		private string _name;
		private string _remark;
		private string _payurl;
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
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankAccount
		{
			set{ _bankaccount=value;}
			get{return _bankaccount;}
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
		public string IconUrl
		{
			set{ _iconurl=value;}
			get{return _iconurl;}
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
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PayUrl
		{
			set{ _payurl=value;}
			get{return _payurl;}
		}
		#endregion Model

	}
}

