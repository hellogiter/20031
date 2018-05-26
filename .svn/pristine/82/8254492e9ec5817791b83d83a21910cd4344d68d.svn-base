using MYZJ.OPC.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.Base
{
    public class BaseRefer<T1,T2>:Pager where T1:class where T2:class 
    {
        private List<T1> _list;

        public List<T1> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<T1>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<T2> _list2;

        public List<T2> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<T2>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private T1 _searchDetail;
        public T1 SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = default(T1);
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private T2 _searchDetailExt;
        public T2 SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = default(T2);
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }


    public class BaseRefer<T> : Pager
        where T : class
    {
        private List<T> _list;

        public List<T> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<T>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<T> _list2;

        public List<T> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<T>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private T _searchDetail;
        public T SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = default(T);
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private T _searchDetailExt;
        public T SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = default(T);
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }




    
}
