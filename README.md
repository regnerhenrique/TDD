Código que servirá de auxilio para a talk da Valtech_ sobre testes.

Links dos frameworks e ferramentas utilizadas para a criação:

Visual Studio 2019: https://visualstudio.microsoft.com/pt-br/vs/
.Net Core 3.1: https://dotnet.microsoft.com/download/dotnet-core/3.1
xUnit: https://xunit.net/
MoQ: https://github.com/moq/moq4
Auto Mocker: https://github.com/moq/Moq.AutoMocker
Bogus: https://github.com/bchavez/Bogus

User Stories:

Épico: Cadastro de Cliente

Funcionalidade: Adicionar Cliente
Como um gerente de conta
Eu quero ser capaz de adicionar um cliente
Para que eu obter uma lista com todos os clientes

Cenário 1: Adicionar um cliente com sucesso
Dado que eu esteja na tela de adicionar um novo cliente
E todos os campos foram preenchidos corretamente
Quando for clicado em salvar
Entao sinalize que foi criada com sucesso

Cenário 2: Adicionar um cliente sem sucesso
Dado que eu esteja na tela de adicionar um novo cliente
E todos os campos não forem preenchidos corretamente
Quando for clicado em salvar
Entao me mostre quais os campos não foram preenchidos corretamente
