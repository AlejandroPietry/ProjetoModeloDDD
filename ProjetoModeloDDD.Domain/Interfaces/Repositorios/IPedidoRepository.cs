using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositorios
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        IEnumerable<Pedido> GetPedidosFromIndex();
    }
}
