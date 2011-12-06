using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Config:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Config
	{
		public EC_Config()
		{}
		#region Model
		private int _id;
		private string _delpwd;
		private int? _platmax;
		private int? _usermax;
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
		public string DelPwd
		{
			set{ _delpwd=value;}
			get{return _delpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlatMax
		{
			set{ _platmax=value;}
			get{return _platmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserMax
		{
			set{ _usermax=value;}
			get{return _usermax;}
		}
		#endregion Model

	}
}

