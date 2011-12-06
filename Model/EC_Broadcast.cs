using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Broadcast:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Broadcast
	{
		public EC_Broadcast()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private DateTime? _posttime= DateTime.Now;
		private string _showname;
		private int? _userid;
		private int? _state=0;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
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
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
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

