using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoneySkillTreeHW.Helper
{
    public static class CusHtmlHelper
    {
        public static string SetColor(this HtmlHelper helper, string pCategory)
        {
            return pCategory == "1" ? "red" : "blue";
        }

        public static string ShowCateDesc(this HtmlHelper helper, string pCategory)
        {
            return pCategory == "1" ? "支出" : "收入";
        }
    }
}