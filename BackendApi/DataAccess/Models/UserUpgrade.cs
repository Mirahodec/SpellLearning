using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserUpgrade
    {
        public UserUpgrade()
        {
            UserClickerUpgrades = new HashSet<UserClickerUpgrade>();
        }

        public int UpgradeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? CostClick { get; set; }
        public decimal? PowerMultiplier { get; set; }

        public virtual ICollection<UserClickerUpgrade> UserClickerUpgrades { get; set; }
    }
}
