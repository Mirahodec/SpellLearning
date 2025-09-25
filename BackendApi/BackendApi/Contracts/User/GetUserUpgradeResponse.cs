namespace BackendApi.Contracts.UserUpgrade
{
    public class GetUserUpgradeResponse
    {
        public int UpgradeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? CostClick { get; set; }
        public decimal? PowerMultiplier { get; set; }
    }
}
