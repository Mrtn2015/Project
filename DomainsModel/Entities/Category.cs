using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName="varchar(50)")]
        [Required(ErrorMessage = "Please Enter Name")]

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
