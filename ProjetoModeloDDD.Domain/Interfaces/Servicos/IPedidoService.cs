using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Servicos
{
    public interface IPedidoService : IServiceBase<Pedido>
    {
        IEnumerable<Pedido> GetPedidosFromIndex();
    }
}
