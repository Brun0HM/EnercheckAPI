using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EnercheckAPI.Models
{
    public class Usuario
    {

        public Guid UsuarioId { get; set; }
        [Required(ErrorMessage = "O endereço de email é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Insira um endereço de email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Insira um número de telefone válido.")]
        public string Telefone { get; set; }

        public IdentityUser? Usuarios { get; set; }

    }
}
