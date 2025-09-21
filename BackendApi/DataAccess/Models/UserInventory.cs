using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserInventory
    {
        public UserInventory()
        {
            DeckSlots = new HashSet<DeckSlot>();
            TraceInventoryIdOfferNavigations = new HashSet<Trace>();
            TraceInventoryIdWantNavigations = new HashSet<Trace>();
        }

        public int InventoryId { get; set; }
        public int UserId { get; set; }
        public int SpellId { get; set; }
        public DateTime? ObtainedAt { get; set; }

        public virtual Spell Spell { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<DeckSlot> DeckSlots { get; set; }
        public virtual ICollection<Trace> TraceInventoryIdOfferNavigations { get; set; }
        public virtual ICollection<Trace> TraceInventoryIdWantNavigations { get; set; }
    }
}
