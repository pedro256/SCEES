using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCEES.Domain.Models
{
    public class Sale
    {
        [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Required]
        [ForeignKey("idProduct")]
        public Guid idProduct { get; set; }
        
        public Product product { get; set; }
        [Required]
        public int qtd { get; set; }
        public string nameClient { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public Sale()
        {
            createdAt = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
        }
    }
}
