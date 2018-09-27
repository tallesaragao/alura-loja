using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class CompraRepository : IDisposable
    {
        private LojaContext context;

        public CompraRepository()
        {
            context = LojaContextFactory.create();
        }

        public void Save(Compra compra)
        {
            context.Compras.Add(compra);
            context.SaveChanges();
        }

        public Compra FindById(int id)
        {
            return context.Compras.Where(c => c.Id == id).FirstOrDefault();
        }

        public IList<Compra> ListByProduto(Produto produto)
        {
            return ListByProduto(produto.Id);
        }

        public IList<Compra> ListByProduto(int produtoId)
        {
            return context.Compras.Where(c => c.ProdutoId == produtoId).ToList();
        }

        public IList<Compra> ListAll()
        {
            return context.Compras.ToList();
        }

        public void Update(Compra compra)
        {
            context.Compras.Update(compra);
            context.SaveChanges();
        }

        public void Remove(Compra produto)
        {
            context.Compras.Remove(produto);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
