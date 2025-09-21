using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class GameSafe
    {
        public int SaveId { get; set; }
        public int UserId { get; set; }
        public int? Level { get; set; }
        public int? HighScore { get; set; }
        public int? EquippedDeckId { get; set; }
        public string? SaveData { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual UserDeck? EquippedDeck { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
