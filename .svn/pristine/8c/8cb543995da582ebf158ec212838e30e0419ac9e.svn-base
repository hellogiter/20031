namespace Myzj.OPC.UI.Model.Base
{
    public class BaseResponse
    {
        /// <summary>
        /// 是否正确
        /// </summary>
        public bool DoFlag { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public dynamic DoResult { get; set; }
        /// <summary>
        /// 返回值
        /// </summary>
        public string Data { get; set; }
        
    }

    public class BaseResponse<T> : BaseResponse
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Info { get; set; }
    }
}
