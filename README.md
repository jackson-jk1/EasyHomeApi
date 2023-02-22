## Estrutura do codigo

Este projeto possui uma arqutetura baseado no DDD("Domain Drive Desing")

Aqui está uma explicação da arquitetura DDD implementada no projeto:

A camada de aplicação ("Application") é responsável por orquestrar o fluxo de dados e serviços do sistema. É responsável por receber as requisições, delegar a lógica de negócio e orquestrar o fluxo dos dados através das camadas. Essa camada deve ser mantida o mais simples possível e não deve conter lógica de negócio.

A camada de domínio ("Domain") contém classes que são de dominio global tais como envio de e-mails, e outras funcionalidades.

A camada de infraestrutura ("Infra") é responsável por fornecer serviços de baixo nível, como acesso a banco de dados. É aqui que a persistência de dados é implementada, bem como a integração com outros sistemas.

A camada de Service("Service") é responsável por toda a logica de negocio da aplicação.

## Configuração do ambiente .NET 6 para executar a API

Este guia fornece instruções passo a passo para configurar o ambiente necessário para executar a API. A API é baseada em .NET 6, portanto, você precisará ter o SDK .NET 6 instalado em sua máquina.

## Passo 1: Instalar o .NET 6 SDK
Para instalar o .NET 6 SDK, siga as instruções para o seu sistema operacional, que podem ser encontradas no site da Microsoft: https://dotnet.microsoft.com/download/dotnet/6.0

## Passo 2: Clonar o repositório da API
Clone o repositório da API em sua máquina. Você pode fazer isso usando um cliente Git ou baixando o arquivo zip do repositório e descompactando em seu computador.

## Passo 3: Configurar a conexão com o banco de dados
A API usa um banco de dados para armazenar e recuperar dados. Antes de executar a API, você precisa configurar a conexão com o banco de dados. Abra o arquivo appsettings.json na raiz do projeto e atualize as configurações de banco de dados com as informações da sua instância do banco de dados.

"Database": {
    "mysql": {
      "server": "<seu server>",
      "port": <sua porta>,
      "database": "<seu banco>",
      "username": "<seu usuario>",
      "password": "<>sua senha"
    } 
}

## 🚀 Instalando EasyHomeApi

Para instalar o EasyHomeApi, siga estas etapas:


Windows:
```
dotnet restore
database-update
dotnet run
```

## 🤝 Colaboradores

Agradecemos às seguintes pessoas que contribuíram para este projeto:

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/54186456?v=4" width="100px;" alt="Foto do pagoto"/><br>
        <sub>
          <b>Gabriel Pagoto</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/56005941?s=400&u=0282b7888567a9f7f3df62df4433743a38289305&v=4" width="100px;" alt="Foto do Jackson"/><br>
        <sub>
          <b>Jackson longo dos santos</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#">
        <img src="https://pps.whatsapp.net/v/t61.24694-24/298393423_191871359934710_1423164344747583347_n.jpg?ccb=11-4&oh=01_AdSyHhlJAx-4oOvzefy_-rsjgT97CccprYQ7J8Xo8UoVRw&oe=64037008" width="100px;" alt="Foto do Jose"/><br>
        <sub>
          <b>Jose Adilson</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

[⬆ Voltar ao topo](#nome-do-projeto)<br>
