using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kibexinhos.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string? Apelido { get; set; }

        [Column("CPF/CNPJ")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(18, ErrorMessage = "Este campo deve conter entre 11 e 18 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve conter entre 11 e 18 caracteres")]
        public string? CPFCNPJ { get; set; }

        [Column("RG/IE")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter entre 12 e 15 caracteres")]
        [MinLength(12, ErrorMessage = "Este campo deve conter entre 12 e 15 caracteres")]
        public string? RGIE { get; set; }

        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 20 e 50 caracteres")]
        [MinLength(20, ErrorMessage = "Este campo deve conter entre 20 e 50 caracteres")]
        public string? NomeFantasia { get; set;}

        [MaxLength(70, ErrorMessage = "Este campo deve conter entre 20 e 70 caracteres")]
        [MinLength(20, ErrorMessage = "Este campo deve conter entre 20 e 70 caracteres")]
        public string? RazaoSocial { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter no máximo caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 8 e 50 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 50 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(9, ErrorMessage = "Este campo deve conter 9 caracteres")]
        [MinLength(9, ErrorMessage = "Este campo deve conter 9 caracteres")]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter 15 caracteres")]
        [MinLength(15, ErrorMessage = "Este campo deve conter 15 caracteres")]
        public string? Celular1 { get; set;}

        [MaxLength(15, ErrorMessage = "Este campo deve conter 15 caracteres")]
        [MinLength(15, ErrorMessage = "Este campo deve conter 15 caracteres")]
        public string? Celular2 { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool Newsletter { get; set; }

        public virtual ICollection<AvaliacaoProduto>? AvaliacaoProduto { get; set;}

        public virtual ICollection<Carrinho>? Carrinho { get; set;}

        public virtual ICollection<Pedido>? Pedido { get; set;}


        
    }
}