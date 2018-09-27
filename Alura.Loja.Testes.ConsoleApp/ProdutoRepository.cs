using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoRepository : IDisposable
    {
        private LojaContext context;

        public ProdutoRepository()
        {
            context = LojaContextFactory.create();
        }

        public void Save(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public Produto FindById(int id)
        {
            return context.Produtos.Where(p => p.Id == id).FirstOrDefault();
        }

        public IList<Produto> ListByNome(string nome)
        {
            return context.Produtos.Where(p => EF.Functions.Like(p.Nome, $"%{nome}%")).ToList();
        }

        public IList<Produto> ListAll()
        {
            return context.Produtos.ToList();
        }

        public void Update(Produto produto)
        {
            context.Produtos.Update(produto);
            context.SaveChanges();
        }

        public void Remove(Produto produto)
        {
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
