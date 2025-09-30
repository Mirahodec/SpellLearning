namespace BackendApi.Contracts.UserClickerUpgrade
{
    public class GetUserClickerUpgradeResponse
    {
        public int UserId { get; set; }
        public int UpgradeId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PurchasedLast { get; set; }

    }
}
