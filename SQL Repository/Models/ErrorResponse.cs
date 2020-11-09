using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Repository.Models
{
    public class ErrorResponse
    {
        public string RequestId { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}
