using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "9999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Disponivel ?")]
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}
