using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_DownLoad:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_DownLoad
	{
		public EC_DownLoad()
		{}
		#region Model
		private int _id;
		private string _fullfilename;
		private string _showname;
		private string _remark;
		private DateTime? _posttime= DateTime.Now;
		private string _price="A-0|B-0|C-0|D-0|E-0";
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
		public string FullFileName
		{
			set{ _fullfilename=value;}
			get{return _fullfilename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShowName
		{
			set{ _showname=value;}
			get{return _showname;}
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
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		#endregion Model

	}
}

