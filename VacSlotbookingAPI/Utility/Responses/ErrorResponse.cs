using System.Collections.Generic;

namespace Contracts.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
