# Portfolio API

Backend voor mijn portfoliosite. De API ondersteunt volledige CRUD (aanmaken, opvragen, wijzigen en verwijderen) voor **projecten** en **blogposts**. Gegevens worden via Entity Framework Core opgeslagen in SQL Server.

## Technieken

- .NET 10
- ASP.NET Core Web API (controllers)
- Entity Framework Core 10 met SQL Server (LocalDB)
- Swagger UI via Swashbuckle.AspNetCore

## Vereisten

- .NET 10 SDK
- SQL Server LocalDB (wordt meegeleverd met de Visual Studio-workload *ASP.NET and web development*)

## API-stijl en codestructuur

Ik heb gekozen voor **controllers** met een **gelaagde structuur**. HTTP-afhandeling, applicatielogica en datatoegang zijn van elkaar gescheiden:

| Map | Inhoud | Verantwoordelijkheid |
|---|---|---|
| `Controllers` | `ProjectsController`, `BlogpostsController` | HTTP-afhandeling: routes en statuscodes (200, 201, 204, 404) |
| `Services` | `IProjectService` / `ProjectService`, `IBlogpostService` / `BlogpostService` | Applicatielogica en de omzetting tussen entiteit en DTO (`ToDto` en `CopyInput`) |
| `Data` | `PortfolioDBContext` | Datatoegang via EF Core |
| `Entities` | `Project`, `Blogpost` | EF Core-entiteiten (tabellen in de database) |
| `Dtos` | `ProjectDto`, `ProjectInputDto`, `BlogpostDto`, `BlogpostInputDto` | Gegevens die de API ontvangt en terugstuurt |
| `Migrations` | `InitialCreate`, `AddBlogposts` | Migraties waarmee de database is aangemaakt |

Controllers gebruiken nooit rechtstreeks de DbContext of entiteiten. Ze praten alleen met een service via de interface. De DbContext en services worden via dependency injection geregistreerd in `Program.cs`.

## Database instellen

De connectionstring staat in `appsettings.json` onder `ConnectionStrings:DefaultConnection`:

```
Server=(localdb)\MSSQLLocalDB;Database=PortfolioDb;Trusted_Connection=True;TrustServerCertificate=True
```

De database wordt aangemaakt met **EF Core-migraties** (niet met `EnsureCreated`). Voer één van de volgende opties uit:

**Optie 1: Visual Studio (Package Manager Console)**
```
Update-Database
```

**Optie 2: terminal**
```
dotnet tool install --global dotnet-ef
cd WebApplication1
dotnet ef database update
```

Hiermee wordt de database `PortfolioDb` aangemaakt met de tabellen `Projects` en `Blogposts`.

## Applicatie starten

```
cd WebApplication1
dotnet run
```

Open daarna Swagger UI in de browser via:

```
http://localhost:5132/swagger
```

Wil je via HTTPS starten (zoals in Visual Studio), gebruik dan:

```
dotnet run --launch-profile https
```

en ga naar `https://localhost:7019/swagger`.

(Het poortnummer staat ook in de console na het starten, bij *Now listening on*.)

## Endpoints

| Methode | Route | Beschrijving |
|---|---|---|
| GET | `/api/Projects` | Alle projecten opvragen |
| GET | `/api/Projects/{id}` | Eén project opvragen (404 als het niet bestaat) |
| POST | `/api/Projects` | Project aanmaken (201) |
| PUT | `/api/Projects/{id}` | Project wijzigen (204, of 404) |
| DELETE | `/api/Projects/{id}` | Project verwijderen (204, of 404) |
| GET | `/api/Blogposts` | Alle blogposts opvragen |
| GET | `/api/Blogposts/{id}` | Eén blogpost opvragen (404 als hij niet bestaat) |
| POST | `/api/Blogposts` | Blogpost aanmaken (201) |
| PUT | `/api/Blogposts/{id}` | Blogpost wijzigen (204, of 404) |
| DELETE | `/api/Blogposts/{id}` | Blogpost verwijderen (204, of 404) |
