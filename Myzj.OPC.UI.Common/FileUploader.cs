// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/13 16:47:10
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/13 16:47:10
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Myzj.OPC.UI.Common
{
	/// <summary>
	/// 通用的文件文件上传服务,将请求中的文件保存到特定的文件夹下
	/// </summary>
	public class FileUploader
	{
		/// <summary>
		/// The save path
		/// </summary>
		private string _savePath;

		/// <summary>
		/// Gets or sets 文件保存的路径,~/开头
		/// </summary>
		/// <value>
		/// The save path.
		/// </value>
		public string SavePath
		{
			get
			{
				return this._savePath;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("SavePath", "path can not be null");
				}
				if (!value.StartsWith("~/"))
				{
					throw new ArgumentException("SavePath", "path must start with ~/");
				}
				this._savePath = value;
			}
		}

		/// <summary>
		/// Gets or sets是否在保存时用时间戳来重新命名,文件名将更改为"8990023232_真正文件名.后缀".缺省为false
		/// </summary>
		/// <value>
		/// 需要重命名以防止文件重名的情况,设置为 <c>true</c>; otherwise, <c>false</c>.
		/// </value>
		public bool RenameWithTimeTicks
		{
			get;
			set;
		}

		/// <summary>
		/// 允许的文件扩展名,缺省为 .doc,.docx,.xls,.xlsx
		/// </summary>
		public string[] ExtensionLimit
		{
			get;
			private set;
		}

		/// <summary>
		/// 构造一个实例,保存路径为~/Upload.
		/// </summary>
		public FileUploader()
			: this("~/Upload")
		{
		}

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="savePath">文件在服务器上保存的路径,~/开头</param>
		public FileUploader(string savePath)
		{
			this.SavePath = savePath;
			this.RenameWithTimeTicks = false;
			this.ExtensionLimit = new string[]
			{
				".doc",
				".docx",
				".xls",
				".xlsx"
			};
		}

		/// <summary>
		/// 设置文件扩展名限制范围,只有在扩展名范围内的文件才能上传.
		/// </summary>
		/// <param name="joinedExtensions">文件扩展名(包含前面的点.)用|拼接成的串,为空时表示不限止扩展名</param>
		public void SetExtensionLimit(string joinedExtensions)
		{
			if (string.IsNullOrEmpty(joinedExtensions))
			{
				this.ExtensionLimit = null;
				return;
			}
			else
			{
				this.ExtensionLimit = joinedExtensions.ToLower().Trim().Split("|,".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
			}
		}

		/// <summary>
		/// Processes the specified request.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <param name="error">如果导入出现错误,那么返回错误的信息.</param>
		/// <returns>返回上传的文件名列表</returns>
		/// <exception cref="T:System.ApplicationException">错误的文件类型</exception>
		public List<string> Process(HttpRequestBase request, out string error)
		{
			error = null;
			List<string> fileNames = new List<string>();
			try
			{
				foreach (string item in request.Files)
				{
					HttpPostedFileBase file = request.Files[item];
					if (file != null || file.ContentLength != 0)
					{
						string path = HttpContext.Current.Server.MapPath(this.SavePath);
						if (!Directory.Exists(path))
						{
							Directory.CreateDirectory(path);
						}
						string fileName = Path.GetFileName(file.FileName);
						this.CheckExtension(file.FileName);
						string saveName = this.RenameWithTimeTicks ? string.Format("{0}_{1}", DateTime.Now.Ticks, fileName) : fileName;
						file.SaveAs(Path.Combine(path, saveName));
						fileNames.Add(saveName);
					}
					
				}
			}
			catch (Exception ep)
			{
				error = ep.Message;
			}
			return fileNames;
		}

		/// <summary>
		/// 检查文件扩展名是否在限定的范围内,不在范围内时抛出异常.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <exception cref="T:System.ApplicationException">错误的文件类型</exception>
		private void CheckExtension(string fileName)
		{
			if (this.ExtensionLimit == null || this.ExtensionLimit.Length == 0)
			{
				return;
			}
			if (!string.IsNullOrEmpty(fileName))
			{
				string ext = Path.GetExtension(fileName);
				ext = ext.ToLower();
				if (!this.ExtensionLimit.ToList<string>().Contains(ext))
				{
					throw new ApplicationException("错误的文件类型");
				}
			}
			else
			{
				throw new ApplicationException("请先选择要上传的文件");
			}

		}
	}
}
