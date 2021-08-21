using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositorios;
using ProjetoModeloDDD.Domain.Interfaces.Servicos;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IEnumerable<Pedido> GetPedidosFromIndex()
        {
            return _pedidoRepository.GetPedidosFromIndex(); ;
        }
    }
}
