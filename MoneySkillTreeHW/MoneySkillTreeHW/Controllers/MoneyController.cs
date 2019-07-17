using MoneySkillTreeHW.Models;
using MoneySkillTreeHW.Models.ViewModels;
using MoneySkillTreeHW.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneySkillTreeHW.Controllers
{
    public class MoneyController : Controller
    {
        private readonly MoneyService _mSvc;

        public MoneyController()
        {
            _mSvc = new MoneyService();
        }

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
            //改由service層取資料
            var accBookList = _mSvc.GetAccountList(100);
            
            return View(accBookList);
        }

       
    }
}