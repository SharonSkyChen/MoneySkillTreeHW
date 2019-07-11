using MoneySkillTreeHW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySkillTreeHW.Controllers
{
    public class MoneyController : Controller
    {
        // GET: Money
        public ActionResult MyAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyAccount(MoneyViewModel pAccData)
        {
            return View(pAccData);
        }

        /// <summary>
        /// 下方資料列Action
        /// </summary>
        /// <returns></returns>
        public ActionResult MyAccountDetail()
        {
            List<MoneyViewModel> moneyList = new List<MoneyViewModel>();

            #region 取得假資料
            DateTime firstDate = new DateTime(2019, 1, 1);
            MoneyViewModel tmpMoney;
            Random radm = new Random();
            for (int i = 0; i < 100; i++)
            {
                tmpMoney = new MoneyViewModel()
                {
                    Type = radm.Next(1, 1000) % 2 == 1 ? "支出" : "收入",
                    MoneyDate = firstDate.AddDays(i),
                    Amt = radm.Next(1, 50000)
                };
                moneyList.Add(tmpMoney);
            }
            #endregion

            return View(moneyList);
        }

    }
}