using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kibexinhos.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int PedidoId { get; set; }

        public Pedido? Pedido { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double PrecoUnit { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Quantidade { get; set; }


        
    }
}