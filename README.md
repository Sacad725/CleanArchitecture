# CleanApi

.NET C# SQL Server EF Core MediatR JWT

Ett ASP.NET Core Web API byggt enligt **Clean Architecture** med CQRS, MediatR, Repository Pattern, DTO, AutoMapper och JWT Authentication.

Projektet hanterar **Users** och **Products** där en användare kan äga flera produkter.

---

# Kör programmet

## 1. Uppdatera connection string i appsettings.json

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=example;Trusted_Connection=True;TrustServerCertificate=True"
}
```

## 2. Skapa databasen

```bash
dotnet ef database update --project Infrastructure_Layer --startup-project API_Layer
```

## 3. Starta API

```bash
dotnet run --project API_Layer
```

## 4. Öppna Scalar

```plaintext

```

---

# Projektstruktur

```plaintext
CleanApi/
├── API_Layer/
│   ├── Controllers/
│   │   ├── ProductsController.cs
│   │   └── AuthController.cs
│   └── Program.cs
│
├── Application_Layer/
│   ├── Commands/
│   ├── Queries/
│   ├── DTO/
│   ├── Mapping/
│   └── DependencyInjection.cs
│
├── Domain_Layer/
│   ├── Entities/
│   │   ├── Product.cs
│   │   └── User.cs
│   └── Interfaces/
│
└── Infrastructure_Layer/
    ├── Data/
    ├── Repositories/
    └── Migrations/
```

---

# Layers

| Layer                | Ansvar                           |
| -------------------- | -------------------------------- |
| API_Layer            | Controllers, JWT, Startup        |
| Application_Layer    | Commands, Queries, Handlers, DTO |
| Domain_Layer         | Entities, Interfaces             |
| Infrastructure_Layer | EF Core, SQL Server, Repository  |

---

# Databasmodeller

## User

```plaintext
Id
Username
PasswordHash
Role
```

## Product

```plaintext
Id
Name
Price
UserId
```

## Relation

```plaintext
User (1) → Products (Many)
```

En användare kan ha många produkter.

---

# Features

## Clean Architecture

Projektet är uppdelat i 4 lager med tydliga ansvar.

## CQRS + MediatR

* Commands = skriva data
* Queries = läsa data

Controllers använder:

```csharp
_mediator.Send(...)
```

## Repository Pattern

All databaslogik ligger i repositories.

## JWT Authentication

Användaren loggar in och får token.

Skyddade endpoints använder:

```csharp
[Authorize]
```

## DTO + AutoMapper

Entities exponeras inte direkt utåt.

---

# Endpoints

| Method | Route           | Auth | Beskrivning          |
| ------ | --------------- | ---- | -------------------- |
| POST   | /api/auth/login | Nej  | Login och få JWT     |
| GET    | /api/products   | Ja   | Hämta alla produkter |
| POST   | /api/products   | Ja   | Skapa produkt        |

---

# JWT Login

## Request

```plaintext
POST /api/auth/login?username=test&password=1234
```

## Response

```json
{
  "token": "..."
}
```

---

# Skyddad endpoint

```plaintext
GET /api/products
```

Header:

```plaintext
Authorization: Bearer TOKEN
```

---

# CQRS Flöde

```plaintext
HTTP Request
→ Controller
→ MediatR
→ Handler
→ Repository
→ DbContext
→ SQL Server
→ DTO
→ Response
```

---

# Teknisk sammanfattning

| Del                | Beskrivning           |
| ------------------ | --------------------- |
| SOLID              | Tydliga ansvar        |
| Clean Architecture | Lager separerade      |
| CQRS               | Läs/Skriv separerat   |
| Security           | JWT Token             |
| ORM                | Entity Framework Core |

---

# Reflektion

Det viktigaste i projektet var att hålla lagren separerade.

Application Layer innehåller affärslogik.
Infrastructure Layer innehåller databaslogik.
API Layer innehåller endpoints.

Det gjorde projektet enklare att förstå och underhålla.

---

# skrivit av 

Sacad Elmi
Software Engineer
