using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IPedidoAppService : IAppServiceBase<Pedido>
    {
        IEnumerable<Pedido> GetPedidosFromIndex();
    }
}
