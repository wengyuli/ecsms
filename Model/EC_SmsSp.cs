using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_SmsSp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_SmsSp
	{
		public EC_SmsSp()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _limit;
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
		public int? Limit
		{
			set{ _limit=value;}
			get{return _limit;}
		}
		#endregion Model

	}
}

