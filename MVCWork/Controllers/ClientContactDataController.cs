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

namespace MVCWork.Controllers
{
    public class ClientContactDataController : BaseController
    {
        private 客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();

        private int pageSize = 5;

        // GET: 客戶聯絡人
        public ActionResult Index(string sQuery, string sPosition, string sortOrder, int? page, string ClientId)
        {
            var PageNumber = page ?? 1;

            var 客戶聯絡人 = repo.Query(sQuery, sPosition, sortOrder, ClientId).Include(客 => 客.客戶資料);

            ViewBag.職稱SortParm = String.IsNullOrWhiteSpace(sortOrder) ? "職稱_Desc" : "";
            ViewBag.姓名SortParm = sortOrder == ("姓名") ? "姓名_Desc" : "姓名";
            ViewBag.EmailSortParm = sortOrder == ("Email") ? "Email_Desc" : "Email";
            ViewBag.手機SortParm = sortOrder == ("手機") ? "手機_Desc" : "手機";
            ViewBag.電話SortParm = sortOrder == ("電話") ? "電話_Desc" : "電話";
            ViewBag.客戶名稱SortParm = sortOrder == ("客戶名稱") ? "客戶名稱_Desc" : "客戶名稱";

            ViewBag.ClientId = ClientId;

            return View(客戶聯絡人.ToPagedList(PageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(IList<客戶聯絡人批次更新ViewModel> data, string ClientId)
        {
            int Id = String.IsNullOrWhiteSpace(ClientId) ? 0 : Convert.ToInt32(ClientId);
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var 客戶聯絡人 = repo.Find(item.Id);

                    客戶聯絡人.職稱 = item.職稱;
                    客戶聯絡人.手機 = item.手機;
                    客戶聯絡人.電話 = item.電話;
                }
                repo.UnitOfWork.Commit();
                return RedirectToAction("Details", "ClientData", new { Id = Id });
            }

            return RedirectToAction("Details", "ClientData", new { Id = Id });
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(get客戶資料(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶聯絡人);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(get客戶資料(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(get客戶資料(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo.UnitOfWork.Context.Entry(客戶聯絡人).State = EntityState.Modified;
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(get客戶資料(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            客戶聯絡人.刪除 = true;
            repo.UnitOfWork.Context.Entry(客戶聯絡人).State = EntityState.Modified;
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

        public IList<客戶資料> get客戶資料()
        {
            客戶資料Repository 客戶資料repo = RepositoryHelper.Get客戶資料Repository();
            return 客戶資料repo.All().ToList();
        }
    }
}
