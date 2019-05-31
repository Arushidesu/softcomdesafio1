using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParse.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "Esse não é um e-mail válido!")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Esse não é um telefone válido!")]
        public string Fone { get; set; }
        public List<Conta> Contas { get; set; }
    }
}
