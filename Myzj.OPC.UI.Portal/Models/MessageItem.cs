using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Myzj.OPC.UI.Portal.Models
{
	/// <summary>
	/// 信息单元
	/// </summary>
	public class MessageItem
	{
		/// <summary>
		/// 记录所处列表的位置
		/// </summary>
		/// <value>The index.</value>
		public int Index
		{
			get;
			set;
		}

		/// <summary>
		/// 所承载的信息
		/// </summary>
		/// <value>The message.</value>
		public string Message
		{
			get;
			set;
		}

		/// <summary>
		/// 扩展信息
		/// </summary>
		/// <value>The option1.</value>
		public string option1
		{
			get;
			set;
		}
	}
}