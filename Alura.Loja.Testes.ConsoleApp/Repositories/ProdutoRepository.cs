using Alura.Loja.Testes.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>
    {
        public Produto FindById(int produtoId)
        {
            return context.Produtos.Where(p => p.Id == produtoId).FirstOrDefault();
        }

        public Produto FindByIdAndComprasWithTotalMinimo(int produtoId, double totalMinimo)
        {
            var produto = context.Produtos.Where(p => p.Id == produtoId).FirstOrDefault();

            produto.Compras = context.Entry(produto)
                .Collection(p => p.Compras)
                .Query()
                .Where(c => c.Total > totalMinimo)
                .ToList();

            return produto;
        }

        public List<Produto> ListByCompraWithTotalMinimo(double valorMinimo)
        {
            var produtos = context.Produtos
                .Include(p => p.Compras)
                .ToList();

            foreach(var produto in produtos)
            {
                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Total > valorMinimo)
                    .Load();
            }
            return produtos;
            
        }

        public IList<Produto> ListByNome(string nome)
        {
            return context.Produtos.Where(p => EF.Functions.Like(p.Nome, $"%{nome}%")).ToList();
        }
    }
}
