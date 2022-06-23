using System;
using System.Collections.Generic;

namespace Contracts.Responses
{
    public class LoginSuccessResponse
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class LoginFailureResponse
    {
        public IEnumerable<string> errors { get; set; }
    }

    public class GetLoginUsers
    {
        public List<string> UserNames { get; set; }
    }

    public class DataEntityLastUpdatedResponse
    {
        public bool IsUpdated { get; set; } = false;
        public DateTime LastUpdatedTime { get; set; }
    }
}
