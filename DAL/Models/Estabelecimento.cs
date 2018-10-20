using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FITCARD.Models
{
    public class Estabelecimento
    {
        public int IDEstabelecimento { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Categoria { get; set; }

        [Required]
        public int Status { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
    }
}