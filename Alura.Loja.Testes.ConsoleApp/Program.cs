using Alura.Loja.Testes.ConsoleApp.DbContexts;
using Alura.Loja.Testes.ConsoleApp.Models;
using Alura.Loja.Testes.ConsoleApp.Repositories;
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
            //AtualizarPromocao();
            //ListarPromocoes();
            //ListarProdutos();
            //AdicionarCliente();
            //ListarClientes();
            ListarComprasProdutoComTotalMinimo();
            Pause();
        }

        private static void ListarComprasProdutoComTotalMinimo()
        {
            using (var produtoRepository = new ProdutoRepository())
            {
                var produto = produtoRepository.FindByIdAndComprasWithTotalMinimo(1, 200);
                foreach (var compra in produto.Compras)
                {
                    Console.WriteLine(compra);
                }
            }
        }

        private static void ListarComprasProduto()
        {
            using (var produtoRepository = new ProdutoRepository())
            {
                var produto = produtoRepository.FindById(1002);
                foreach(var compra in produto.Compras)
                {
                    Console.WriteLine(compra);
                }
            }
        }

        private static void ListarClientes()
        {
            using (var clienteRepository = new ClienteRepository())
            {
                var clientes = clienteRepository.ListAll();
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente);
                }
            }
        }

        private static void AdicionarCliente()
        {
            var endereco = new Endereco
            {
                Cep = "08720400",
                Logradouro = "Rua Antônio Ruiz Veiga",
                Bairro = "Mogilar",
                Cidade = "Mogi das Cruzes",
                Numero = 100
            };
            var cliente = new Cliente
            {
                Endereco = endereco,
                Nome = "Leão do Proerd"
            };
            using (var clienteRepository = new ClienteRepository())
            {
                clienteRepository.Save(cliente);
            }
        }

        private static void AtualizarPromocao()
        {
            using (var promocaoRepository = new PromocaoRepository())
            using (var produtoRepository = new ProdutoRepository())
            {
                var produto = produtoRepository.ListByNome("Harry Potter e a Pedra Filosofal").First();
                var promocao = promocaoRepository.ListAll().First();
                promocao.AdicionarProdutos(produto);
                promocaoRepository.Update(promocao);
            }
        }

        private static void ListarPromocoes()
        {
            using (var promocaoRepository = new PromocaoRepository())
            {
                var promocoes = promocaoRepository.ListAll();
                foreach(var promocao in promocoes)
                {
                    Console.WriteLine(promocao);
                }
            }
        }

        private static void AdicionarPromocao()
        {
            var farinha = new Produto { Nome = "Café", Categoria = "Alimentos", PrecoUnitario = 2.49, Unidade = "Gramas" };
            var cocaCola = new Produto { Nome = "Coca-Cola", Categoria = "Bebidas", PrecoUnitario = 7.99, Unidade = "Litros" };
            var caneta = new Produto { Nome = "Caneta Esferográfica", Categoria = "Material Escolar", PrecoUnitario = 1.49, Unidade = "Unidade" };
            var promocao = new Promocao { DataInicial = DateTime.Now.Date, DataFinal = DateTime.Now.Date.AddMonths(2), Descricao = "Promoção de Aniversário" };
            promocao.AdicionarProdutos(farinha, cocaCola, caneta);
            using (var promocaoRepository = new PromocaoRepository())
            {
                promocaoRepository.Save(promocao);
            }
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
            using(var produtoRepository = new ProdutoRepository())
            {
                IList<Produto> produtos = produtoRepository.ListAll();
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

        private static void Pause()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
