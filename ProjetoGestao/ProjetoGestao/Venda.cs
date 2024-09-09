using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestao
{
    internal class Venda
    {
        private int idVenda;
        private List<Produto> produtosVenda;
        private Cliente cliente;
        private double valorTotal;

        public Venda(int idVenda, List<Produto> produtosVenda, Cliente cliente, double valorTotal)
        {
            this.idVenda = idVenda;
            this.produtosVenda = produtosVenda;
            this.cliente = cliente;
            this.valorTotal = valorTotal;
        }

        public Venda()
        {
        }

        public Venda(int idVenda)
        {
            this.idVenda = idVenda;
        }

        public void setIdVenda(int idVenda)
        {
            this.idVenda = idVenda;
        }

        public int getIdVenda()
        {
            return this.idVenda;
        }

        public void setProdutoVenda(List<Produto> produto)
        {
            this.produtosVenda = produto;
        }

        public List<Produto> getProdutosVenda()
        {
            return this.produtosVenda;
        }

        public void setCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Cliente getCliente()
        {
            return this.cliente;
        }

        public void setValorTotal(double valorTotal)
        {
            this.valorTotal = valorTotal;
        }

        public double getValorTotal()
        {
            return this.valorTotal;
        }

        public int getUltimoId(List<Venda> listaVendas)
        {
            int ultimoId = -1;
            if (listaVendas.Count.Equals(0))
            {
                ultimoId = 0;
            }
            else
            {
                ultimoId = listaVendas.Last().getIdVenda();
            }

            return ultimoId;
        }

        public Venda NovaVenda(List<Cliente> listaClientes, List<Produto> listaProdutos, List<Venda> listaVendas)
        {
            //id produtos CLIENTE vltottal
            Cliente cliente = new Cliente();
            List<Produto> produtosAdd = new List<Produto>();
            int opcao = 0;
            int validadorProd = 0;

            Console.WriteLine("Deseja vincular um cliente? (1 - Sim | 2 - Não)");
            int vincularCliente = Convert.ToInt32(Console.ReadLine());

            if (vincularCliente == 1)
            {
                cliente = selecionarClienteVenda(listaClientes);
                if (cliente != null)
                {
                    Console.WriteLine("Cliente cadastrado!");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }
            }

            do
            {
                Console.WriteLine("Adicione um produto para a venda: ");
                foreach (Produto produtoAtual in listaProdutos)
                {
                    Console.WriteLine(produtoAtual.ToString());
                }
                Console.WriteLine("Digite o ID do produto desejado: ");
                int idProdVenda = Convert.ToInt32(Console.ReadLine());
                Produto produtoSelecionado = null;
                foreach (Produto produtoAtual in listaProdutos)
                {

                    if (produtoAtual.getIdProduto() == idProdVenda)
                    {
                        produtoSelecionado = produtoAtual;
                        break;
                    }

                }

                if (produtoSelecionado != null)
                {
                    produtosAdd.Add(produtoSelecionado);
                    Console.WriteLine("Produto Adicionado.");
                    validadorProd++;
                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                }

                if (validadorProd > 0)
                {
                    Console.WriteLine("Deseja adicionar um novo Produto? (1 - Sim | 2 - Não)");
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Você deve adicionar pelo menos um produto à venda.");
                    opcao = 1;
                }
            } while (opcao != 2);

            int novoID = getUltimoId(listaVendas)+ 1;

            Venda novaVenda = new Venda(novoID, produtosAdd, cliente, valorTotalVenda(produtosAdd));
            return novaVenda;

        }


        public Cliente selecionarClienteVenda(List<Cliente> listaClientes)
        {
            int idClienteVenda;
            Cliente cliente = null;

            Console.WriteLine("Segue lista dos Clientes: ");
            foreach (Cliente clienteAtual in listaClientes)
            {
                Console.WriteLine(clienteAtual.ToString());
            }
            Console.WriteLine("Escolha o ID do cliente que você deseja:");
            idClienteVenda = Convert.ToInt32(Console.ReadLine());

            foreach (Cliente clienteAtual in listaClientes)
            {
                if (clienteAtual.getIdCliente() == idClienteVenda)
                {
                    cliente = clienteAtual;
                }
            }
            return cliente;
        }

        public double valorTotalVenda(List<Produto> listaProdutosAdd)
        {
            double valorTotal = 0;
            foreach (Produto produto in listaProdutosAdd)
            {
                valorTotal += produto.getPreco();
            }
            return valorTotal;
        }

        

        override
        public string ToString()
        {
            string resultado = $"ID Venda: {idVenda}\n";
            if (cliente != null)
            {
                resultado += $"Cliente: ID: {cliente.getIdCliente()} | Nome: {cliente.getName()} | Documento: {cliente.getDocumento()}\n";
            }
            else
            {
                resultado += "Cliente: Não vinculado\n";
            }

            resultado += "Produtos:\n";
            foreach (Produto produto in produtosVenda)
            {
                resultado += $"  - {produto.ToString()}\n";

                resultado += $"Valor Total: {valorTotal:C}";

               
            }
            return resultado;
        }
    }
}

