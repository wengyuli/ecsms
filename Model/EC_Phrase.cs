using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Phrase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Phrase
	{
		public EC_Phrase()
		{}
		#region Model
		private int _id;
		private string _phrase;
		private int? _groupid;
		private string _userid;
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
		public string Phrase
		{
			set{ _phrase=value;}
			get{return _phrase;}
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
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

