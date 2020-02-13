using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.Entities
{
    public class Tag
    {
        public Tag()
        {
            CreatedDate = DateTime.Now;
        }
        public int TagId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
