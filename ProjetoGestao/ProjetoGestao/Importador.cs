using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjetoGestao
{
    internal class Importador
    {
        public void carregarDadosProdutos(string caminhoArquivo, List<Produto> listaProdutos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(caminhoArquivo.Trim()))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');
                        if (dados.Length == 3)
                        {
                            int idProduto = int.Parse(dados[0]);
                            string nome = dados[1];
                            double preco = double.Parse(dados[2]);
                            Produto produto = new Produto(idProduto, nome, preco);
                            listaProdutos.Add(produto);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao carregar os dados Produto: " + e.Message);
            }
        }
        public void carregarDadosClientes(string caminhoArquivo, List<Cliente> listaClientes)
        {
            try
            {
                using (StreamReader sr = new StreamReader(caminhoArquivo.Trim()))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');

                        if (dados.Length == 3)
                        {
                            int idCliente = int.Parse(dados[0]);
                            string nome = dados[1];
                            int documento = int.Parse(dados[2]);
                            Cliente cliente = new Cliente(idCliente, nome, documento);
                            listaClientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao carregar os dados Cliente: " + e.Message);
            }
        }


        public void salvarProdutos(string caminhoArquivo, List<Produto> listaProdutos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoArquivo.Trim()))
                {
                    foreach (Produto produtoAtual in listaProdutos)
                    {
                        sw.WriteLine($"{produtoAtual.getIdProduto()};{produtoAtual.getNome()};{produtoAtual.getPreco()}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao salvar dados Produto: " + e.Message);
            }
        }

        public void salvarClientes(string caminhoArquivo, List<Cliente> listaClientes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoArquivo.Trim()))
                {
                    foreach (Cliente clienteAtual in listaClientes)
                    {
                        sw.WriteLine($"{clienteAtual.getIdCliente()};{clienteAtual.getName()};{clienteAtual.getDocumento()}");
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao salvar dados Clientes: " + e.Message);
            }

        }

        public void SalvarVendas(string caminhoArquivo, List<Venda> listaVendas)
        {
            //String dados;
            using (StreamWriter sw = new StreamWriter(caminhoArquivo.Trim()))
            {
                
                foreach (var venda in listaVendas)
                {
                    StringBuilder itensVenda = new StringBuilder();
                    foreach (Produto prod in venda.getProdutosVenda())
                    {
                        itensVenda.Append(prod.getIdProduto() + ";" + prod.getNome() + ";" + prod.getPreco() + ";");
                    }
                    String clienteVenda;
                    if (venda.getCliente() == null)
                    {
                        clienteVenda = "Venda;Sem;Cliente";
                    }
                    else
                    {
                        clienteVenda = venda.getCliente().getIdCliente() + ";" + venda.getCliente().getName() + ";" + venda.getCliente().getDocumento();
    
                    }

                    string dados = venda.getIdVenda() + ";" + clienteVenda + ";" + venda.getValorTotal() + ";" + itensVenda.ToString().TrimEnd(';');
                    sw.WriteLine(dados);
                }
            }
        }

        public List<Venda> carregarDadosVendas(string caminhoArquivo)
        {
            List<Venda> vendas = new List<Venda>();
           
            
            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                String linha;

                while ((linha = reader.ReadLine()) != null)
                {
                    List<Produto> listaProdutos = new List<Produto>();
                    Venda venda = new Venda();

                    String[] dados = linha.Split(';');

                    if (dados[0] == "")
                    {
                        break;
                    }
                    
                    venda.setIdVenda(Convert.ToInt32(dados[0]));
                    if (dados[1].Equals("Venda"))
                    {
                        venda.setCliente(null);
                    }
                    else
                    {
                        Cliente cliente = new Cliente();
                        cliente.setIdCliente(Convert.ToInt32(dados[1]));
                        cliente.setName(dados[2]);
                        cliente.setDocumento(Convert.ToInt32(dados[3]));
                        venda.setCliente(cliente);
                    }
                    venda.setValorTotal(Convert.ToDouble(dados[4]));
                    for (int i = 5; i < dados.Length; i += 3)
                    {
                        if (i >= dados.Length - 1)
                        {
                            break;
                        }
                       
                        Produto produto = new Produto();
                        produto.setIdProduto(Convert.ToInt32(dados[i]));
                        produto.setNome(dados[i + 1]);
                        produto.setPreco(Convert.ToDouble(dados[i + 2]));
                        listaProdutos.Add(produto);

                        venda.setProdutoVenda(listaProdutos);
                        vendas.Add(venda);
                    }
                }
            }
            return vendas;
        }
    }
}
