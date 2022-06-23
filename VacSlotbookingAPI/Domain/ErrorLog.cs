using System;

namespace Domain
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Instance { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
