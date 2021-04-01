using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Models
{
    public class Expenditure
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Required]
        public string name { get; set; }
        [Required,MinLength(1)]
        public decimal price { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        [Required]
        public DateTime payDay { get; set; }
        public Expenditure()
        {
            createdAt = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
        }
    }
}
