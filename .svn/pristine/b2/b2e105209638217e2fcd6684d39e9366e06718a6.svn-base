namespace Myzj.OPC.UI.Model.Base
{
    public class BaseSearchRequest
    {
        private int? _pageIndex;
        public int? PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = (value < 1 ? 1 : value) ?? 1; }
        }

        private int? _pageSize;
        public int? PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value >= 1000 ? 20 : value) ?? 20; }
        }
    }
}
