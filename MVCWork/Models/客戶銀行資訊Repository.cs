using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.刪除 == false).AsQueryable();
        }

        public 客戶銀行資訊 Find(int Id)
        {
            return this.All().Where(p => p.Id == Id).FirstOrDefault();
        }

        public IQueryable<客戶銀行資訊> Query(string keyword)
        {
            var data = this.All();

            if (!String.IsNullOrWhiteSpace(keyword))
            {
                data = data.Where(p => p.銀行名稱.Contains(keyword));
            }

            return data;
        }
    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}