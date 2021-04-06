using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Models
{
    public class Product
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Required]
        public string name { get; set; }
        public long qtd { get; set; }

        [ForeignKey("CategoryId")]
        [Required]
        public Guid categoryId { get; set; }
        public Category category { get; set; }
        [Required]
        public decimal price {get;set;}
        [Required]
        public decimal salePrice { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime dataValid { get; set; }
        public Product()
        {
            createdAt = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
        }
    }
}
