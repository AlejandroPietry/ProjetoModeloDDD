using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        [Display(Name = "Sobrenome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um email válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }

    }
}
