using Alura.Loja.Testes.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>
    {
        public Produto FindById(int id)
        {
            return context.Produtos.Where(p => p.Id == id).FirstOrDefault();
        }

        public IList<Produto> ListByNome(string nome)
        {
            return context.Produtos.Where(p => EF.Functions.Like(p.Nome, $"%{nome}%")).ToList();
        }
    }
}
