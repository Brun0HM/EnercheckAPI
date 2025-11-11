using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace EnercheckAPI.Models
{
    public class Projeto
    {
        public Guid ProjetoId { get; set; }

        public string UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }


        public DateTime? DataCriacao { get; set; }

        [Required]
        [Display(Name = "Nomde do Projetos")]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Range(0, 100)]
        public int Progresso { get; set; }

        [Display(Name = "Descrição do projeto")]
        [DataType(DataType.MultilineText)]
        [StringLength(600)]
        public string? Descricao { get; set; }
        public string Analise { get; set; }
    }
}
