<h1 align="center"> 🖳 TodoApi Rest 🖳</h1>

<p align="center">
    <img src="https://github.com/danhpaiva/todo-api-mvc-net/blob/main/screen/api_01.png?raw=true" width="600" alt="TodoApi">
</p>

<p align="center">
    <img src="https://github.com/danhpaiva/todo-api-mvc-net/blob/main/screen/api_02.png?raw=true" width="600" alt="Testes Unitarios">
</p>

<p align="center">
 <a href="#status">Status</a> • 
 <a href="#objective">Objetivo</a> •
 <a href="#installation">Desenvolvimento</a> • 
 <a href="#technology">Tecnologias</a> • 
 <a href="#author">Autor</a> • 
 <a href="#licence">Licença</a>
</p>

<h2 align="center" id=status> 
	⌛ Concluído ⌛
</h2>

<h2 id=objective>📜 Sobre</h2>
Criacao de uma API simples no modelo Restfull em .Net + EntityFramework. <br>
O modelo de dados esta simples porque o foco esta em abstrair alguns conhecimentos.

<h2 id=installation>✔️ Instalacao</h2>

Você precisa ter o Visual Studio 2022 ou VsCode instalado para testar o projeto.</br>
O projeto roda sob o SDK .Net 9.

Rode o projeto e acesse a URL:

~~~
https://localhost:7181/swagger/index.html
~~~

#### Autenticacao

Para autenticar, acesse a url: 

~~~
https://localhost:7181/api/Auth/login
~~~

e use o JSON:

~~~
{
  "username": "admin",
  "password": "senhaforte"
}
~~~

O Token expira depois de 30 minutos.

#### Post

Clique no metodo Post, e cole esse modelo de retorno de dados:

~~~
{
  "name": "Estudar Arquitetura Hexagonal",
  "isComplete": true
}
~~~

Voce recebera um json semelhante a este:

~~~
{
  "id": 1,
  "name": "Estudar Arquitetura Hexagonal",
  "isComplete": true
}
~~~


<h2 id=technology>🧰 Tecnologias</h2>

As seguintes tecnologias foram utilizadas neste projeto:

- IDE: <a href="https://visualstudio.microsoft.com/pt-br/vs/">Visual Studio 2022</a>
- SDK: <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/9.0">.Net 9</a>
- EntityFrameworkCore: <a href="https://www.nuget.org/packages/microsoft.entityframeworkcore.inmemory">Microsoft.EntityFrameworkCore.InMemory</a>
- Autenticacao e Autorizacao: <a href="https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer">Microsoft.AspNetCore.Authentication.JwtBearer</a>
- Autenticacao e Autorizacao: <a href="https://www.nuget.org/packages/microsoft.identitymodel.tokens/">Microsoft.IdentityModel.Tokens</a>
- Autenticacao e Autorizacao: <a href="https://www.nuget.org/packages/system.identitymodel.tokens.jwt/">System.IdentityModel.Tokens.Jwt</a>
- Testes Unitarios: <a href="https://www.nuget.org/packages/xunit">xUnit</a>
- Docker: <a href="https://docs.docker.com/get-started/">Docker</a>
  
<h2 id=author>😎 Autor</h2>

Developed by <a href="https://www.linkedin.com/in/danhpaiva/" target="_blank">Daniel Paiva</a>

<h2 id=licence>🆓 Licença</h2>

Este projeto está sob a licença
<a href="https://github.com/danhpaiva/todo-api-mvc-net/blob/main/LICENSE" target="_blank">MIT</a>
