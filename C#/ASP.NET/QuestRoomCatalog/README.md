# Quest Room Catalog

**Difficulty:** Advanced learning exercise.

**Target:** .NET 5 / ASP.NET Core 5; all supplied projects target `net5.0`.

## Implementation

An MVC catalog backed by Entity Framework Core and SQL Server, with a repository for lists/details and filters for difficulty, player count, and fear level.

## Dependencies

EF Core, SQL Server provider, and EF tools 5.0.9; web code-generation design package 5.0.2.

Open the original solution in this directory with compatible .NET SDK/ASP.NET tooling and restore its declared packages. Running requires a compatible ASP.NET Core runtime. Original `Properties/launchSettings.json` and `appsettings*.json` files are included. Use local environment settings for database connections and endpoint addresses where applicable. No deployment was performed.

## Static Review and Material Status

Includes the original EF migration, model snapshot, entity models, and Task.txt. Prepare a SQL Server database consistent with the supplied migrations and connection settings. Filter projections omit Id in some repository methods, which can affect detail links. Repository and UI behavior were not executed.

## Archive Notes

Imported from `ASP_HW4.zip` inside the supplied `ASP.7z`. The original solution layout, C# source, Razor views/pages, configuration, launch profiles, migrations, static assets, client libraries, and licenses are preserved without changes and checked against the extracted files using hashes. Assignment-only documents remain text files. Generated `bin`/`obj`, restored packages, `node_modules`, and Visual Studio's `.vs` data are excluded; bundled `wwwroot/lib` runtime assets and their licenses are retained.

The project was classified through static inspection. It was not built or run; database migrations and scripts were not executed. Review notes are not an exhaustive correctness audit, and no source corrections were applied.

