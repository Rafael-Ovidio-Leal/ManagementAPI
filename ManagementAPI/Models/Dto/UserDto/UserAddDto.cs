namespace ManagementAPI.Models.Dto.UserDto
{
    public class UserAddDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required string Token { get; set; }

        public required string Role { get; set; }

        public required string Email { get; set; }
    }
}
