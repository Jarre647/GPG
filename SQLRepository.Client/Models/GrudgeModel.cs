using System;
using System.ComponentModel.DataAnnotations;

namespace SQLRepository.Client.Models
{
    public class GrudgeModel
    {
        [Key]
        public int Id { get; set; }
        public string AbuserName { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; } 
    }
}
