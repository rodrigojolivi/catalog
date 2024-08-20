Instruções sobre o projeto de Api

1 - Incluir o projeto 'Catalog.Presentation.Api' como inicial
2 - Ao iniciar, o banco de dados será criado automaticamente, pois há um método no Program.cs que já executa as migrations
3 - Primeiro criar um usuário para cada tipo, Administrador, Vendedor e Cliente
4 - Confirmar o usuário no endpoint 'api/users/confirm' com o token recebido no cadastro ou alterar para 'true' a flag de 'EmailConfirmed' na tabela de usuários
5 - Fazer o CRUD de produtos de acordo com a necessidade
6 - Criar pedido com o cliente e produto pré-cadastrado

Obs.: Verificar a string de conexão para localhost
"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=catalog-dev;Trusted_Connection=True;MultipleActiveResultSets=true"

Instruções sobre o projeto de testes

1 - Incluir o projeto 'Catalog.Test.Unit' como inicial
2 - Rodar os testes

Detalhes do projeto

1 - NET 8
2 - C#
3 - WebApi
4 - Asp.NET Core Identity
5 - MSSQL Server
6 - Mediator
7 - Vertical Sliced Architecture
8 - UnitTest

A definição da arquitetura foi com base nos recursos solicitados e tempo para desenvolvimento.

Por ser um projeto basicamente simples, optei por criar uma arquitetura vertical, onde o time tem total liberdade
para criar novos recursos (features) sem afetar os existentes.