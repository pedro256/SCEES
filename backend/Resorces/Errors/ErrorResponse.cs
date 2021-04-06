using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Resorces.Errors
{
    public class ErrorResponse
    {
        public bool Status { get; set; }
        public dynamic Error { get; set; }
    }
}
