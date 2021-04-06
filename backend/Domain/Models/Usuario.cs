using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Models
{
    public class Usuario
    {
        [Required,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        [Required]
        public string name { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
        [Required,MinLength(6)]
        public string password { get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public Usuario()
        {
            createdAt = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
        }

    }
}
