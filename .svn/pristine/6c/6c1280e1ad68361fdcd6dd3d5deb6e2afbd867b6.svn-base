// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 17:31:00
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 17:31:00
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Myzj.OPC.UI.Common
{
	public static class EventArgExtensions
	{
		public static void Raise<TEventArgs>(this TEventArgs e, object sender, ref EventHandler<TEventArgs> eventDelegate) where TEventArgs : EventArgs
		{
			EventHandler<TEventArgs> handler = Interlocked.CompareExchange<EventHandler<TEventArgs>>(ref eventDelegate, null, null);
			if (handler != null)
			{
				handler(sender, e);
			}
		}
	}
}
