using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWork.Models;

namespace MVCWork.Controllers
{
    public class ClientAnalysisController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: ClientAnalysis
        public ActionResult Index(string sQuery)
        {
            var 客戶分析 = db.v客戶分析.AsQueryable();

            if (!String.IsNullOrWhiteSpace(sQuery))
            {
                客戶分析 = 客戶分析.Where(p => p.客戶名稱.Contains(sQuery));
            }

            return View(db.v客戶分析.ToList());
        }
    }
}