using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
   public class ExpressSelfAccessRefer:Pager
   {
       private ExpressSelfAccessSearchModel _search;
       public ExpressSelfAccessSearchModel Search
       {
           get
           {
               if (_search == null)
               {
                   _search = new ExpressSelfAccessSearchModel();
               }
               return _search;
           }
           set { _search = value; }
       }

       private List<ExpressSelfAccessModel> _list;
       public List<ExpressSelfAccessModel> List
       {
           get
           {
               if (_list == null)
               {
                   _list = new List<ExpressSelfAccessModel>();
               }
               return _list;
           }
           set { _list = value; }
       }
   }
}
