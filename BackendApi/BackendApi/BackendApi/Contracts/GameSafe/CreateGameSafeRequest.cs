namespace BackendApi.Contracts.GameSafe
{
    public class CreateGameSafeRequest
    {
        public int SaveId { get; set; }
        public int UserId { get; set; }
        public int? Level { get; set; }
        public int? HighScore { get; set; }
        public int? EquippedDeckId { get; set; }
        public string? SaveData { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}