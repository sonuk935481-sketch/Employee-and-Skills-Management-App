# Employee and Skills Management App

A full-stack Employee and Skills Management System built using **.NET 10 Blazor**, **ASP.NET Core**, **Entity Framework Core**, and **SQL Server**.

The application allows users to manage employees and their skills with complete CRUD functionality. It demonstrates modern .NET development practices, Entity Framework Core Code First approach, and responsive UI using Blazor.

---

# Features

- Employee Management
  - Create Employee
  - Update Employee
  - Delete Employee
  - View Employee List

- Skill Management
  - Add Skills
  - Edit Skills
  - Delete Skills
  - View Skills

- Employee-Skill Mapping
  - Assign multiple skills to an employee
  - Remove assigned skills
  - View employee skill details

- Data Validation
- Entity Framework Core Code First
- SQL Server Database
- Responsive Blazor UI

---

# Technology Stack

- .NET 10
- ASP.NET Core
- Blazor Server
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Visual Studio 2022

---

# Project Structure

```
Employee-and-Skills-Management-App
│
├── Components
│   ├── Pages
│   ├── Layout
│   └── Shared
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Models
│   ├── Employee.cs
│   ├── Skill.cs
│   └── EmployeeSkill.cs
│
├── Services
│   ├── EmployeeService.cs
│   ├── SkillService.cs
│   └── Interfaces
│
├── Migrations
│
├── wwwroot
│
├── Program.cs
│
└── appsettings.json
```

---

# Prerequisites

Before running the application, install the following software.

- .NET 10 SDK
- Visual Studio 2022 (Latest Version)
- SQL Server 2019 or later
- SQL Server Management Studio (SSMS) (Optional)
- Git

---

# Clone Repository

```bash
git clone https://github.com/sonuk935481-sketch/Employee-and-Skills-Management-App.git
```

```bash
cd Employee-and-Skills-Management-App
```

# Configure Database Connection

Open

```
appsettings.json
```

Update the connection string.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployeeSkillsDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Example for SQL Authentication

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployeeSkillsDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
}
```

Replace

- YOUR_SERVER_NAME
- Database Name
- Username
- Password

with your local SQL Server details.

---

# Create Database

Open terminal inside the project folder.

Run

```bash
dotnet restore
```

Apply migrations

```bash
dotnet ef database update
```

If migrations are not available, create them first.

```bash
dotnet ef migrations add InitialCreate
```

Then

```bash
dotnet ef database update
```

---

# Build Project

```bash
dotnet build
```

---

# Run Project

```bash
dotnet run
```

The application will start and display something similar to

```
https://localhost:5001
```

or

```
https://localhost:7001
```

Open the displayed URL in your browser.

---

# Database Choice

This project uses **SQL Server**.

### Why SQL Server?

- Excellent integration with Entity Framework Core.
- Native support in Visual Studio.
- Reliable relational database.
- Easy migration management.
- Widely used in enterprise .NET applications.
- Strong performance for CRUD operations.

---

# Code Explanation

## Project Structure

The project follows a clean layer architecture for better maintainability.

### Models

Contains entity classes such as:

- Employee
- Skill
- EmployeeSkill

These classes represent database tables.

---

### Data

Contains

```
ApplicationDbContext
```

Responsible for

- Entity Framework configuration
- Database mapping
- Relationships
- DbSets

---

### Services

Business logic is separated into service classes.

Responsibilities include:

- CRUD operations
- Database communication
- Data retrieval
- Updating entities

This keeps UI components clean.

---

### Components / Pages

Contains all Blazor pages.

Examples

- Employee List
- Create Employee
- Edit Employee
- Skill List
- Create Skill

Pages interact with services instead of directly accessing the database.

---

# Employee–Skill Relationship

The Employee and Skill entities have a **Many-to-Many** relationship.

This is implemented using a junction table:

```
EmployeeSkill
```

Relationship

```
Employee
    |
    | One
    |
Many
EmployeeSkill
Many
    |
    | One
    |
Skill
```

Advantages

- One employee can have multiple skills.
- One skill can belong to multiple employees.
- Easily scalable.
- Maintains normalization.
- Prevents duplicate data.

---

# Validation

Validation is implemented using **Data Annotations**.

Blazor components use

```
EditForm
```

along with

```
DataAnnotationsValidator
```

to provide both client-side validation and server-side validation support.

Validation Summary and field-level validation messages are displayed to the user before submission.

---

# Design Decisions

Some important design decisions include:

- Entity Framework Core Code First approach.
- Dependency Injection for services.
- Separation of concerns using Services.
- Blazor Components for reusable UI.
- SQL Server as relational database.
- Clean folder structure.
- Reusable CRUD methods.
- Responsive Bootstrap UI.

---

# Future Improvements

With additional development time, the following features could be added:

- Authentication using ASP.NET Identity
- Role-Based Authorization (Admin/User)
- Search and filtering
- Pagination
- Sorting
- File upload for employee profile picture
- Skill proficiency levels
- Audit logging
- REST API endpoints
- Unit Testing
- Integration Testing
- Docker support
- Azure deployment
- Export to Excel/PDF
- Dark Mode
- Toast Notifications
- Global Exception Handling
- Repository Pattern with Unit of Work
- AutoMapper integration
- FluentValidation
- Serilog logging
- Caching

# Author

**Sonu Kumar**

GitHub

https://github.com/sonuk935481-sketch

<img width="1911" height="917" alt="image" src="https://github.com/user-attachments/assets/14961dc9-6659-46d1-a6d6-da2e1d548251" />
