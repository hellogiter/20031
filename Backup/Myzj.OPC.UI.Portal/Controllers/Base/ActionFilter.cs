using System.Web.Mvc;
namespace Myzj.OPC.UI.Portal.Controllers
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller;
            var actionType = controller.GetType();
            string fullName = actionType.FullName;
            if (!typeof(IBaseController).IsAssignableFrom(actionType) || actionType.IsAbstract || actionType.IsGenericTypeDefinition)
            {
                return;
            }
            IBaseController baseController = (IBaseController)controller;
            baseController.Action_Load();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}