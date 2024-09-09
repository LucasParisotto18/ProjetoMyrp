using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestao
{
    internal class Cliente
    {
        private int idCliente;
        private string name;
        private int documento;

        public Cliente(int idCliente, string name, int documento)
        {
            this.idCliente = idCliente;
            this.name = name;
            this.documento = documento;
        }

        public Cliente()
        {
        }

        public void setIdCliente(int idCliente)
        {
            this.idCliente = idCliente;
        }

        public int getIdCliente()
        {
            return idCliente;
        }

        public string getName()
        {
            return name;
        }

        public int getDocumento()
        {
            return documento;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setDocumento(int documento)
        {
            this.documento = documento;
        }

        public Cliente novoCliente(List<Cliente> listaCliente)
        {
            Console.WriteLine("Nome do novo cliente:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o CPF/CNPJ do cliente:");
            int cpfCnpj = Convert.ToInt32(Console.ReadLine());

            if (checarClienteCPFCNPJ(listaCliente, cpfCnpj))
            {
                Console.WriteLine($"Cliente com CPF/CNPJ \'{cpfCnpj}\' já cadastrado em nossa base.");    
            } else
            {
                Cliente novoCliente = new Cliente(getUltimoId(listaCliente) + 1, nome, cpfCnpj);
                return novoCliente;
            }
            return null;
        }
        public int getUltimoId(List<Cliente> listaCliente)
        {
            int ultimoId = -1;
            if (listaCliente.Count.Equals(0))
            {
                ultimoId = 0;
            }
            else
            {
                ultimoId = listaCliente.Last().getIdCliente();
            }

            return ultimoId;
        }

        public bool checarClienteCPFCNPJ(List<Cliente> listaCliente, int cpfCnpj)
        {
            bool existe = false;

            foreach (Cliente cliente in listaCliente)
            {
                if (cliente.getDocumento().Equals(cpfCnpj))
                {
                    existe = true;
                    return existe;
                }
            }

            return existe;
        }


        public Cliente selecionarClienteVenda(List<Cliente> listaClientes)
        {
            Console.WriteLine("Lista de Clientes cadastrados: ");
            foreach (Cliente clienteAtual in listaClientes)
            {
                Console.WriteLine("- " + clienteAtual.ToString());
            }
            Console.WriteLine("Digite o ID do cliente que deseja vincular à essa venda: ");
            int idClienteVenda = Convert.ToInt32(Console.ReadLine());

            foreach (Cliente clienteAtual in listaClientes)
            {
                if (clienteAtual.getIdCliente() == idClienteVenda)
                {
                    return clienteAtual;
                }
            }
            return null;

        }

        public void listarClientes(List<Cliente> listaClientes)
        {
            Console.WriteLine("Segue lista dos Clientes: ");
            foreach (Cliente clienteAtual in listaClientes)
            {
                Console.WriteLine(clienteAtual.ToString());
            }
            Console.WriteLine("");
        }

        override
        public String ToString()
        {
          String result = $"| ID: {idCliente} | Nome: {name} | CPF/CNPJ: {documento} |";
          return result;
        }
    }
}
