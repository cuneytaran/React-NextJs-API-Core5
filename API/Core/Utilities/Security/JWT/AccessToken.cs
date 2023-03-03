using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
