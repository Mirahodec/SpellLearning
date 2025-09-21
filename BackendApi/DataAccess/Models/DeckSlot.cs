using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class DeckSlot
    {
        public int SlotId { get; set; }
        public int DeckId { get; set; }
        public int InventoryId { get; set; }
        public int SlotNumber { get; set; }

        public virtual UserDeck Deck { get; set; } = null!;
        public virtual UserInventory Inventory { get; set; } = null!;
    }
}
