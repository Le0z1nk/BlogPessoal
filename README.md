# 📖 BlogPessoal API

API REST desenvolvida em ASP.NET para gerenciamento de um blog pessoal, permitindo cadastro de usuários, autenticação segura e gerenciamento de postagens e temas.

O projeto foi desenvolvido utilizando autenticação JWT, criptografia de senhas com BCrypt e documentação interativa com Swagger.

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core
- PostgreSQL
- Swagger
- Insomnia
- JWT Authentication
- BCrypt Password Hashing
- Entity Framework Core

---

# 📂 Funcionalidades

✅ Cadastro de usuários  
✅ Login com autenticação JWT  
✅ Criptografia de senha com BCrypt  
✅ CRUD de postagens  
✅ CRUD de temas  
✅ Relacionamento entre usuários, postagens e temas  
✅ Documentação automática da API com Swagger  

---

# 🔐 Segurança

O projeto utiliza:

- **JWT (JSON Web Token)** para autenticação e autorização
- **BCrypt** para criptografia de senhas
- Rotas protegidas por token

---

# 🗄️ Banco de Dados

O banco de dados utilizado foi o PostgreSQL.

Estrutura principal:
- Usuários
- Postagens
- Temas

---

# ⚙️ Como Executar o Projeto

## 1. Clonar o repositório

```bash
git clone https://github.com/Le0z1nk/BlogPessoal.git
````
---

## 3. Configurar a connection string

No arquivo:

```bash
appsettings.json
```

Configure:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=nome_database;Username=postgres;Password=sua_senha"
}
```

---

## 4. Restaurar dependências

```bash
dotnet restore
```

---

## 5. Executar as migrations

```bash
dotnet ef database update
```

---

## 6. Executar o projeto

```bash
dotnet run
```

---

# 📑 Documentação da API

Após executar o projeto, acesse:

```bash
http://localhost:5000/swagger
```

ou

```bash
https://localhost:5001/swagger
```

---

# 🧪 Testes da API

Os testes das rotas foram realizados utilizando o:

* Insomnia

---

# 📌 Exemplos de Endpoints

## Usuários

| Método | Endpoint            |
| ------ | ------------------- |
| POST   | api/usuarios/cadastrar |
| POST   | api/usuarios/login     |
| PUT    | api/usuarios/{id}      |
| DELETE | api/usuarios/{id}      |

---

## Postagens

| Método | Endpoint        |
| ------ | --------------- |
| GET    | api/postagens                                   |
| GET    | api/posatgens/filtro/?autor={id} ou ?tema={id}  |
| POST   | api/postagens                                   |
| PUT    | api/postagens/{id}                              |
| DELETE | api/postagens/{id}                              |

---

## Temas

| Método | Endpoint    |
| ------ | ----------- |
| GET    | api/temas      |
| POST   | api/temas      |
| PUT    | api/temas{id}  |
| DELETE | api/temas/{id} |
