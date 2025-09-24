namespace BackendApi.Contracts.User
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? CurrencyClick { get; set; }
        public int? CurrencyGame { get; set; }
    }
}
