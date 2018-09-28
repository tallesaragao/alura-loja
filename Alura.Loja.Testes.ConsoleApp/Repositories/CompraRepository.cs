using Alura.Loja.Testes.ConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp.Repositories
{
    public class CompraRepository : GenericRepository<Compra>
    {
        public Compra FindById(int id)
        {
            return context.Compras.Where(c => c.Id == id).FirstOrDefault();
        }

        public IList<Compra> ListByProduto(Promocao produto)
        {
            return ListByProduto(produto.Id);
        }

        public IList<Compra> ListByProduto(int produtoId)
        {
            return context.Compras.Where(c => c.ProdutoId == produtoId).ToList();
        }
    }
}
