using System.Collections.Generic;

namespace Domain
{
    public class AuthResult
    {
        public bool status { get; set; }
        public Login _user { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
}
