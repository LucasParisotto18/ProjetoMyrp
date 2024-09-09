using ProjetoGestao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int escolha = 0;
            Importador importador = new Importador();
            List<Produto> listaProdutos = new List<Produto>();
            List<Cliente> listaClientes = new List<Cliente>();
            List<Venda> listaVendas = new List<Venda>();
            Produto produto = new Produto();
            Cliente cliente = new Cliente();
            Venda venda = new Venda();

            //Caminhos que devem apontar para os txt's correspondentes:
            String caminhoArquivoProdutos = "C:\\Users\\Lucas\\Desktop\\Curso\\ProjetoMyrp\\produtos.txt"; //txt produtos
            String caminhoArquivoClientes = "C:\\Users\\Lucas\\Desktop\\Curso\\ProjetoMyrp\\clientes.txt"; //txt clientes
            String caminhoArquivoVendas = "C:\\Users\\Lucas\\Desktop\\Curso\\ProjetoMyrp\\vendas.txt"; //txt vendas

            importador.carregarDadosProdutos(caminhoArquivoProdutos, listaProdutos);
            importador.carregarDadosClientes(caminhoArquivoClientes, listaClientes);
            listaVendas = importador.carregarDadosVendas(caminhoArquivoVendas);

            do
            {
                Console.WriteLine("|----  MENU PRINCIPAL  ----|");
                Console.WriteLine("| 1 - Nova Venda.          |");
                Console.WriteLine("| 2 - Cadastrar Produto.   |");
                Console.WriteLine("| 3 - Cadastrar Cliente.   |");
                Console.WriteLine("| 4 - Listar Produtos.     |");
                Console.WriteLine("| 5 - Listar Clientes.     |");
                Console.WriteLine("| 6 - Finalizar.           |");
                Console.WriteLine("|--------------------------|");
                escolha = Convert.ToInt32(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Opção selecionada: Nova Venda");
                        venda = venda.NovaVenda(listaClientes, listaProdutos, listaVendas);
                        listaVendas.Add(venda);
                        File.WriteAllText(caminhoArquivoVendas, string.Empty);
                        Console.WriteLine("Venda salva com sucesso.");

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Opção selecionada: Cadastrar Produto");
                        produto = produto.NovoProduto(produto.getUltimoId(listaProdutos));
                        listaProdutos.Add(produto);
                        importador.salvarProdutos(caminhoArquivoProdutos, listaProdutos);
                        Console.WriteLine("Produto cadastrado com sucesso.");
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Opção selecionada: Cadastrar Cliente");
                        cliente = cliente.novoCliente(listaClientes);
                        listaClientes.Add(cliente);
                        importador.salvarClientes(caminhoArquivoClientes, listaClientes);
                        Console.WriteLine("Cliente cadastrado com sucesso.");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Opção selecionada: Listar Produtos");
                        produto.listarProdutos(listaProdutos);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Opção selecionada: Listar Clientes");
                        cliente.listarClientes(listaClientes);
                        break;

                    case 6:
                        Console.WriteLine("Finalizando o programa...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção {escolha} é Inválida.");
                        Console.WriteLine("Por favor, selecione outra opção.");
                        break;
                }
                importador.SalvarVendas(caminhoArquivoVendas, listaVendas);


            } while (escolha != 6);

        }

    }
}
