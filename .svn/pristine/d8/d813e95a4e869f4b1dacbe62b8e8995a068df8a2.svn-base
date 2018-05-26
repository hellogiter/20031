using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public interface IExportComplexPage<TEntity> : IExportComplexPage, IExportPage
	{
		IList<TEntity> GetDataSource();
		void OnRowExport(object sender, OnRowExportEventArgs<TEntity> e);
	}
}
