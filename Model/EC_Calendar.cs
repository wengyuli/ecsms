using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Calendar:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Calendar
	{
		public EC_Calendar()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private DateTime? _todotime= DateTime.Now;
		private DateTime? _posttime= DateTime.Now;
		private int? _isdone;
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
		public DateTime? ToDoTime
		{
			set{ _todotime=value;}
			get{return _todotime;}
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
		public int? IsDone
		{
			set{ _isdone=value;}
			get{return _isdone;}
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

