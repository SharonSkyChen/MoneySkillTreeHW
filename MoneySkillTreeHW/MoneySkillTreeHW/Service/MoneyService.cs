using MoneySkillTreeHW.Helper;
using MoneySkillTreeHW.Models;
using MoneySkillTreeHW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoneySkillTreeHW.Service
{
    public class MoneyService
    {
        private readonly AccountBookContext _accBookDB;

        /// <summary>
        /// 建構子
        /// </summary>
        public MoneyService()
        {
            _accBookDB = new AccountBookContext();
        }

        /// <summary>
        /// 取得AccountBooks之資料
        /// </summary>
        /// <param name="pAccNum"></param>
        /// <returns></returns>
        public IEnumerable<MoneyViewModel> GetAccountList(int pAccNum)
        {
            var accData = _accBookDB.AccountBooks.Take(pAccNum).OrderBy(x => x.Dateee).ToList();
            var accList = new List<MoneyViewModel>();

            foreach (var acc in accData)
            {
                accList.Add(new MoneyViewModel()
                {
                    Type = acc.Categoryyy == 1 ? "支出" : "收入",
                    Amt = acc.Amounttt,
                    MoneyDate = acc.Dateee
                });

            }
            return accList;
        }

        /// <summary>
        /// 儲存記帳本的資料
        /// </summary>
        /// <param name="pMoneyObj"></param>
        public void SaveAccount(MoneyViewModel pMoneyObj)
        {
            var customers = _accBookDB.Set<AccountBook>();
            customers.Add(new AccountBook()
            {
                Id = new Guid(),
                Categoryyy = pMoneyObj?.Type.Trim() == "1" ? 1 : 0,
                Amounttt = (int)pMoneyObj.Amt,
                Dateee = pMoneyObj.MoneyDate
            });
        }

        /// <summary>
        /// 取得類型下拉選單
        /// </summary>
        /// <typeparam name="CategoryState"></typeparam>
        /// <returns></returns>
        public List<SelectListItem> EnumToSelectList<T>()
        {
            var enumValues = new List<SelectListItem>();
            Array values = Enum.GetValues(typeof(T));
            
            //設定下拉選單Text與Value
            foreach (var item in values)
            {
                enumValues.Add(new SelectListItem
                {
                    Text = (item as Enum).ToDescription(),
                    //Text = Enum.GetName(typeof(CategoryState), i),
                    Value = ((int)item).ToString()
                });
            }

            return enumValues;
        }

        /// <summary>
        /// 存檔
        /// </summary>
        public void Save()
        {
            _accBookDB.SaveChanges();
        }

    }
}