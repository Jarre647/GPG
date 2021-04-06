using System.Collections.Generic;

namespace SQLRepository.Models
{
    public class ErrorResponse
    {
        public string RequestId { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}
