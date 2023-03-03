namespace Entities.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        //***
        public string RoleName { get; set; }
        public string Password { get; set; }
    }
}
