using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace EnercheckAPI.Models
{
    public class Projeto
    {
        public Guid ProjetoId { get; set; }
        public Guid UsuarioId { get; set; }
        public IdentityUser? Usuario { get; set; }
        [Required]
        [Display(Name = "Nomde do Projetos")]
        public string? Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int Progresso { get; set; }
        [Display(Name = "Descrição do projeto")]
        [DataType(DataType.MultilineText)]
        public string? Descricao { get; set; }
        public JsonArray? Analise { get; set; }
    }
}
