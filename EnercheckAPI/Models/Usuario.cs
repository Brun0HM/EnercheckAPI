using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EnercheckAPI.Models
{
    public class Usuario : IdentityUser
    {

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Insira um número de telefone válido.")]
        public string Telefone { get; set; }

        public string NomeCompleto { get; set; }

        public Guid PlanoId { get; set; }

        public Plano? Plano { get; set; }

        public ICollection<Projeto>? Projeto { get; set; }
    }
}
