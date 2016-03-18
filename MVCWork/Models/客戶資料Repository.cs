using System;
using System.Linq;
using System.Collections.Generic;

namespace MVCWork.Models
{
    public class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.刪除 == false).AsQueryable();
        }

        public 客戶資料 Find(int Id)
        {
            return this.All().Where(p => p.Id == Id).FirstOrDefault();
        }

        public IQueryable<客戶資料> Query(string keyword, string ClintId, string sortOrder)
        {
            var data = this.All();

            if (!String.IsNullOrWhiteSpace(keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(keyword));
            }

            if (!String.IsNullOrWhiteSpace(ClintId))
            {
                int key = Convert.ToInt32(ClintId);
                data = data.Where(p => p.客戶分類 == key);
            }

            switch (sortOrder)
            {
                case "客戶名稱_Desc":
                    data = data.OrderByDescending(p => p.客戶名稱);
                    break;
                case "統一編號":
                    data = data.OrderBy(p => p.統一編號);
                    break;
                case "統一編號_Desc":
                    data = data.OrderByDescending(p => p.統一編號);
                    break;
                case "電話":
                    data = data.OrderBy(p => p.電話);
                    break;
                case "電話_Desc":
                    data = data.OrderByDescending(p => p.電話);
                    break;
                case "傳真":
                    data = data.OrderBy(p => p.傳真);
                    break;
                case "傳真_Desc":
                    data = data.OrderByDescending(p => p.傳真);
                    break;
                case "地址":
                    data = data.OrderBy(p => p.地址);
                    break;
                case "地址_Desc":
                    data = data.OrderByDescending(p => p.地址);
                    break;
                case "Email":
                    data = data.OrderBy(p => p.Email);
                    break;
                case "Email_Desc":
                    data = data.OrderByDescending(p => p.Email);
                    break;
                case "客戶分類":
                    data = data.OrderBy(p => p.客戶分類);
                    break;
                case "客戶分類_Desc":
                    data = data.OrderByDescending(p => p.客戶分類);
                    break;
                default:
                    data = data.OrderBy(p => p.客戶名稱);
                    break;
            }

            return data;
        }
    }

    public interface I客戶資料Repository : IRepository<客戶資料>
    {

    }
}