# Projeto de Gestão de Vendas

Este projeto é uma aplicação de gerenciamento de vendas.

# Funcionalidades 

- Cadastro de clientes.
- Cadastro de produtos.
- Cadastro de vendas, atribuindo produtos e um cliente.
- Listagem de todos os clientes cadastrados.
- Listagem de todos os produtos cadastrados.

# Estrutura do Projeto (Classes)
- Cliente.cs: Representa um cliente com informações de ID, nome e documento.
- Produto.cs: Representa um produto com ID, nome e preço.
- Venda.cs: Gerencia a criação e manipulação de vendas, associando produtos e cliente. Além dos atributos de ID e valor total.
- Importador.cs: Responsável por carregar e salvar dados em arquivos de texto.

# Observações
- Escolhi fazer a persistência de dados foi feita usando arquivo plano (txt). Tendo três arquivos para a persistência (vendas.txt, produtos.txt, clientes.txt).
- A parte visual foi realizada via Console.

# Como rodar
- Único ponto de antenção são os caminhos dos arquivos de texto. Os arquivos, em si, já estão junto no repositório, sendo apenas necessário alterar o caminho na classe Program.cs das Strings:
`caminhoArquivoProdutos`, `caminhoArquivoClientes`, `caminhoArquivoVendas`, respectivamente nas linhas 27, 28, 29.


 
## Autor
- Lucas Elias Parisotto.
