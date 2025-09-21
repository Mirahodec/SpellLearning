using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Spell
    {
        public Spell()
        {
            GachaPulls = new HashSet<GachaPull>();
            UserInventories = new HashSet<UserInventory>();
        }

        public int SpellId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? CostCurrency { get; set; }
        public string? Rarity { get; set; }
        public int? CostAmount { get; set; }
        public string? ImageUrl { get; set; }
        public string? GameEffectCode { get; set; }
        public int? BaseDamage { get; set; }

        public virtual ICollection<GachaPull> GachaPulls { get; set; }
        public virtual ICollection<UserInventory> UserInventories { get; set; }
    }
}
