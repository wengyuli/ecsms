using System;
namespace ECSMS.Model
{
	/// <summary>
	/// EC_SmsType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EC_SmsType
	{
		public EC_SmsType()
		{}
		#region Model
		private string _type;
		private string _name;
		private string _remark;
		private string _channelcode;
		private string _price;
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
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
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChannelCode
		{
			set{ _channelcode=value;}
			get{return _channelcode;}
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

