using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class ActionLocatorAttribute : ActionNameSelectorAttribute
    {
        public ActionLocatorAttribute()
        {
        }

        public ActionLocatorAttribute(params string[] names)
        {
            Names = names;
        }

        public string[] Names { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            bool flag = false;
            var request = controllerContext.HttpContext.Request;
            if (request.HttpMethod == "POST")
            {
                var allKeys = request.Form.AllKeys;
                if (allKeys.Length > 0)
                {
                    if (Names == null || Names.Length <= 0)
                    {
                        Names = new string[1] { methodInfo.Name };
                    }

                    foreach (string name in Names)
                    {
                        flag = flag | (allKeys.Any(submitName => string.Equals(name, submitName, StringComparison.InvariantCultureIgnoreCase)));
                    }
                }
            }
            return flag;
        }
    }
}