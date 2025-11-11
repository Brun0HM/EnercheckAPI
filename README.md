# ⚡ EnerCheck API

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET 9.0](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)
![Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow?style=for-the-badge)

---

## 🚀 Sobre o projeto

A **EnerCheck API** é o backend do ecossistema **EnerCheck**, uma plataforma voltada para **engenheiros elétricos** que desejam otimizar e reduzir custos em projetos elétricos por meio de **análises inteligentes baseadas em IA (Google Gemini)**.

Esta API foi desenvolvida em **ASP.NET Core 9.0 (C#)** e integra todo o sistema — conectando o painel administrativo, o aplicativo mobile e o site institucional.  
Sua principal função é **gerenciar usuários, projetos, planos de assinatura e análises de plantas elétricas**.

---

## 🧩 Estrutura do Banco de Dados

O modelo relacional foi estruturado para suportar múltiplos usuários e projetos simultâneos, garantindo escalabilidade e consistência entre as entidades.

### Tabelas principais:

#### 🧑‍💼 `usuarios`
- `id` *(int8)* — Identificador do usuário.  
- `nome` *(text)* — Nome completo do engenheiro.  
- `email` *(text)* — Email único para autenticação.  
- `data_inscricao` *(timestampz)* — Data de registro.  
- `numero_crea` *(text)* — Número de registro profissional.  
- `plano_id` *(int8)* — Relacionamento com o plano ativo.  
- `quantidade_requisicoes` *(int4)* — Limite de requisições da IA.  
- `projeto_id` *(int8)* — Último projeto associado.

#### ⚙️ `planos`
- `id` *(int8)* — Identificador do plano.  
- `nome` *(text)* — Nome comercial do plano.  
- `preco` *(numeric)* — Valor mensal.  
- `quantidade_requisicoes` *(int4)* — Limite de análises.  
- `ativado` *(bool)* — Define se o plano está ativo.  
- `quantidade_usuarios` *(int4)* — Número máximo de usuários.

#### 🧾 `projetos`
- `id` *(int8)* — Identificador do projeto.  
- `usuario_id` *(int8)* — Engenheiro responsável.  
- `nome` *(text)* — Nome do projeto elétrico.  
- `data_criacao` *(timestampz)* — Data de criação.  
- `progresso` *(int4)* — Percentual de execução.  
- `descricao` *(text)* — Detalhes do projeto.

#### 🧠 `analiseplanta`
- `id` *(int8)* — Identificador da análise.  
- `analise_json` *(jsonb)* — Resultado gerado pela IA (Gemini).  
- `projeto_id` *(int8)* — Projeto vinculado à análise.

---

## ⚙️ Funcionalidades Principais

✅ CRUD de usuários, planos e projetos  
✅ Autenticação via **JWT**  
✅ Integração com **Google Gemini API**  
✅ Armazenamento e consulta de resultados em formato **JSON**  
✅ Controle de planos e limites de requisições  
✅ Suporte a múltiplos módulos (Web, Mobile e Dashboard)  
✅ Documentação da API via **Swagger**

---

## 🛠️ Tecnologias Utilizadas

| Categoria | Tecnologia |
|------------|-------------|
| **Linguagem** | C# (.NET 9.0) |
| **ORM** | Entity Framework Core |
| **Banco de Dados** | SQL Server |
| **Autenticação** | JWT Bearer |
| **Documentação** | Swagger / Swashbuckle |
| **IA** | Google Gemini API |

---

## 🧰 Como Clonar e Executar no Visual Studio Community

### 1️⃣ Pré-requisitos

Certifique-se de ter instalado:
- [Visual Studio 2022 Community](https://visualstudio.microsoft.com/vs/community/)
- **.NET SDK 9.0**
- **SQL Server** (ou Azure SQL)
- **Git**

---

### 2️⃣ Clonar o repositório

Abra o terminal ou o próprio Visual Studio:

```bash
git clone https://github.com/Brun0HM/EnercheckAPI.git
```
### 3️⃣ Abrir no Visual Studio

Abra o Visual Studio Community

Vá em “Abrir um projeto ou solução”

Selecione o arquivo .sln localizado na pasta clonada.

### 4️⃣ Restaurar pacotes NuGet

No Visual Studio:

Vá até o menu Ferramentas → Gerenciador de Pacotes NuGet → Restaurar Pacotes
ou, no terminal do projeto:
```bash
dotnet restore
```

### 5️⃣ Principais Pacotes NuGet utilizados
Pacote	Função
Microsoft.EntityFrameworkCore	ORM para mapeamento do banco
Microsoft.EntityFrameworkCore.SqlServer	Provider do SQL Server
Microsoft.EntityFrameworkCore.Tools	Suporte a migrações
Swashbuckle.AspNetCore	Documentação da API (Swagger)
Microsoft.AspNetCore.Authentication.JwtBearer	Autenticação via JWT
Newtonsoft.Json	Manipulação de JSON
Google.AI.Gemini (ou integração customizada)	Comunicação com o modelo de IA
### 6️⃣ Configurar o appsettings.json

Exemplo de configuração mínima:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EnerCheckDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "chave-super-secreta",
    "Issuer": "EnerCheckAPI",
    "Audience": "EnerCheckUsers"
  },
  "Gemini": {
    "ApiKey": "SUA_CHAVE_API_GOOGLE"
  }
}
```
### 7️⃣ Executar a aplicação

No Visual Studio:

Pressione F5 ou selecione Executar com depuração.
A API será iniciada e poderá ser acessada em:
```bash

https://localhost:5001/swagger
```

## 📘 Documentação

A documentação completa dos endpoints está disponível via Swagger na rota:
```bash

/swagger/index.html
```

## 🧠 Integração com Gemini

A API envia as plantas elétricas em formato JSON ou imagem vetorial para o Google Gemini, que retorna:

Identificação de falhas;

Cálculo estimado de custo;

Sugestões de otimização energética;

Geração automática de relatórios técnicos.

## 🧾 Licença

Este projeto está sob a licença MIT.
Sinta-se livre para utilizá-lo e contribuir com melhorias.

## 🧑‍💻 Desenvolvido por
<table align="center"> <tr>
 <td align="center"><img src="https://avatars.githubusercontent.com/u/158314044" width="100px;" alt=""/><br /><sub><b>Thiago Mazzi</b></sub><br />💻 Dev FullStack</td>
 <td align="center"><img src="https://avatars.githubusercontent.com/u/158314249" width="100px;" alt=""/><br /><sub><b>Joaquim</b></sub><br />💻 Dev FullStack</td> 
 <td align="center"><img src="https://avatars.githubusercontent.com/u/158313981" width="100px;" alt=""/><br /><sub><b>Luiz Ghilherme </b></sub><br />💻 Dev FullStack</td> </tr>
</table>

Equipe EnerCheck — Projeto Final de Engenharia Elétrica com foco em Inteligência Artificial e Eficiência Energética.
