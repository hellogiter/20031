using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;
using Myzj.OPC.UI.Model.CouponActivity;

namespace Myzj.OPC.UI.Model.CouponActivity
{
   public class CouponActivityRefer:Pager
    {
       public Dictionary<string, object> Filters { get; set; }
       private CouponActivityDetail _searchDetail;
       public CouponActivityDetail SearchDetail
       {
           get
           {
               if (_searchDetail == null)
               {
                   _searchDetail=new CouponActivityDetail();
               }
               return _searchDetail;
           }
           set { _searchDetail = value; }
       }

       private List<CouponActivityDetail> _list;
       public List<CouponActivityDetail> List
       {
           get
           {
               if (_list == null)
               {
                   _list=new List<CouponActivityDetail>();
               }
               return _list;
           }
           set { _list = value; }
       }
    }
}
