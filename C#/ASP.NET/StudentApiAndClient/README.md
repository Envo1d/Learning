# Student REST API and Web Client

**Difficulty:** Advanced learning project.

**Target:** .NET 5 / ASP.NET Core 5; all supplied projects target `net5.0`.

## Implementation

A three-project solution containing a student CRUD API, shared DataModels library, and Razor Pages frontend. The API uses a repository with EF Core; the frontend communicates through HTTP and client assets, with CORS configured on the API.

## Dependencies

API: EF Core, SQL Server provider, and EF tools 5.0.10. Front and DataModels declare no explicit package references.

Open the original solution in this directory with compatible .NET SDK/ASP.NET tooling and restore its declared packages. Running requires a compatible ASP.NET Core runtime. Original `Properties/launchSettings.json` and `appsettings*.json` files are included. Use local environment settings for database connections and endpoint addresses where applicable. No deployment was performed.

## Static Review and Material Status

The original solution name is Api.sln. Both Api and Front reference DataModels through relative paths. Configure the API database and frontend ApiUrl to match local launch addresses, and use the supplied migrations for the schema. API routes use api/v1/Students; the POST Created location uses the singular student path and needs review. CORS allows any origin/method/header as supplied. HW 6 (API).txt and HW 7 (Front).txt preserve both assignment stages.

## Archive Notes

Imported from `ASPHW6.zip` inside the supplied `ASP.7z`. The original solution layout, C# source, Razor views/pages, configuration, launch profiles, migrations, static assets, client libraries, and licenses are preserved without changes and checked against the extracted files using hashes. Assignment-only documents remain text files. Generated `bin`/`obj`, restored packages, `node_modules`, and Visual Studio's `.vs` data are excluded; bundled `wwwroot/lib` runtime assets and their licenses are retained.

The project was classified through static inspection. It was not built or run; database migrations and scripts were not executed. Review notes are not an exhaustive correctness audit, and no source corrections were applied.

