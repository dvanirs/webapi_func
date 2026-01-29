# WebApi_Func

API RESTful para gerenciamento de usuários desenvolvida com ASP.NET Core 8, seguindo boas práticas de arquitetura, padrão CQS e testes automatizados.

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 8** (Web API)
- **PostgreSQL** (Banco de dados relacional)
- **Entity Framework Core** (ORM)
- **MediatR** (Implementação do padrão CQS)
- **FluentValidation** (Validação de dados)
- **Swagger / OpenAPI** (Documentação da API)
- **XUnit & Moq** (Testes Unitários)
- **Docker & Docker Compose** (Containerização)

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture**, organizado nas seguintes camadas:

- **Domain**: Contém as entidades (`User`) e interfaces de repositório.
- **Application**: Contém os Casos de Uso (Commands e Queries), DTOs, Validadores e Log de Negócio (Handlers).
- **Infrastructure**: Implementação do acesso a dados (EF Core, Repositories, Migrations).
- **API**: Controllers e configuração da aplicação.
- **Tests**: Testes unitários para validar as regras de negócio.

## ⚙️ Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop) (Opcional, se tiver um PostgreSQL local)

### 🐳 Via Docker (Recomendado)

Na raiz do projeto (onde está o arquivo `docker-compose.yml`), execute:

```bash
docker-compose up --build
```

A API estará disponível em: `http://localhost:8080/swagger`

### 💻 Execução Local

1. Configure a string de conexão no `appsettings.json` para o seu PostgreSQL local.
2. Na pasta do projeto `WebApi_Func`, execute:

```bash
dotnet restore
dotnet run
```

Acesse a documentação Swagger em: `https://localhost:7198/swagger` (ou a porta indicada no terminal).

## 🧪 Testes

Para executar os testes unitários:

```bash
dotnet test
```

## 📝 Funcionalidades (Endpoints)

- **GET /api/users**: Listagem paginada de usuários.
- **GET /api/users/{id}**: Obtém detalhes de um usuário.
- **POST /api/users**: Cadastro de novo usuário.
- **PUT /api/users/{id}**: Atualização de usuário existente.
- **DELETE /api/users/{id}**: Exclusão de usuário.
