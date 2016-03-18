using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWork.Controllers
{
    [紀錄Action的執行時間]
    public class BaseController : Controller
    {
        [HandleError(ExceptionType = typeof(FieldAccessException), View = "ErrorField")]
        [HandleError(ExceptionType = typeof(SqlException), View = "ErrorSql")]
        public ActionResult ErrorPage(string errorMessage)
        {
            switch (errorMessage)
            {
                case "ArgumentException":
                    throw new ArgumentException("ArgumentException");
                case "ArgumentNullException":
                    throw new ArgumentNullException("ArgumentNullException");
                case "FieldAccessException":
                    throw new FieldAccessException("FieldAccessException");
                case "OutOfMemoryException":
                    throw new OutOfMemoryException("OutOfMemoryException");
                case "NullReferenceException":
                    throw new NullReferenceException("NullReferenceException");
                case "Exception":
                    throw new Exception("Exception");
                default:
                    return Content("No Error");
            }
        }

        public ActionResult Debug()
        {
            return View();
        }
    }
}