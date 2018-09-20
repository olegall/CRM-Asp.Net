﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        //TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        //IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}