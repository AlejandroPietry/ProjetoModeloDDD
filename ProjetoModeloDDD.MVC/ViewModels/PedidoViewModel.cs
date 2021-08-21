using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public string DetalhesPedido { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Cliente Cliente { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

    }
}
