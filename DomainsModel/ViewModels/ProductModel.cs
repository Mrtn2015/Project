using DomainsModel.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainsModel.ViewModels
{
    [NotMapped]
    public class ProductModel:Product
    {
        public IFormFile File { get; set; }
    }
}
