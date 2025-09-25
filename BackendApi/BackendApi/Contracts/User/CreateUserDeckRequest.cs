namespace BackendApi.Contracts.UserDeck
{
    public class CreateUserDeckRequest
    {
        public int DeckId { get; set; }
        public int UserId { get; set; }
        public string DeckName { get; set; } = null!;
    }
}
