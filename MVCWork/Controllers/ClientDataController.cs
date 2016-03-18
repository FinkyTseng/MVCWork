using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWork.Models;
using PagedList;
using NPOI.XSSF.UserModel;
using System.IO;

namespace MVCWork.Controllers
{
    public class ClientDataController : BaseController
    {
        private 客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        private int pageSize = 5;

        // GET: 客戶資料
        public ActionResult Index(string sQuery, string 客戶分類, string sortOrder, int? page)
        {
            var PageNumber = page ?? 1;

            var 客戶資料 = repo.Query(sQuery, 客戶分類, sortOrder);

            ViewBag.客戶名稱SortParm = String.IsNullOrWhiteSpace(sortOrder) ? "客戶名稱_Desc" : "";
            ViewBag.統一編號SortParm = sortOrder == ("統一編號") ? "統一編號_Desc" : "統一編號";
            ViewBag.電話SortParm = sortOrder == ("電話") ? "電話_Desc" : "電話";
            ViewBag.傳真SortParm = sortOrder == ("傳真") ? "傳真_Desc" : "傳真";
            ViewBag.地址SortParm = sortOrder == ("地址") ? "地址_Desc" : "地址";
            ViewBag.EmailSortParm = sortOrder == ("Email") ? "Email_Desc" : "Email";

            ViewBag.客戶分類 = new SelectList(get客戶分類(), "Id", "客戶分類名稱");

            return View(客戶資料.ToPagedList(PageNumber, pageSize));
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            ViewBag.客戶分類 = new SelectList(get客戶分類(), "Id", "客戶分類名稱");

            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料 客戶資料)
        {
            if (TryUpdateModel<I客戶資料>(客戶資料))
            {
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶分類 = new SelectList(get客戶分類(), "Id", "客戶分類名稱", 客戶資料.客戶分類);

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            ViewBag.客戶分類 = new SelectList(get客戶分類(), "Id", "客戶分類名稱", 客戶資料.客戶分類);

            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶資料 客戶資料)
        {
            if (TryUpdateModel<I客戶資料>(客戶資料))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶分類 = new SelectList(get客戶分類(), "Id", "客戶分類名稱", 客戶資料.客戶分類);
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = repo.Find(id);
            客戶資料.刪除 = true;
            repo.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;

            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private IList<客戶分類> get客戶分類()
        {
            var 客戶分類repo = RepositoryHelper.Get客戶分類Repository(repo.UnitOfWork);
            return 客戶分類repo.All().ToList();
        }
    }
}
