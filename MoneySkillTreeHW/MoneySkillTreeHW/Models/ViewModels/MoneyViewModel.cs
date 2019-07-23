using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MoneySkillTreeHW.Models.ViewModels
{
    public class MoneyViewModel
    {
        /// <summary>
        /// 種類
        /// </summary>
        [DisplayName("類別")]
        [Required]
        public string Category { get; set; }
        /// <summary>
        /// 支出、收入日期
        /// </summary>
        [DisplayName("日期")]
        [Required]
        [DataType(DataType.Date)]
        [Remote("TodayValid", "Valid", ErrorMessage = "請輸入小於今日之日期。")]
        public DateTime? MoneyDate { get; set; }
        /// <summary>
        /// 支出、收入金額
        /// </summary>
        [DisplayName("金額")]
        [Required]
        [Range(1,Int32.MaxValue,ErrorMessage ="請輸入正整數之金額。")]
        public int Amt { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [DisplayName("備註")]
        [Required]
        [StringLength(100,ErrorMessage ="不可超過100字。")]
        public string Remark { get; set; }

        /// <summary>
        /// 類別的下拉選單
        /// </summary>
        public List<SelectListItem> CateList { get; set; }
    }

    public enum CategoryState
    {
        [Description("收入")]
        Income = 0,
        [Description("支出")]
        Expenditure = 1
    }
}