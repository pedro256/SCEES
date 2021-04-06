using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Models.Query
{
    public class ProductQuery
    {
        public string name { get; set; }
        public int qtd { get; set; }
        public decimal price { get; set; }
        public DateTime dateValid { get; set; }
    }
}
