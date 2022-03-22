using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kibexinhos.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string? NomeProduto { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Preco { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double PrecoDescontado { get; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Estoque { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Desconto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int TipoProdutoId { get; set; }

        public TipoProduto? TipoProduto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int PetId { get; set; }

        public Pet? Pet { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int MarcaProdutoId { get; set; }

        public MarcaProduto? MarcaProduto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool Ativo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double MediaAvaliacao { get; }

        public virtual ICollection<AvaliacaoProduto>? AvaliacaoProduto { get; set;}

        public virtual ICollection<Carrinho>? Carrinho { get; set; }

        public virtual ICollection<ImagemProduto>? ImageProduto { get; set; }

        public virtual ICollection<PedidoItem>? PedidoItem { get; set; }

        
    }
}