using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebVue.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(70)]
        [Required]
        public string NickName { get; set; }
    }
}
