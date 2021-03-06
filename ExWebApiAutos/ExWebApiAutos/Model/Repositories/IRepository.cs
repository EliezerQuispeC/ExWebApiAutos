﻿using System;
using System.Linq;

namespace ExWebApiAutos.Model.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }
        void Save(TEntity item);
        void Delete(Guid itemId);
    }
}
