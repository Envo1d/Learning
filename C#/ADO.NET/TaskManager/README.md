# ADO.NET Task Manager

C# homework: a console task manager that stores data in SQL Server.

**Topics:** ADO.NET, database connections, SQL queries, and CRUD operations.

**Difficulty:** intermediate. Requires knowledge of classes, exception handling, SQL, and database access from C#.

## Assignment

- Store each task's name, importance from 1 to 5, and due date.
- Display tasks according to importance and urgency: important tasks first, then urgent tasks.
- Support adding, deleting, and editing tasks.
- Include an SQL script that creates the database schema.

## Project Files

- `Program.cs` — the original implementation with database access and console interface classes.
- `ADO NET HW.csproj` — a .NET Core 3.1 project referencing `System.Data.SqlClient` version 4.8.2.
- `ADO NET HW.sln` — the Visual Studio solution.
- `ADO.NET 1 DB.sql` — the original SQL Server script that creates the database and table.

The source code and project files were copied without changes. The `.vs`, `bin`, and `obj` directories are excluded from the archive.

## Requirements

The project requires build tools for .NET Core 3.1 and access to SQL Server. At startup, the application prompts for the server address, username, and password. The connection string specifies the `TaskManager` database. Queries use the `Information` table with the columns `Id`, `Name`, `Importance`, `Appointment date`, and `Period of execution`.

The database creation script was found in the parent directory of the original project and copied without changes. Run `ADO.NET 1 DB.sql` against SQL Server before starting the application. The build, SQL script, and database operations were not tested when adding the project to the archive.

The standalone `Program.cs` found beside the SQL script differs from the archived project source only in whitespace, so it is not stored as a separate exercise.
