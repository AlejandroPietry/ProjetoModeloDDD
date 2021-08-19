﻿using System.Collections.Generic;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAppServiceBase<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}
