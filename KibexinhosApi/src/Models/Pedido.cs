using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kibexinhos.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime CriadoEm { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Frete { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int TipoPagamentoId { get; set; }

        public TipoPagamento? Pagamento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int CupomId { get; set; }

        public Cupom? Cupom { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, 100)]
        public int Desconto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(8, ErrorMessage = "Este campo deve conter 8 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter 8 caracteres")]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(2, ErrorMessage = "Este campo deve conter 2 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve conter 2 caracteres")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo deve conter no maximo 45 caracteres")]
        [MinLength(10, ErrorMessage = "Este campo deve conter no minimo 10 caracteres")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo deve conter no maximo 45 caracteres")]
        [MinLength(10, ErrorMessage = "Este campo deve conter no minimo 10 caracteres")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string? Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double Total { get; set; }

        public virtual ICollection<PedidoItem>? PedidoItem { get; set; }

    }
}