# Desafio Softcom

## Escolha da linguagem
A linguagem escolhida foi C#, em detalhes ASP.NET Core 2.2 com Entity Framework Core. A razão principal de eu ter escolhido a versão 2.2 do ASP.NET Core foram algumas pequenas mudanças e inclusões por padrão, e principalmente a adoção do Bootstrap 4. 

O Entity Framework Core supriu 100% das necessidades, inclusive facilitando todo o projeto, como na raiz do CRUD (GETs e POSTs). Banco criado inicialmente com SQLite 3, porém migrei para o PostgreSQL devido ao Heroku prover o banco. O ORM fez todo o processo e apenas poucas linhas foram alteradas (string de conexão e serviço). Para a criação das classes, foi utilizado o [json2csharp](http://json2csharp.com/), que criou as classes exatamente como o esperado.

O JSON incluído no desafio foi utilizado para popular o banco pela primeira vez.

## Contexto do desafio
Adaptei o desafio para uma empresa de gestão financeira que possui clientes e cada cliente possui várias contas. As informações do JSON foram utilizadas para criar o primeiro cliente. O "administrador" da empresa pode realizar o CRUD completo tanto com clientes como com contas.

## Informações detalhadas
- Duas validações são realizadas, e-mail e fone do cliente. Para validar foi utilizado _Data Annotations_ da linguagem. 
- A paginação, busca e ordenação funcionam tanto para clientes como para contas.
- O layout inicial ("/") foi tirado como base [desse repositório](https://github.com/rafaelblink/AtestadosOnline).

## Deploy
O desafio foi publicado no **Heroku**, segue o link: https://dotnet-challenge-first-softcom.herokuapp.com/
