namespace Contracts.Requests
{

    public class AuthenticateLogin
    {
        public string Email { get; set; }
        public string Password { get; set; } 
    }

    public class EntityLastUpdateRequest
    {
        public string EntityName { get; set; }
        public string LastUpdatedTime { get; set; }
    }

    public class RefreshtokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

}
