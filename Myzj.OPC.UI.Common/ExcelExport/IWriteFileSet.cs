using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public interface IWriteFileSet
	{
		int ColumnStartIndex { get; set; }

		int HeadRowIndex { get; set; }

		int RowStartIndex { get; set; }
	}
}
