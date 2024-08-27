# Loja Online em .NET4.7- Estudos e Implementacoes.

Este reposit�rio cont�m um projeto de estudos de uma loja online, desenvolvido em tr�s camadas: **Business**, **Database** e **Apresenta��o**. A camada de apresenta��o segue o padr�o **MVC** (Model-View-Controller), utilizando o **.NET Framework 4.7.2**.

## Tecnologias Utilizadas

- **.NET Framework 4.7.2**
- **MVC (Model-View-Controller)**
- **Bootstrap** para o design responsivo da interface de usu�rio
- **jQuery** para manipula��o de DOM e AJAX

## Estrutura do Projeto

- **Business Layer**: Cont�m a l�gica de neg�cios do aplicativo.
- **Database Layer**: Respons�vel pela comunica��o com o banco de dados.
- **Apresenta��o (Presentation Layer)**: Interface de usu�rio constru�da utilizando o padr�o MVC.

## Como Executar

1. **Clone este reposit�rio**:

    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. **Abra o projeto no Visual Studio.**

3. **Restaure as depend�ncias do projeto** via NuGet Package Manager.

4. **Cria��o do Banco de Dados**:
   - Execute o arquivo `script_banco.sql` no SQL Server para criar o banco de dados necess�rio.

5. **Configura��o da Conex�o com o Banco de Dados**:
   - Abra o arquivo `Web.example.config`.
   - Renomeie para `Web.config`.
   - Localize a se��o `<appSettings>`.
   - Insira os dados da conex�o do SQL Server (host, porta, usu�rio e senha) no formato abaixo:

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

## Contribui��es

Este � um projeto de estudos, ent�o **sugest�es e contribui��es** s�o bem-vindas!

---