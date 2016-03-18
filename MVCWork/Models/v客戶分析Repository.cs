using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCWork.Models
{   
	public  class v客戶分析Repository : EFRepository<v客戶分析>, Iv客戶分析Repository
	{
        public IQueryable<v客戶分析> Query(string keyword)
        {
            var data = this.All();

            if (!String.IsNullOrWhiteSpace(keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(keyword));
            }

            return data;
        }
    }

    public  interface Iv客戶分析Repository : IRepository<v客戶分析>
	{

	}
}