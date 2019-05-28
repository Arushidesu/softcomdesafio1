using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParse.Models
{
    public class Usuario
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string fone { get; set; }
        public List<Conta> contas { get; set; }
    }
}
