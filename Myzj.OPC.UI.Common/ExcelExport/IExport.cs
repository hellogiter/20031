using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public interface IExport : IWriteFileSet
	{
		event EventHandler<BeginExportEventArgs> BgExport;

		void Export(string Url, MyFileType fileType);
		byte[] GetFile(MyFileType fileType);
	}
}
