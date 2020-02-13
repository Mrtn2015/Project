using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.Entities
{
    public class User: IdentityUser<int>
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string IPAddress { get; set; }
        public string Address { get; set; }
        [Required]
        public string Linkedin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ContactNo { get; set; }
        [ForeignKey("Tag")]
        public int? TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
