# Projeto de Gest�o de Vendas

Este projeto � uma aplica��o de gerenciamento de vendas.

# Funcionalidades 

- Cadastro de clientes.
- Cadastro de produtos.
- Cadastro de vendas, atribuindo produtos e um cliente.
- Listagem de todos os clientes cadastrados.
- Listagem de todos os produtos cadastrados.

# Estrutura do Projeto (Classes)
- Cliente.cs: Representa um cliente com informa��es de ID, nome e documento.
- Produto.cs: Representa um produto com ID, nome e pre�o.
- Venda.cs: Gerencia a cria��o e manipula��o de vendas, associando produtos e cliente. Al�m dos atributos de ID e valor total.
- Importador.cs: Respons�vel por carregar e salvar dados em arquivos de texto.

# Observa��es
- Escolhi fazer a persist�ncia de dados foi feita usando arquivo plano (txt). Tendo tr�s arquivos para a persist�ncia (vendas.txt, produtos.txt, clientes.txt).
- A parte visual foi realizada via Console.

# Como rodar
- �nico ponto de anten��o s�o os caminhos dos arquivos de texto. Os arquivos, em si, j� est�o junto no reposit�rio, sendo apenas necess�rio alterar o caminho na classe Program.cs das Strings:
`caminhoArquivoProdutos`, `caminhoArquivoClientes`, `caminhoArquivoVendas`, respectivamente nas linhas 27, 28, 29.


 
## Autor
- Lucas Elias Parisotto.