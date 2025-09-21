using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserClickerUpgrade
    {
        public int UserId { get; set; }
        public int UpgradeId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PurchasedLast { get; set; }

        public virtual UserUpgrade Upgrade { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
