using Alura.Loja.Testes.ConsoleApp.DbContexts;
using Alura.Loja.Testes.ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp.Repositories
{
    public abstract class GenericRepository<T> : IDisposable where T : class
    {
        protected LojaContext context = LojaContextFactory.Create();
        private bool disposed = false;

        public IList<T> ListAll()
        {
            return context.Set<T>().ToList();
        }

        public void Save(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            disposed = true;
        }

        public bool IsDisposed()
        {
            return disposed;
        }
    }
}
