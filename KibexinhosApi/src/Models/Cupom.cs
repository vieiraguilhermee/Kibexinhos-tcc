using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kibexinhos.Models
{
    public class Cupom
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo deve ter no máximo 10 caracteres")]
        [MaxLength(10, ErrorMessage = "Este campo deve ter no máximo 10 caracteres")]
        [Column("Cupom")]
        public string? Cupoom { get; set; }

        [Required(ErrorMessage = "Este campo deve ter no máximo 10 caracteres")]
        [Range(0, 100)]
        public int PorcDesconto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime CriadoEm { get; set; }

        [Required(ErrorMessage = "Este campo deve ter no máximo 10 caracteres")]
        public bool Ativo { get; set; }

        public virtual ICollection<Pedido>? Pedido { get; set; }
    }
}