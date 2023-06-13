namespace ManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required string Token { get; set; }

        public required string Role { get; set; }

        public required string Email { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
