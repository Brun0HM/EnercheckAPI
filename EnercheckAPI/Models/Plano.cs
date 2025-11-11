using System.ComponentModel.DataAnnotations;

namespace EnercheckAPI.Models
{
    public class Plano
    {
        public Guid PlanoId { get; set; }
        public string PlanoNome { get; set; }
        public decimal? Valor { get; set; }
        public bool? Ativo { get; set; }
        public int? QuantidadeUsers { get; set; }
    }
}
