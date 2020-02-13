using DomainsModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainsModel.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        public string Linkedin { get; set; }
        public string[] Roles { get; set; }
        public int TagId { get; set; }
    }
}
