using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Customer
	{
		public EC_Customer()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _nickname;
		private string _mobile;
		private string _sex;
		private string _companyname;
		private string _partment;
		private string _positions;
		private string _companyaddress;
		private string _website;
		private string _telephone;
		private string _fax;
		private string _qq;
		private string _mobile2;
		private string _hometel;
		private string _homeaddress;
		private string _email;
		private string _birthday;
		private string _cardnumber;
		private string _servicer;
		private DateTime? _startdate= DateTime.Now;
		private DateTime? _enddate= DateTime.Now;
		private string _favrate;
		private string _relationlevel;
		private string _postcode;
		private string _remark;
		private int? _groupid;
		private int? _userid;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
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
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		public string Partment
		{
			set{ _partment=value;}
			get{return _partment;}
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
		public string CompanyAddress
		{
			set{ _companyaddress=value;}
			get{return _companyaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Website
		{
			set{ _website=value;}
			get{return _website;}
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
		public string mobile2
		{
			set{ _mobile2=value;}
			get{return _mobile2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeTel
		{
			set{ _hometel=value;}
			get{return _hometel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomeAddress
		{
			set{ _homeaddress=value;}
			get{return _homeaddress;}
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
		public string Birthday
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
		public DateTime? StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Favrate
		{
			set{ _favrate=value;}
			get{return _favrate;}
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
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
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
		public int? GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

