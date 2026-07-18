# ASP.NET Core MVC CRUD with Individual Identity

[ChatGpt link](https://chatgpt.com/share/6a5b0360-0404-83ee-a4cd-c327f3331fe8)
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/fe2172cd-4c9b-47c0-99e3-7590b5867fed" />


This project demonstrates how to build a CRUD (Create, Read, Update, Delete) application using **ASP.NET Core MVC**, **Entity Framework Core**, and **ASP.NET Core Identity**.

---

# Features

- ASP.NET Core MVC
- Individual Identity Authentication
- Entity Framework Core
- SQL Server Database
- Product CRUD
- Authentication Required for CRUD Operations
- Bootstrap UI

---

# Technologies

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- SQL Server
- Bootstrap 5

---

# Project Structure

```
Controllers/
Data/
Models/
Views/
wwwroot/
Program.cs
appsettings.json
```

---

# Step 1 - Create MVC Project

Create a new project.

```
File
→ New Project
→ ASP.NET Core Web App (Model-View-Controller)
```

Authentication Type

```
Individual Accounts
```

Click

```
Create
```

---

# Step 2 - Run the Project

```
Ctrl + F5
```

or

```
dotnet run
```

You should see

```
Home
Privacy
Register
Login
```

---

# Step 3 - Register User

Click

```
Register
```

Create a new account.

Example

```
Email
john@example.com

Password
********
```

After registration you will be automatically logged in.

---

# Step 4 - Create Product Model

Create

```
Models/Product.cs
```

```csharp
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
```

---

# Step 5 - Add DbSet

Open

```
Data/ApplicationDbContext.cs
```

Add

```csharp
public DbSet<Product> Products { get; set; }
```

Example

```csharp
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
```

---

# Step 6 - Create Migration

Open

```
Package Manager Console
```

Run

```powershell
Add-Migration AddProductTable
```

Then

```powershell
Update-Database
```

Database will contain

```
AspNetUsers
AspNetRoles
AspNetUserRoles
Products
...
```

---

# Step 7 - Scaffold CRUD

Right Click

```
Controllers
```

↓

```
Add
```

↓

```
New Scaffolded Item
```

↓

```
MVC Controller with views, using Entity Framework
```

Choose

```
Model Class

Product
```

Choose

```
Data Context

ApplicationDbContext
```

Controller Name

```
ProductsController
```

Click

```
Add
```

Visual Studio will generate

```
ProductsController.cs

Views

Products/
    Index
    Create
    Edit
    Delete
    Details
```

---

# Step 8 - Run CRUD

Open

```
https://localhost:xxxx/Products
```

Now you can

- Create Product
- Edit Product
- Delete Product
- View Product

---

# Step 9 - Add Product Menu

Open

```
Views/Shared/_Layout.cshtml
```

Add

```html
<li class="nav-item">
    <a class="nav-link"
       asp-controller="Products"
       asp-action="Index">
        Products
    </a>
</li>
```

---

# Step 10 - Protect CRUD with Login

Open

```
ProductsController.cs
```

Import

```csharp
using Microsoft.AspNetCore.Authorization;
```

Add

```csharp
[Authorize]
public class ProductsController : Controller
{
}
```

Now only authenticated users can access

```
/Products
```

If a user is not logged in, ASP.NET Core Identity automatically redirects to

```
/Identity/Account/Login
```

No additional code is required.

---

# Optional - Hide Product Menu

Open

```
Views/Shared/_Layout.cshtml
```

Wrap the menu with

```cshtml
@if (SignInManager.IsSignedIn(User))
{
    <li class="nav-item">
        <a class="nav-link"
           asp-controller="Products"
           asp-action="Index">
            Products
        </a>
    </li>
}
```

Now the Product menu is visible only after login.

---

# Project Flow

```
Start Application

↓

Register

↓

Login

↓

Products

↓

Create

↓

Edit

↓

Delete

↓

Logout
```

---

# Authentication Flow

```
User

↓

Login?

├── No
│
└── Redirect to Login

↓

Yes

↓

Access Products

↓

CRUD Operations
```

---

# Commands

Create Migration

```powershell
Add-Migration AddProductTable
```

Update Database

```powershell
Update-Database
```

Run Project

```powershell
dotnet run
```

---

# Next Learning Goals

- Role Based Authorization
- Admin Dashboard
- User Management
- Categories
- Product Images
- Search
- Pagination
- Repository Pattern
- Service Layer
- File Upload
- Validation
- Dependency Injection
- Logging
- Unit Testing

---

# Author

Zahid Hasan

Learning ASP.NET Core MVC & Identity
