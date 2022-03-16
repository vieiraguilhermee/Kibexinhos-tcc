using System.ComponentModel.DataAnnotations;

namespace Kibexinhos.Models
{
    public class ImagemProduto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
        public string? Imagem { get; set; }
        
    }
}