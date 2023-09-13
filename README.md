# SuasContas-Backend

<h1>Sobre o Projeto:</h1>
<p>O projeto Suas Contas é uma implementação simples de um sistema de gestão pessoal focado nos gastos financeiros do usuário. 
  O sistema centraliza as contas do usuário em um aplicativo mobile, possibilitando uma gestão de suas contas pessoais</p>

<h1>Tecnologias e Padrôes Utilizadas</h1>
<li>
  <ul>.NET 6</ul>
  <ul>Asp .Net Core</ul>
  <ul>Sql Server</ul>
  <ul>Entity Framework</ul>
  <ul>Dominío Rico</ul>
  <ul>CQRS</ul>
  <ul>Fluent Validation</ul>
  <ul>Mediator</ul>
</li>

<h1>Como rodar o projeto localmente:</h1>
<p>Rodar o comando dotnet restore na raíz do projeto.</p>
<p></p>Acessar o arquivo appsettings.json na Pasta Api e alterar a connection string para a sua</p>
<p>Abrir o terminal e rodar o comando cd src/Infra</p>
<p>Em seguida rodar o comando dotnet ef database update --startup-project ..\Api\Api.csproj</p>
<p>Seguindo esses passos, você terá o modelo de dados já em sua instância SQL server Local.</p>
