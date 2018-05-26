using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class GroupStructureListRefer : Pager
    {
        private GroupStructureListSearch _searchDetail;
        public GroupStructureListSearch SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new GroupStructureListSearch();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private List<GroupStructureListSearchResult> _list;
        public List<GroupStructureListSearchResult> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<GroupStructureListSearchResult>();
                }
                return _list;
            }
            set { _list = value; }
        }
        public Dictionary<string, object> Filters { get; set; }
    }
}
