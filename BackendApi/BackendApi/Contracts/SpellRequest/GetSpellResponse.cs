namespace BackendApi.Contracts.SpellRequest
{
    public class GetSpellResponse
    {
        public int SpellId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? CostCurrency { get; set; }
        public string? Rarity { get; set; }
        public int? CostAmount { get; set; }
        public string? ImageUrl { get; set; }
        public string? GameEffectCode { get; set; }
        public int? BaseDamage { get; set; }
    }
}
