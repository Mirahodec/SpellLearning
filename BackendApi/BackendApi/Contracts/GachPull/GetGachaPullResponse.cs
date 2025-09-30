namespace BackendApi.Contracts.GachPull
{
    public class GetGachaPullResponse
    {
        public int PullId { get; set; }
        public int SpellId { get; set; }
        public int UserId { get; set; }
        public DateTime? PullDate { get; set; }

    }
}
