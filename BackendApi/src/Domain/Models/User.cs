using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Domain.Models
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

        public bool AcceptTerms { get; set; }
        public Role Role { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated{ get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public virtual ICollection<GachaPull> GachaPulls { get; set; }
        public virtual ICollection<GameSafe> GameSaves { get; set; }
        public virtual ICollection<Trace> TraceUserIdOfferNavigations { get; set; }
        public virtual ICollection<Trace> TraceUserIdReceiveNavigations { get; set; }
        public virtual ICollection<UserClickerUpgrade> UserClickerUpgrades { get; set; }
        public virtual ICollection<UserDeck> UserDecks { get; set; }
        public virtual ICollection<UserInventory> UserInventories { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x=> x.Token == token) != null;
        }    
    }
}