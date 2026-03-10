# CoffeeQueueApp

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-0078D4?style=for-the-badge&logo=microsoft&logoColor=white)](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview)
[![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-10.0.4-68217A?style=for-the-badge&logo=nuget&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-SSMS%2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
[![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![GitHub](https://img.shields.io/badge/GitHub-Source%20Control-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/)
[![YouTube](https://img.shields.io/badge/YouTube-Video%20Walkthrough-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://youtu.be/ErD-wNRYtSg)

---

## About This Project

**CoffeeQueueApp** is a demonstration project built to teach students how to create a full **ASP.NET Core MVC** web application connected to a **SQL Server** database using **Entity Framework Core** on **.NET 10**.

The app simulates a basic coffee shop queue system where **Baristas** manage **Coffee Orders**. It covers the complete workflow — from creating models, wiring up a database context, running migrations, to scaffolding full CRUD controllers and views.

> **YouTube Walkthrough:** [Watch the full video tutorial here](https://youtu.be/ErD-wNRYtSg)

---

## What is MVC?

**MVC (Model-View-Controller)** is an architectural pattern that separates an application into three distinct components, making the code cleaner, more maintainable, and easier to understand.

| Component | Role | Example in This Project |
|-----------|------|------------------------|
| **Model** | Represents the data and business logic | `Barista.cs`, `CoffeeOrder.cs` |
| **View** | The user interface — what the user sees | Razor `.cshtml` pages (CRUD views) |
| **Controller** | Handles user requests and coordinates the Model and View | `BaristaController.cs`, `CoffeeOrdersController.cs` |

**How it flows:**
1. A user sends a request (e.g., clicks "Add Coffee Order")
2. The **Controller** receives the request
3. It interacts with the **Model** (data/database)
4. It returns a **View** (HTML page) with the data to display

---

## What is ApplicationDbContext?

The `ApplicationDbContext` class is the **bridge between your C# application and the SQL Server database**. It inherits from Entity Framework Core's `DbContext` class.

```csharp
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<CoffeeOrder> CoffeeOrder => Set<CoffeeOrder>();
    public DbSet<Barista> Baristas => Set<Barista>();
}
```

**How it works:**
- Each `DbSet<T>` property represents a **table in the database**
- `DbSet<Barista>` maps to a `Baristas` table in SQL Server
- `DbSet<CoffeeOrder>` maps to a `CoffeeOrder` table in SQL Server
- When you run `Add-Migration` and `Update-Database`, Entity Framework reads these `DbSet` properties and **automatically generates the SQL tables** for you — no manual SQL required

---

## Project Structure

```
CoffeeQueueApp/
├── Data/
│   └── ApplicationDbContext.cs       # Links models to the SQL database
├── Models/
│   ├── Barista.cs                    # Barista model
│   └── CoffeeOrder.cs                # Coffee Order model
├── Controllers/
│   ├── BaristaController.cs          # Scaffolded CRUD controller
│   └── CoffeeOrdersController.cs     # Scaffolded CRUD controller
├── Views/
│   ├── Barista/                      # CRUD views for Barista
│   └── CoffeeOrders/                 # CRUD views for CoffeeOrder
├── appsettings.json                  # Database connection string
├── Program.cs                        # App configuration and startup
└── CoffeeQueueApp.csproj             # NuGet packages
```

---

## Models

### Barista Model

```csharp
public class Barista
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Barista Name Required")]
    [StringLength(50)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Barista shift time required")]
    [StringLength(20)]
    public string Shift { get; set; } = "Morning";

    // Navigation property — one Barista can have many CoffeeOrders
    public List<CoffeeOrder> Order { get; set; } = new List<CoffeeOrder>();
}
```

### CoffeeOrder Model

```csharp
public class CoffeeOrder
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Customer Name is required")]
    [StringLength(50)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Drink { get; set; } = "Latte";

    [Required]
    [StringLength(15)]
    public string Size { get; set; } = "Medium";

    [Required]
    [StringLength(50)]
    public string Milk { get; set; } = "Full Cream";

    [Range(0, 6, ErrorMessage = "Sugar must be between 0 and 6")]
    public int Sugar { get; set; } = 0;

    [Required]
    [StringLength(15)]
    public string Status { get; set; } = "Completed";

    public DateTime CreatedAt { get; set; }
}
```

---

## Step-by-Step Build Guide

### Step 1 — Create the MVC Project

1. Open **Visual Studio 2022**
2. Select **Create a new project**
3. Choose **ASP.NET Core Web App (Model-View-Controller)**
4. Name the project `CoffeeQueueApp`
5. Select **.NET 10.0** as the target framework
6. Click **Create**

---

### Step 2 — Open SQL Server Management Studio 22

1. Open **SSMS 22**
2. Connect to your local server using **Windows Authentication**
3. Server name: `localhost` or `.\SQLEXPRESS`
4. Confirm the connection is active — Entity Framework will create the database automatically

---

### Step 3 — Install Entity Framework Core NuGet Packages

Open the **NuGet Package Manager** (Tools → NuGet Package Manager → Manage NuGet Packages for Solution) and install:

| Package | Version |
|---------|---------|
| `Microsoft.EntityFrameworkCore.SqlServer` | 10.0.4 |
| `Microsoft.EntityFrameworkCore.Tools` | 10.0.4 |
| `Microsoft.VisualStudio.Web.CodeGeneration.Design` | 10.0.2 |

Your `.csproj` should include:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.4" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.4">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="10.0.2" />
</ItemGroup>
```

---

### Step 4 — Add the Models

Create the following files inside the `Models/` folder:

- `Barista.cs` — see model code above
- `CoffeeOrder.cs` — see model code above

---

### Step 5 — Create the ApplicationDbContext

Create a new folder called `Data/` in the project root. Inside it, create `ApplicationDbContext.cs`:

```csharp
using CoffeeQueueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeQueueApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<CoffeeOrder> CoffeeOrder => Set<CoffeeOrder>();
        public DbSet<Barista> Baristas => Set<Barista>();
    }
}
```

---

### Step 6 — Configure the Connection String (appsettings.json)

Open `appsettings.json` and add the `ConnectionStrings` section:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CoffeeDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> **Note:** If `localhost` does not work, try replacing it with `.\SQLEXPRESS` or your actual SQL Server instance name.

---

### Step 7 — Register the DbContext in Program.cs

Open `Program.cs` and register the `ApplicationDbContext` service:

```csharp
using CoffeeQueueApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
```

---

### Step 8 — Run Migrations

Open the **Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console) and run:

```powershell
Add-Migration InitialCreate
```

Then apply the migration to create the database tables:

```powershell
Update-Database
```

> After running `Update-Database`, open **SSMS** and confirm that the `CoffeeDB` database has been created with `Baristas` and `CoffeeOrder` tables.

---

### Step 9 — Scaffold Controllers and Views

1. Right-click the `Controllers/` folder → **Add → New Scaffolded Item**
2. Select **MVC Controller with views, using Entity Framework**
3. Choose `Barista` as the model and `ApplicationDbContext` as the data context
4. Click **Add**, then repeat the process for `CoffeeOrder`

This automatically generates full **Create, Read, Update, Delete (CRUD)** controllers and Razor views.

---

### Step 10 — Run and Test the Application

Press **F5** or click **Run** in Visual Studio. Navigate to:

- `/Baristas` — manage baristas
- `/CoffeeOrders` — manage coffee orders

Test all CRUD operations to confirm the application is working correctly with the database.

---

## Useful Resources

### Installation

- [How to Install SQL Server 2025 & SSMS 22 on Windows 10/11](https://www.youtube.com/watch?v=Tsbm11I04xI)

### Tutorials

- [ASP.NET Core MVC CRUD with .NET 8 & Entity Framework Core — Beginner Tutorial](https://www.youtube.com/watch?v=_uSw8sh7xKs)

### Reference Documentation

| Topic | Resource |
|-------|----------|
| HTML | [W3Schools HTML](https://www.w3schools.com/html/) |
| CSS | [W3Schools CSS](https://www.w3schools.com/css/default.asp) |
| JavaScript | [W3Schools JavaScript](https://www.w3schools.com/js/default.asp) |
| SQL | [W3Schools SQL](https://www.w3schools.com/sql/default.asp) |
| ASP.NET Core MVC | [Microsoft Learn — MVC Overview](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview) |
| Entity Framework Core | [Microsoft Learn — EF Core](https://learn.microsoft.com/en-us/ef/core/) |
| .NET 10 | [.NET Official Site](https://dotnet.microsoft.com/) |

---

## Author

**Cameron Chetty**
[GitHub Profile](https://github.com/st10251759) | [Personal Website](https://cameronchetty.co.za/)

---

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

[![YouTube](https://img.shields.io/badge/YouTube-Video%20Walkthrough-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://youtu.be/ErD-wNRYtSg)
