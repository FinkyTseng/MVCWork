using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWork.Models;

namespace MVCWork.Controllers
{
    public class ClientAnalysisController : BaseController
    {
        v客戶分析Repository repo = RepositoryHelper.Getv客戶分析Repository();

        // GET: ClientAnalysis
        public ActionResult Index(string sQuery)
        {
            var 客戶分析 = repo.Query(sQuery);

            return View(客戶分析.ToList());
        }
    }
}