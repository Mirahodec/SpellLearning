using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserDeck
    {
        public UserDeck()
        {
            DeckSlots = new HashSet<DeckSlot>();
            GameSaves = new HashSet<GameSafe>();
        }

        public int DeckId { get; set; }
        public int UserId { get; set; }
        public string DeckName { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<DeckSlot> DeckSlots { get; set; }
        public virtual ICollection<GameSafe> GameSaves { get; set; }
    }
}