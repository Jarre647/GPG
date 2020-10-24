using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQL_Repository.Models
{
    public class Abuser
    {
        public int Id { get; set; }
        public string AbuserName { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; } 
    }
}
