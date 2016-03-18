using System;
using System.Linq;
using System.Collections.Generic;

namespace MVCWork.Models
{
    public class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.刪除 == false).AsQueryable();
        }

        public 客戶聯絡人 Find(int Id)
        {
            return this.All().Where(p => p.Id == Id).FirstOrDefault();
        }

        public IQueryable<客戶聯絡人> Query(string keyword, string sPosition, string sortOrder, string ClientId)
        {
            var data = this.All();

            if (!String.IsNullOrWhiteSpace(keyword))
            {
                data = data.Where(p => p.姓名.Contains(keyword));
            }

            if (!String.IsNullOrWhiteSpace(sPosition))
            {
                data = data.Where(p => p.職稱.Contains(sPosition));
            }

            if (!String.IsNullOrWhiteSpace(ClientId))
            {
                int Id = Convert.ToInt32(ClientId);
                data = data.Where(p => p.客戶Id == Id);
            }

            switch (sortOrder)
            {
                case "職稱_Desc":
                    data = data.OrderByDescending(p => p.職稱);
                    break;
                case "姓名":
                    data = data.OrderBy(p => p.姓名);
                    break;
                case "姓名_Desc":
                    data = data.OrderByDescending(p => p.姓名);
                    break;
                case "電話":
                    data = data.OrderBy(p => p.電話);
                    break;
                case "電話_Desc":
                    data = data.OrderByDescending(p => p.電話);
                    break;
                case "手機":
                    data = data.OrderBy(p => p.手機);
                    break;
                case "手機_Desc":
                    data = data.OrderByDescending(p => p.手機);
                    break;
                case "Email":
                    data = data.OrderBy(p => p.Email);
                    break;
                case "Email_Desc":
                    data = data.OrderByDescending(p => p.Email);
                    break;
                case "客戶名稱":
                    data = data.OrderBy(p => p.客戶資料.客戶名稱);
                    break;
                case "客戶名稱_Desc":
                    data = data.OrderByDescending(p => p.客戶資料.客戶名稱);
                    break;
                default:
                    data = data.OrderBy(p => p.職稱);
                    break;
            }

            return data;
        }
    }

    public interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
    {

    }
}