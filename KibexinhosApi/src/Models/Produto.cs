using System.Collections.Generic;
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
        [MaxLength(200, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 200 caracteres")]
        public string? NomeProduto { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(1000, ErrorMessage = "Este campo deve conter entre 3 e 1000 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 1000 caracteres")]
        public string? Descricao { get; set; }

        [MaxLength(1000, ErrorMessage = "Este campo deve conter entre 10 e 1000 caracteres")]
        [MinLength(10, ErrorMessage = "Este campo deve conter entre 10 e 1000 caracteres")]
        public string? InformacaoNutricional { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, double.MaxValue)]
        public double Altura { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, double.MaxValue)]
        public double Largura { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, double.MaxValue)]
        public double Comprimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, double.MaxValue)]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Preco { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double PrecoDescontado { get; set; }

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
        public int? MediaAvaliacao { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<AvaliacaoProduto>? AvaliacaoProduto { get; set;}

        public virtual ICollection<Carrinho>? Carrinho { get; set; }

        public virtual ICollection<ImagemProduto>? ImageProduto { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<PedidoItem>? PedidoItem { get; set; }

        
    }
}