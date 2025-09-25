namespace BackendApi.Contracts.Trace
{
    public class GetTraceResponse
    {
        public int TradeId { get; set; }
        public int UserIdOffer { get; set; }
        public int UserIdReceive { get; set; }
        public int InventoryIdOffer { get; set; }
        public int InventoryIdWant { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
