namespace MYZJ.OPC.UI.Model
{
    public class Pager
    {
        private int? _pageIndex = null;
        private int? _pageSize = null;

        public int? PageIndex
        {
            get
            {
                if (_pageIndex == null)
                {
                    _pageIndex = 1;
                }
                return _pageIndex;
            }
            set { _pageIndex = value; }
        }
        public int? PageSize
        {
            get
            {
                if (_pageSize == null)
                {
                    _pageSize = 20;
                }
                return _pageSize;
            }
            set { _pageSize = value; }
        }
        public long? Total { get; set; }
        public string RedirectUrl { get; set; }

        public static bool IsShow(Pager pager)
        {
            bool flag = !(null == pager.Total || pager.Total <= 0);
            return flag;
        }

        /// <summary>
        /// 方法名
        /// </summary>
        public string Fun { get; set; }
    }
}
