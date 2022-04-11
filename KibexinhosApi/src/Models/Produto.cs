using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TipoProduto? TipoProduto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int PetId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Pet? Pet { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue)]
        public int MarcaProdutoId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MarcaProduto? MarcaProduto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool Ativo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double MediaAvaliacao { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<AvaliacaoProduto>? AvaliacaoProduto { get; set;}

        public virtual ICollection<Carrinho>? Carrinho { get; set; }

        public virtual ICollection<ImagemProduto>? ImageProduto { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<PedidoItem>? PedidoItem { get; set; }

        
    }
}