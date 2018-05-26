using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public interface IExportSimplePage<TEntity> : IExportPage
	{
		IList<TEntity> GetDataSource();
		Dictionary<string, string> GetHead();
	}
}
