using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kibexinhos.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int ProdutoId { get; set; }
        
        public Produto? Produto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public float Quantidade { get; set; }


        
    }
}