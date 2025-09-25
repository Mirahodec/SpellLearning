namespace BackendApi.Contracts.UserInventory
{
    public class GetUserInventoryResponse
    {
        public int InventoryId { get; set; }
        public int UserId { get; set; }
        public int SpellId { get; set; }
        public DateTime? ObtainedAt { get; set; }
    }
}
