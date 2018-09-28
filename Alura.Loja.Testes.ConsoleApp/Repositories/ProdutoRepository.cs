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
            var produto = context.Produtos.Include(p => p.Compras).Where(p => p.Id == produtoId).FirstOrDefault();
            context.Entry(produto)
                .Collection(p => p.Compras)
                .Query()
                .Where(compra => compra.Total > totalMinimo)
                .Load();
            return produto;
        }

        public IList<Produto> ListByNome(string nome)
        {
            return context.Produtos.Where(p => EF.Functions.Like(p.Nome, $"%{nome}%")).ToList();
        }
    }
}
