namespace BackendApi.Contracts.GachaPull
{
    public class CreateGachaPullRequest
    {
        public int PullId { get; set; }
        public int SpellId { get; set; }
        public int UserId { get; set; }
        public DateTime? PullDate { get; set; }

    }
}
