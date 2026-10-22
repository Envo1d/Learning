# Course Work: Product Accounting with ADO.NET

A Windows Forms application for product, supply, and sales accounting with SQL Server storage and Excel report export.

**Topics:** desktop forms, ADO.NET connections and commands, SQL queries and joins, relational data, configuration, and Excel COM automation.

**Difficulty:** advanced learning project. Combines several application screens, database operations, and report generation.

## Features and Organization

- `Form1.cs` hosts the main interface and child forms.
- `Products.cs`, `Supply.cs`, and `Realize.cs` implement the product, supply, and sales screens.
- `Reports.cs` queries report data and exports it using Microsoft Excel automation.
- `ErrorMessage.cs` and `Ok.cs` provide feedback dialogs.
- Each form retains its `.Designer.cs` and `.resx` files.
- `Properties/` contains assembly information, application settings, and resource definitions and generated code.
- `Resources/` and `ico2.ico` contain the original images and icons.
- `BD.sql` contains the original SQL Server script for the `Enterprise` database.
- `CourseWork.sln`, `CourseWork.csproj`, `CourseWork.csproj.user`, `packages.config`, `App.config`, and `Program.cs` retain the original solution, project settings, dependency declarations, configuration, and startup code.

## Differences from GraduateWork

This project is preserved separately from [GraduateWork](../GraduateWork/) because its implementation differs. It targets .NET Framework 4.7.2 and uses `System.Data.SqlClient` connections, commands, and readers with explicit SQL queries. GraduateWork targets .NET 6 and uses Entity Framework Core. CourseWork references FontAwesome.Sharp 5.15.3, while GraduateWork references 6.1.1. Similar screen names and purpose do not make these projects identical; their chronological relationship was not verified.

## Requirements

Open `CourseWork.sln` in Visual Studio on Windows with support for .NET Framework 4.7.2. Restore the FontAwesome.Sharp 5.15.3 NuGet package declared in `packages.config`; the project expects it under its local `packages` directory.

The project declares COM references to Microsoft Office Core, Microsoft Excel, and VBIDE. Building requires suitable Office COM references, and report export requires Microsoft Excel installed and registered for automation.

Database operations require SQL Server and the schema used by the application. The main form reads the `SqlServer` connection string from `App.config`; connection settings must match the intended local environment. The supplied `BD.sql` script is preserved as written and was not executed or validated against every application query.

## Archive Notes

The original project and solution layout, all forms, supporting properties and resources, configuration, and SQL script were copied without changes. File hashes were checked against the originals. Generated `bin` and `obj` directories, restored `packages`, and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

This description is based on the implementation. The project was not built or run, database operations were not tested, and Excel export was not tested when adding it to the archive.
