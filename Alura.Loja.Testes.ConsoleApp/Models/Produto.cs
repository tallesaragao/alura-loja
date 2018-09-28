using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp.Models
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; set; }
        public virtual IList<Compra> Compras { get; set; }
        public virtual IList<PromocaoProduto> PromocoesProdutos { get; set; }

        public override string ToString()
        {
            return $"Produto[Id: {Id}, Nome: {Nome}, Categoria: {Categoria}, Preço: {PrecoUnitario}, Unidade: {Unidade}]";
        }
    }
}