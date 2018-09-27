using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastrarCompraComProdutoNovo();
            ListarCompras();
            Pause();
        }

        private static void CadastrarCompra()
        {
            using (var compraRepository = new CompraRepository())
            using (var produtoRepository = new ProdutoRepository())
            {
                Produto produto = produtoRepository.ListAll().First();
                compraRepository.Save(new Compra { Produto = produto, Quantidade = 10 });
                Console.WriteLine("Compra cadastrada com sucesso");
            };
        }

        private static void CadastrarCompraComProdutoNovo()
        {
            using (var compraRepository = new CompraRepository())
            using (var produtoRepository = new ProdutoRepository())
            {
                var produto = new Produto { Nome = "iPhone XS", PrecoUnitario = 9000, Categoria = "Celulares", Unidade = "Unidade" };
                compraRepository.Save(new Compra { Produto = produto, Quantidade = 10 });
                Console.WriteLine("Compra cadastrada com sucesso");
            };
        }

        private static void ListarCompras()
        {
            using (var compraRepository = new CompraRepository())
            {
                var compras = compraRepository.ListAll();
                foreach (var compra in compras)
                {
                    Console.WriteLine(compra);
                };
            }
        }

        private static void ExcluirProdutos()
        {
            using (var context = new LojaContext())
            {
                IList<Produto> produtos = context.Produtos.ToList();
                foreach (var produto in produtos)
                {
                    context.Produtos.Remove(produto);
                    context.SaveChanges();
                }
            }
        }

        private static void ListarProdutos()
        {
            using(var context = new LojaContext())
            {
                IList<Produto> produtos = context.Produtos.ToList();
                foreach(var produto in produtos)
                {
                    Console.WriteLine(produto);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            var produto = new Produto
            {
                Nome = "Casino Royale",
                Categoria = "Filmes",
                PrecoUnitario = 15.99
            };

            using(var context = new LojaContext())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }

        private static void Pause()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
