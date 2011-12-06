using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_ForbidWord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_ForbidWord
	{
		public EC_ForbidWord()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _channelcode;
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
		public string ChannelCode
		{
			set{ _channelcode=value;}
			get{return _channelcode;}
		}
		#endregion Model

	}
}

