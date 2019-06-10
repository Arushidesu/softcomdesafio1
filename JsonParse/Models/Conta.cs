using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParse.Models
{
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        public string Resumo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Valor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Vencimento { get; set; }

        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
