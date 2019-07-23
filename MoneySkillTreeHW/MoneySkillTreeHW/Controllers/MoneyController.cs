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
        private List<SelectListItem> _CateList;
        public MoneyController()
        {
            _mSvc = new MoneyService();

            //預先取得類別的下拉選單
            _CateList = new List<SelectListItem>() {
                new SelectListItem(){
                    Text = "",
                    Value = ""
                }
            };
            _CateList.AddRange(_mSvc.EnumToSelectList<CategoryState>());
        }

        // GET: Money
        public ActionResult MyAccount()
        {
            ViewData["CateList"] = _CateList;

            return View();
        }

        [HttpPost]
        public ActionResult MyAccount(MoneyViewModel pAccData)
        {
            ViewData["CateList"] = _CateList;
            if (ModelState.IsValid)
            {
                //存檔
                _mSvc.SaveAccount(pAccData);
                _mSvc.Save();
                return View();
            }

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