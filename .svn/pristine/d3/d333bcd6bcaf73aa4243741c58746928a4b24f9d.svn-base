using System.Collections;
using System.Web.Mvc;

namespace Myzj.OPC.UI.Model.Base
{
    public class KvSelectList : SelectList
    {
        public KvSelectList(IEnumerable items)
            : base(items, "Key", "Value")
        {
        }

        public KvSelectList(IEnumerable items, object selectedValue)
            : base(items, "Key", "Value", selectedValue)
        {
        }

        public KvSelectList(IEnumerable items, string dataValueField, string dataTextField)
            : base(items, dataValueField, dataTextField)
        {
        }

        public KvSelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue)
            : base(items, dataValueField, dataTextField, selectedValue)
        {
        }
    }
}
