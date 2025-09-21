using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            GachaPulls = new HashSet<GachaPull>();
            GameSaves = new HashSet<GameSafe>();
            TraceUserIdOfferNavigations = new HashSet<Trace>();
            TraceUserIdReceiveNavigations = new HashSet<Trace>();
            UserClickerUpgrades = new HashSet<UserClickerUpgrade>();
            UserDecks = new HashSet<UserDeck>();
            UserInventories = new HashSet<UserInventory>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? CurrencyClick { get; set; }
        public int? CurrencyGame { get; set; }

        public virtual ICollection<GachaPull> GachaPulls { get; set; }
        public virtual ICollection<GameSafe> GameSaves { get; set; }
        public virtual ICollection<Trace> TraceUserIdOfferNavigations { get; set; }
        public virtual ICollection<Trace> TraceUserIdReceiveNavigations { get; set; }
        public virtual ICollection<UserClickerUpgrade> UserClickerUpgrades { get; set; }
        public virtual ICollection<UserDeck> UserDecks { get; set; }
        public virtual ICollection<UserInventory> UserInventories { get; set; }
    }
}
