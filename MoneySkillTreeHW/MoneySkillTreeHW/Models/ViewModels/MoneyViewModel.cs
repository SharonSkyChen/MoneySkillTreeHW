using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneySkillTreeHW.Models.ViewModels
{
    public class MoneyViewModel
    {
        /// <summary>
        /// 種類
        /// </summary>
        [DisplayName("類別")]
        public string Type { get; set; }
        /// <summary>
        /// 支出、收入日期
        /// </summary>
        [DisplayName("日期")]
        public DateTime MoneyDate { get; set; }
        /// <summary>
        /// 支出、收入金額
        /// </summary>
        [DisplayName("金額")]
        public double Amt { get; set; }
    }
}