using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetoGestao
{
    internal class Produto
    {
        private int idProduto;
        private string nome;
        private double preco;

        public Produto()
        {
        }

        public Produto(int idProduto, string nome, double preco)
        {
            this.idProduto = idProduto;
            this.nome = nome;
            this.preco = preco;
        }

        public int getIdProduto()
        {
            return idProduto;
        }

        public void setIdProduto(int idProduto)
        {
            this.idProduto = idProduto;
        }

        public String getNome()
        {
            return nome;
        }

        public void setNome(String nome)
        {
            this.nome = nome;
        }

        public double getPreco()
        {
            return preco;
        }

        public void setPreco(double preco)
        {
            this.preco = preco;
        }


        public Produto NovoProduto(int idUltimoProduto)
        {
            Console.WriteLine("Digite o nome do novo produto? ");
            String nome = Console.ReadLine();

            Console.WriteLine("Qual o preço do produto?");
            double preco = Convert.ToDouble(Console.ReadLine());

            idUltimoProduto++;

            Produto NovoProduto = new Produto(idUltimoProduto, nome, preco);

            return NovoProduto;
        }

        public int getUltimoId(List<Produto> listaProdutos)
        {
            int ultimoId = -1;
            if (listaProdutos.Count.Equals(0))
            {
                ultimoId = 0;
            }
            else
            {
                ultimoId = listaProdutos.Last().getIdProduto();
            }

            return ultimoId;
        }

        public Produto selecionarProdutoVenda(List<Produto> listaProdutos)
        {
            Console.WriteLine("Lista de Produtos cadastrados: ");
            foreach (Produto ProdutoAtual in listaProdutos)
            {
                Console.WriteLine("- " + ProdutoAtual.ToString());
            }
            Console.WriteLine("Digite o ID do produto que deseja adicionar à essa venda: ");
            int idProdutoVenda = Convert.ToInt32(Console.ReadLine());

            foreach (Produto produtoAtual in listaProdutos)
            {
                if (produtoAtual.getIdProduto() == idProdutoVenda)
                {
                    return produtoAtual;
                }
            }
            return null;

        }

        public void listarProdutos(List<Produto> listaProdutos)
        {
            Console.WriteLine("Segue lista de Produtos: ");
            foreach (Produto produtoAtual in listaProdutos)
            {
                Console.WriteLine(produtoAtual.ToString());
            }
            Console.WriteLine("");
        }

        override
        public String ToString()
        {
            String result = $"| ID: {idProduto} | Nome: {nome} | Preço: {preco} |";
            return result;
        }
    }
}