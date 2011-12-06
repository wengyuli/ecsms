using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_Area:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_Area
	{
		public EC_Area()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid=0;
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
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

