using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "you must fill user name")]
        [MaxLength(10, ErrorMessage = "Max Characters are 10")]
        [MinLength(3, ErrorMessage = "Min Characters are 3")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "you must fill password")]
        [MinLength(6, ErrorMessage = "Min Length is 6 Characters")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "you must fill email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail is not Vaild")]
        public string UserEmail { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}