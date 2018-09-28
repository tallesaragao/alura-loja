using Alura.Loja.Testes.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp.Repositories
{
    public class PromocaoRepository : GenericRepository<Promocao>
    {
        public Promocao FindById(int id)
        {
            return context.Promocoes.Where(p => p.Id == id).FirstOrDefault();
        }

        public void RemoverProduto(int produtoId)
        {

        }
    }
}
