using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParse.Models
{
    public class Conta
    {
        public string titulo { get; set; }
        public string resumo { get; set; }
        public double valor { get; set; }
        public DateTime vencimento { get; set; }
    }
}
