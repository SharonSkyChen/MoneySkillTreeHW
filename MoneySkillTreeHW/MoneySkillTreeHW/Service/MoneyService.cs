using MoneySkillTreeHW.Models;
using MoneySkillTreeHW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneySkillTreeHW.Service
{
    public class MoneyService
    {
        private readonly AccountBookContext _accBookDB;

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

        public void Save()
        {
            _accBookDB.SaveChanges();
        }

    }
}