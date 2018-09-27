using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra
    {
        public int Id { get; set; }
        public int ProdutoId { get; private set; }

        private Produto produto;
        public virtual Produto Produto
        {
            get
            {
                return produto;
            }
            set
            {
                produto = value;
                if (produto != null)
                    ProdutoId = produto.Id;
                Total = CalcularTotal();
            }
        }

        private int quantidade;
        public int Quantidade
        {
            get
            {
                return quantidade;
            }
            set
            {
                quantidade = value;
                if (produto != null)
                    Total = CalcularTotal();
            }
        }
        public double Total { get; private set; }

        private double CalcularTotal()
        {
            return quantidade * produto.PrecoUnitario;
        }

        public override string ToString()
        {
            return $"Compra[ProdutoId: {ProdutoId}, ProdutoNome: {Produto.Nome}, PrecoUnitario: {Produto.PrecoUnitario}, Quantidade: {Quantidade}, Total: {Total} ";
        }
    }
}
