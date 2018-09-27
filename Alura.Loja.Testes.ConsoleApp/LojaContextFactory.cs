using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContextFactory
    {
        private static LojaContext lojaContext;
        public static LojaContext create()
        {
            if (lojaContext == null || lojaContext.IsDisposed())
                lojaContext = new LojaContext();      
            return lojaContext;
        }
    }
}
