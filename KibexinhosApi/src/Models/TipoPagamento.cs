using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kibexinhos.Models
{
    public class TipoPagamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string? Tipo { get; set;}

        public virtual ICollection<Pedido>? Pedido { get; set; }


        
    }
}