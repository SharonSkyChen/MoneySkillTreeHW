using System;
using System.Linq;
using System.Reflection;

namespace MoneySkillTreeHW.Helper
{
    public static class EnumHelper
    {
        /// <summary>
        /// Enum擴充：取得Enum的Description
        /// </summary>
        /// <param name="pEnum"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum pEnum)
        {
            return pEnum.GetType()
                .GetRuntimeField(pEnum.ToString())
                .GetCustomAttributes<System.ComponentModel.DescriptionAttribute>()
                .FirstOrDefault()?.Description ?? string.Empty;
        }
    }
}