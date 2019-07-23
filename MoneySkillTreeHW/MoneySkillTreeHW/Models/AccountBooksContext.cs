using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneySkillTreeHW.Models
{
    public class AccountBookContext : DbContext
    {
        public AccountBookContext()
            : base("name=SkillTreeHomeworkEntities")
        {
        }
        public DbSet<AccountBook> AccountBooks { get; set; }
    }
}