# Northwind Products with LINQ to SQL

A C# console exercise that queries the Northwind database and prints product names.

**Topics:** LINQ queries, LINQ to SQL, generated database mappings, and SQL Server access.

**Difficulty:** intermediate. Requires familiarity with classes, collections, LINQ, and relational databases. The application performs a single read query; the larger database model is generated code.

## Behavior

`Program.cs` creates a `DataClasses1DataContext` with an explicit SQL Server connection string, selects all products with a LINQ query, materializes the results with `ToList()`, and prints each `ProductName`. It then waits for console input.

The application uses the LINQ to SQL model in `DataClasses1.dbml`. The project also references Entity Framework 6.2.0, but the query in `Program.cs` uses the generated LINQ to SQL context.

## Project Files

- `Program.cs` — the product query and console output.
- `DataClasses1.dbml` — Northwind table and relationship mappings.
- `DataClasses1.designer.cs` — generated data context and entity classes.
- `DataClasses1.dbml.layout` — database designer layout.
- `Entity1.csproj` and `Entity1.sln` — the .NET Framework 4.7.2 project and Visual Studio solution.
- `packages.config` — Entity Framework 6.2.0 and its Russian localization package.
- `App.config` — connection strings, runtime settings, and Entity Framework configuration.
- `Properties/` — assembly metadata and generated application settings referenced by the project.

## Requirements

Use Windows build tools with support for .NET Framework 4.7.2. Open `Entity1.sln` in Visual Studio and restore the NuGet packages listed in `packages.config`. The project expects restored packages in its local `packages` directory.

Running the example requires a SQL Server instance with the Northwind database and a compatible schema. The original files contain machine-specific connection settings and embedded SQL credentials. `Program.cs` supplies its own connection string, so changing only `App.config` will not change the connection used by `Main`. A local setup requires connection settings that match the intended server.

## Archive Notes

All eight supplied files and the three supporting files in `Properties/` were copied without changes. The `.vs`, `bin`, `obj`, and restored `packages` directories are excluded. No database creation script or separate assignment statement was included. The description is based on the implementation; the project was not built or connected to a database when archived.
