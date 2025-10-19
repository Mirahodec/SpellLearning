namespace Domain.Models
{
    public partial class GachaPull
    {
        public int PullId { get; set; }
        public int SpellId { get; set; }
        public int UserId { get; set; }
        public DateTime? PullDate { get; set; }

        public virtual Spell Spell { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}