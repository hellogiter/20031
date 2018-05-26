using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	internal interface IExportComplexEvent : IExport, IWriteFileSet
	{
		event EventHandler<OnRowExportEventArgs> RowExport;
	}
}
