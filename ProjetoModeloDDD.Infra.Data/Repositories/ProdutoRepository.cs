using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositorios;
using ProjetoModeloDDD.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProjetoModeloContext context) : base(context)
        {

        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _context.Produtos.Where(p => p.Nome.Contains(nome));
        }
    }
}
