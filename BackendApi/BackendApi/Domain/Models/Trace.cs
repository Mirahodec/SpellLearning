using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Trace
    {
        public int TradeId { get; set; }
        public int UserIdOffer { get; set; }
        public int UserIdReceive { get; set; }
        public int InventoryIdOffer { get; set; }
        public int InventoryIdWant { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public virtual UserInventory InventoryIdOfferNavigation { get; set; } = null!;
        public virtual UserInventory InventoryIdWantNavigation { get; set; } = null!;
        public virtual User UserIdOfferNavigation { get; set; } = null!;
        public virtual User UserIdReceiveNavigation { get; set; } = null!;
    }
}