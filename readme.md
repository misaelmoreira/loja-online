# Loja Online em .NET4.7- Estudos e Implementacoes.

Este repositório contém um projeto de estudos de uma loja online, desenvolvido em três camadas: **Business**, **Database** e **Apresentação**. A camada de apresentação segue o padrão **MVC** (Model-View-Controller), utilizando o **.NET Framework 4.7.2**.

## Tecnologias Utilizadas

- **.NET Framework 4.7.2**
- **MVC (Model-View-Controller)**
- **Bootstrap** para o design responsivo da interface de usuário
- **jQuery** para manipulação de DOM e AJAX

## Estrutura do Projeto

- **Business Layer**: Contém a lógica de negócios do aplicativo.
- **Database Layer**: Responsável pela comunicação com o banco de dados.
- **Apresentação (Presentation Layer)**: Interface de usuário construída utilizando o padrão MVC.

## Como Executar

1. **Clone este repositório**:

    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. **Abra o projeto no Visual Studio.**

3. **Restaure as dependências do projeto** via NuGet Package Manager.

4. **Criação do Banco de Dados**:
   - Execute o arquivo `script_banco.sql` no SQL Server para criar o banco de dados necessário.

5. **Configuração da Conexão com o Banco de Dados**:
   - Abra o arquivo `Web.example.config`.
   - Renomeie para `Web.config`.
   - Localize a seção `<appSettings>`.
   - Insira os dados da conexão do SQL Server (host, porta, usuário e senha) no formato abaixo:

    ```xml
    <appSettings>
        <add key="sqlConn" value="Data Source=[host],[port];Initial Catalog=LojaOnline;User ID=[user];Password=[password]" />
    </appSettings>
    ```

6. **Compile e execute o projeto.**

## Funcionalidades Implementadas

- **Cadastro de produtos**
- **Gerenciamento de carrinho de compras**
- **Processamento de pedidos**

## Contribuições

Este é um projeto de estudos, então **sugestões e contribuições** são bem-vindas!

---