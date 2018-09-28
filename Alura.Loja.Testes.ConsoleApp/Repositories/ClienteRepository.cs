using Alura.Loja.Testes.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>
    {
        public Cliente FindByExactNome(string nome)
        {
            return context.Clientes.Where(c => c.Nome == nome).FirstOrDefault();
        }

        public IList<Cliente> ListByPartialNome(string nome)
        {
            return context.Clientes.Where(c => EF.Functions.Like(c.Nome, $"%{nome}%")).ToList();
        }
    }
}
