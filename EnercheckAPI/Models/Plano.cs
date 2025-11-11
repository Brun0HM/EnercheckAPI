using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnercheckAPI.Models
{
    public class Plano
    {
        public Guid PlanoId { get; set; }

        [Required(ErrorMessage = "O nome do plano é obrigatório.")]
        public string PlanoNome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor válido.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Valor { get; set; }
        public int? QuantidadeUsers { get; set; }
        [Range(0, 200, ErrorMessage = "O máximo de requisições permitidas em um plano é 200.")]
        public int totalReq { get; set; }
    }
}
