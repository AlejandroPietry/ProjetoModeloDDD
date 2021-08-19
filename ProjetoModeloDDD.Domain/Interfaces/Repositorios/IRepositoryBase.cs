using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositorios
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllAsNoTracking();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();
    }
}
