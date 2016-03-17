using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.刪除 == false).AsQueryable();
        }

        public 客戶聯絡人 Find(int Id)
        {
            return this.All().Where(p => p.Id == Id).FirstOrDefault();
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}