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
        /// <param name="pDate"></param>
        /// <returns></returns>
        public ActionResult TodayValid(DateTime? pDate)
        {
            bool isValidate = true;
            if (pDate == null)
                isValidate = false;
            else
            {
                DateTime today = DateTime.Today;
                DateTime inputDay = pDate.GetValueOrDefault();
                if (DateTime.Compare(inputDay, today) > 0)
                    isValidate = false;
            }

            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}