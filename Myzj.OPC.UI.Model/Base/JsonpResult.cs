using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace Myzj.OPC.UI.Model.Base
{
    /// <summary>
    /// jsonp 支持
    /// </summary>
    public class JsonpResult : JsonResult
    {
        private const string JsonpCallbackName = "callback";
        private const string CallbackApplicationType = "application/json";

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="context"/> parameter is null.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null || context.HttpContext == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet) &&
                  String.Equals(context.HttpContext.Request.HttpMethod, "GET"))
            {
                throw new InvalidOperationException();
            }
            var response = context.HttpContext.Response;
            if (!String.IsNullOrEmpty(ContentType))
                response.ContentType = ContentType;
            else
                response.ContentType = CallbackApplicationType;
            if (ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (Data != null)
            {
                var request = context.HttpContext.Request;
                var jsonStr = JsonConvert.SerializeObject(Data);

                if (request[JsonpCallbackName] != null)
                    jsonStr = String.Format("{0}({1});", request[JsonpCallbackName], jsonStr);

                response.Write(jsonStr);
            }
        }
    }
}
