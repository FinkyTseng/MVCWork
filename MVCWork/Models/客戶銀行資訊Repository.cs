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
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}