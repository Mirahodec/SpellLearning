namespace BackendApi.Contracts.UserDeck
{ 
    public class GetUserDeckResponse
    {
        public int DeckId { get; set; }
        public int UserId { get; set; }
        public string DeckName { get; set; } = null!;
    }
}
