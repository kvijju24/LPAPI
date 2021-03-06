﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LaunchPad.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);        //void RemoveRange(IEnumerable<T> entities);        //void AddRange(IEnumerable<T> entities);
    }
}
