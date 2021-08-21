using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositorios;
using ProjetoModeloDDD.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ProjetoModeloContext projetoModeloContext) : base(projetoModeloContext)
        {
        }

        public IEnumerable<Pedido> GetPedidosFromIndex()
        {
            return _context.Pedidos.Include(x => x.Cliente);
        }
    }
}
