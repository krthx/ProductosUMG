﻿using System.Web;
using System.Web.Mvc;

namespace Tienda2013407
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
