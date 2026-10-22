# Graduate Work: Product Accounting

A Windows Forms application for product, supply, and sales accounting, with a SQL Server database and Excel report export.

**Topics:** desktop interfaces, Entity Framework Core, relational data modeling, asynchronous database access, input validation, and Excel COM automation.

**Difficulty:** advanced learning project. Combines multiple forms, persistent business data, related entities, and report generation.

## Features

- A main window that hosts product, supply, sales, and reporting forms.
- Database entities for products, producers, suppliers, customers, sellers, addresses, units, supplies, and sales.
- SQL Server access through Entity Framework Core.
- Report export to `.xlsx` files using Microsoft Excel automation.
- Shared validation helpers and success/error dialogs.

## Archive Structure

The original solution layout is preserved:

```text
GraduateWork.sln
GraduateWork/
    GraduateWork.csproj
    GraduateWork.csproj.user
    Program.cs
    MainForm.cs
    MainForm.Designer.cs
    MainForm.resx
    App.config
    DB.sql
    Common/
    DB/
        AppDbContext.cs
        Entity/
    Forms/
    Properties/
    Resources/
```

`Forms/` includes the source, designer, and resource files for the child forms and dialogs. `Properties/` contains generated resource access code and resource definitions. `Resources/` contains the original logo and icon. The supplied `.csproj.user` file is preserved as part of the original project.

## Requirements

- Windows and build tools supporting .NET 6 Windows Forms (`net6.0-windows`).
- Visual Studio/MSBuild with support for the project's Office and Excel COM references.
- Microsoft Excel installed and registered for COM automation to export reports.
- SQL Server and connection settings appropriate for the local environment.
- NuGet package restore for the versions declared in `GraduateWork.csproj`, including Entity Framework Core 6.0.10, EntityFrameworkCore.Exceptions.SqlServer 6.0.3.1, and FontAwesome.Sharp 6.1.1.

Open `GraduateWork.sln` in Visual Studio and restore the project packages. The main form reads the `SqlServer` connection string from `App.config`. `DB.sql` contains the original SQL Server script for the `Enterprise` database. The data context also calls `Database.EnsureCreated()` when constructed. These database initialization paths were preserved as supplied and were not checked for equivalence.

## Archive Notes

The source code, configuration, SQL script, form resources, images, and solution files were copied without changes, with file hashes checked against the originals. Generated `bin` and `obj` directories, Visual Studio's `.vs` data, and the source repository's `.git` directory are excluded. The original project remains in its source location.

This description is based on the implementation. The project was not built or run, the SQL script was not executed, and Excel export was not tested when adding it to the archive.
