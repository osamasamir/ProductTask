using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class ProductCategories
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "you must fill name")]
        [MaxLength(10, ErrorMessage = "Max Characters are 10")]
        [MinLength(3, ErrorMessage = "Min Characters are 3")]
        public string Name { get; set; }
    }
}