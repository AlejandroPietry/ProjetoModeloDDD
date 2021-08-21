using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Servicos;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class PedidoAppService : AppServiceBase<Pedido>, IPedidoAppService
    {
        private readonly IPedidoService _pedidoService;

        public PedidoAppService(IPedidoService pedidoService) : base(pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public IEnumerable<Pedido> GetPedidosFromIndex()
        {
            return _pedidoService.GetPedidosFromIndex();
        }
    }
}
