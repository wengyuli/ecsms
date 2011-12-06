using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_User
	{
		public EC_User()
		{}
		#region Model
		private int _id;
		private string _account;
		private string _pwd;
		private string _name;
		private int? _sex=0;
		private string _telephone;
		private string _mobile;
		private string _email;
		private string _fax;
		private string _qq;
		private string _msn;
		private string _companyname;
		private string _department;
		private string _companyacity;
		private string _companyaddress;
		private string _website;
		private string _postcode;
		private string _sign;
		private int? _signlock=1;
		private int? _awokenum=10000;
		private int? _maxsendnum;
		private int? _role;
		private int? _groupid;
		private int? _state=0;
		private int? _userid=0;
		private int? _operater;
		private int? _online=0;
		private string _trysmstype;
		private string _regfor;
		private string _certificatetype;
		private string _certificatenumbers;
		private string _mobile2;
		private string _positions;
		private string _birthday;
		private string _cardnumber;
		private string _servicer;
		private string _startdate;
		private string _enddate;
		private string _favirate;
		private string _relationlevel;
		private string _remark;
		private int? _islock=0;
		private DateTime? _lastupdatetime;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MSN
		{
			set{ _msn=value;}
			get{return _msn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyaCity
		{
			set{ _companyacity=value;}
			get{return _companyacity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyAddress
		{
			set{ _companyaddress=value;}
			get{return _companyaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sign
		{
			set{ _sign=value;}
			get{return _sign;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SignLock
		{
			set{ _signlock=value;}
			get{return _signlock;}
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
		public int? MaxSendNum
		{
			set{ _maxsendnum=value;}
			get{return _maxsendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Role
		{
			set{ _role=value;}
			get{return _role;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
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
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Operater
		{
			set{ _operater=value;}
			get{return _operater;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OnLine
		{
			set{ _online=value;}
			get{return _online;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrySmsType
		{
			set{ _trysmstype=value;}
			get{return _trysmstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegFor
		{
			set{ _regfor=value;}
			get{return _regfor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CertificateType
		{
			set{ _certificatetype=value;}
			get{return _certificatetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CertificateNumbers
		{
			set{ _certificatenumbers=value;}
			get{return _certificatenumbers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile2
		{
			set{ _mobile2=value;}
			get{return _mobile2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Positions
		{
			set{ _positions=value;}
			get{return _positions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BirthDay
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardNumber
		{
			set{ _cardnumber=value;}
			get{return _cardnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Servicer
		{
			set{ _servicer=value;}
			get{return _servicer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Favirate
		{
			set{ _favirate=value;}
			get{return _favirate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RelationLevel
		{
			set{ _relationlevel=value;}
			get{return _relationlevel;}
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
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastUpdateTime
		{
			set{ _lastupdatetime=value;}
			get{return _lastupdatetime;}
		}
		#endregion Model

	}
}

