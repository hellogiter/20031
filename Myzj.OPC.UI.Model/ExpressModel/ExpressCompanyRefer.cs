using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
   public class ExpressCompanyRefer:Pager
   {
       private CompanyModel _search;
       public CompanyModel Search
       {
           get
           {
               if (_search == null)
               {
                   _search = new CompanyModel();
               }
               return _search;
           }
           set { _search = value; }
       }

       private List<CompanyModel> _list;
       public List<CompanyModel> List
       {
           get
           {
             if (_list == null)
             {
                 _list=new List<CompanyModel>();
             }
               return _list;
           }
           set { _list = value; }
       }

   }
}
