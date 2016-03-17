using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCWork.Models
{   
	public  class v客戶分析Repository : EFRepository<v客戶分析>, Iv客戶分析Repository
	{

	}

	public  interface Iv客戶分析Repository : IRepository<v客戶分析>
	{

	}
}