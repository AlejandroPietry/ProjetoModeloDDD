using ProjetoModeloDDD.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositorios
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
