
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Myzj.OPC.UI.Common;


namespace Myzj.OPC.UI.Portal.Controllers
{
	public abstract class CommonExportController<TEntity> : BaseController, IExportComplexPage<TEntity>
    {
		protected string FileUrl { get; private set; }


		/// <summary>
		/// 设置导出Excel文件的列标题
		/// </summary>
		/// <returns></returns>
		public abstract IList<string> GetHead();

		/// <summary>
		/// 获取导出文件的列标题
		/// </summary>
		/// <returns></returns>
		public abstract IList<TEntity> GetDataSource();

		/// <summary>
		/// 数据导出前事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void BeginExport(object sender, BeginExportEventArgs e)
		{
		}

		public abstract void OnRowExport(object sender, OnRowExportEventArgs<TEntity> e);

		/// <summary>
		/// 导出数据
		/// </summary>
		/// <param name="fileName">导出文件名称</param>
		/// <returns></returns>
		[NonAction]
		protected ActionResult Export(string fileName = "")
		{

			IExport export = new GetToolManager().InitExport<TEntity>(this);
			string path = base.Server.MapPath(@"~\DownLoad");
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			fileName = ExportHelper.GetMatchUrl(fileName, MyFileType.EXCEL);
			path = path + @"\" + fileName;
			this.FileUrl = path;
			this.EncodeStr(Path.GetFileName(path), Encoding.UTF8);
			try
			{
				byte[] file = export.GetFile(MyFileType.EXCEL);
				if ((file != null) && (file.Length > 0))
				{
					return this.File(file, "application/ms-excel", base.Url.Encode(fileName));
				}
				return null;
			}
			catch (Exception exception)
			{
				return base.Content("<script>alert('数据导出失败：" + exception.Message + "');</script>");
			}
		}

		private string EncodeStr(string str, Encoding coding)
		{
			str = ExportHelper.GetMatchUrl(str, MyFileType.EXCEL);
			string str2 = base.Url.Encode(str);
			if (base.Request.Browser.Type.StartsWith("Firefox"))
			{
				base.Response.HeaderEncoding = coding;
				str2 = coding.GetString(coding.GetBytes(str));
			}
			return str2;
		}
		
    }
}