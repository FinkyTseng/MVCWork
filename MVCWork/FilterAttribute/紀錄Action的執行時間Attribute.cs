using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace MVCWork.Controllers
{
    internal class 紀錄Action的執行時間Attribute : ActionFilterAttribute
    {
        private Stopwatch stopWatch = new Stopwatch();
         
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopWatch.Reset();
            stopWatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopWatch.Stop();
            string executionTime = stopWatch.Elapsed.TotalMilliseconds.ToString();
            filterContext.Controller.ViewBag.執行時間 = executionTime;

            base.OnActionExecuted(filterContext);
        }
    }
}