using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "you must fill name")]
        [MaxLength(10, ErrorMessage = "Max Characters are 10")]
        [MinLength(3, ErrorMessage = "Min Characters are 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "you must fill price")]
        [Range(1, 999999999999.99, ErrorMessage = "Invaild Price")]
        public double Price { get; set; }

        [ForeignKey("ProductCategories")]
        public int ProductCategoriesId { get; set; }

        public ProductCategories ProductCategories { get; set; }
    }
}