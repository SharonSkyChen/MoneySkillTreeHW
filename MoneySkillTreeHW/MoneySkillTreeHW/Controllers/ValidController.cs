using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySkillTreeHW.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        /// <summary>
        /// 日期檢核
        /// </summary>
        /// <param name="MoneyDate"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult TodayValid(DateTime? MoneyDate)
        {
            bool isValidate = false;
            if (MoneyDate != null)
            {
                DateTime today = DateTime.Today;
                DateTime inputDay = MoneyDate.GetValueOrDefault();
                if (DateTime.Compare(inputDay, today) <= 0)
                    isValidate = true;
            }
               
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}