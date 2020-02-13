using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.ViewModels
{
    public class TagModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
