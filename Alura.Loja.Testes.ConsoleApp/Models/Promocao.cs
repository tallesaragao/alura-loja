using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp.Models
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        private IList<PromocaoProduto> promocoesProdutos = new List<PromocaoProduto>();
        public virtual IList<PromocaoProduto> PromocoesProdutos
        {
            get
            {
                return new ReadOnlyCollection<PromocaoProduto>(promocoesProdutos);
            }
            private set
            {
                promocoesProdutos = value;
            }
        }

        public void AdicionarProdutos(params Produto[] produtos)
        {
            foreach (var produto in produtos)
            {
                promocoesProdutos.Add(new PromocaoProduto { Produto = produto });
            }
        }

        public override string ToString()
        {
            string produtos = "";
            for (int i = 0; i < PromocoesProdutos.Count; i++)
            {
                var promocaoProduto = PromocoesProdutos[i];
                if (i < PromocoesProdutos.Count - 1)
                    produtos += promocaoProduto.Produto.Nome + ", ";
                else
                    produtos += promocaoProduto.Produto.Nome;
            }
            return $"Promocao[ Descricao: {Descricao}, DataInicial: {DataInicial.ToShortDateString()}, DataFinal: {DataFinal.ToShortDateString()}, Produtos: ({produtos})";
        }
    }
}
