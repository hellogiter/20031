using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.Portal.Models
{
	/// <summary>
	/// 信息列表，用于在页面上显示多条信息
	/// </summary>
	public class MessageList
	{
		private int index_cur;

		/// <summary>
		/// 信息列表
		/// </summary>
		/// <value>The messages.</value>
		public List<MessageItem> Messages
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the <see cref="T:System.String" /> at the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>System.String.</returns>
		[JsonIgnore]
		public string this[int index]
		{
			get
			{
				MessageItem item = this.Messages.Find((MessageItem lang) => lang.Index == index);
				if (item != null)
				{
					return item.Message;
				}
				return "";
			}
			set
			{
				MessageItem item = this.Messages.Find((MessageItem lang) => lang.Index == index);
				if (item != null)
				{
					item.Message = value;
					return;
				}
				MessageItem item2 = this.Messages.LastOrDefault<MessageItem>();
				if (item2 != null)
				{
					this.Messages.Add(new MessageItem
					{
						Index = item2.Index + 1,
						Message = value
					});
				}
			}
		}

		/// <summary>
		/// 新增一条信息
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="message">The message.</param>
		/// <param name="option">The option.</param>
		public void Add(int index, string message, string option = "")
		{
			this.index_cur = index;
			MessageItem item = new MessageItem
			{
				Index = index,
				Message = message,
				option1 = option
			};
			if (this.Messages == null)
			{
				this.Messages = new List<MessageItem>();
			}
			this.Messages.Add(item);
		}

		/// <summary>
		/// 新增一条信息，index自增
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="option">The option.</param>
		public void Add(string message, string option = "")
		{
			MessageItem item = new MessageItem
			{
				Index = this.index_cur + 1,
				Message = message,
				option1 = option
			};
			if (this.Messages == null)
			{
				this.Messages = new List<MessageItem>();
			}
			this.Messages.Add(item);
		}

		/// <summary>
		///  将另一个messageList合并到这个实例中
		/// </summary>
		/// <param name="list">The list.</param>
		public void Merge(MessageList list)
		{
			if (list == null || list.Messages == null)
			{
				return;
			}
			if (this.Messages == null)
			{
				this.Messages = new List<MessageItem>();
			}
			foreach (MessageItem one in list.Messages)
			{
				this.Messages.Add(one);
			}
		}
	}
}