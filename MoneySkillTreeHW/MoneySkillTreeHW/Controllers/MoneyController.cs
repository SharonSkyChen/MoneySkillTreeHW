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
            List<SelectListItem> sList = _mSvc.EnumToSelectList<CategoryState>();

            return View();
        }

        [HttpPost]
        public ActionResult MyAccount(MoneyViewModel pAccData)
        {
            //存檔
            _mSvc.SaveAccount(pAccData);
            _mSvc.Save();

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