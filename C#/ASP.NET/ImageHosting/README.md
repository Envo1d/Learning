# Razor Pages Image Hosting

**Difficulty:** Advanced learning project.

**Target:** .NET 5 / ASP.NET Core 5; all supplied projects target `net5.0`.

## Implementation

A Razor Pages application with image uploads, related tags, index/filtering/pagination code, and administration/deletion pages. Uploaded file content is stored with database entities.

## Dependencies

Microsoft.EntityFrameworkCore 5.0.10, SQL Server provider and EF tools 5.0.9, and web code-generation design package 5.0.2. Original mixed package versions are preserved.

Open the original solution in this directory with compatible .NET SDK/ASP.NET tooling and restore its declared packages. Running requires a compatible ASP.NET Core runtime. Original `Properties/launchSettings.json` and `appsettings*.json` files are included. Use local environment settings for database connections and endpoint addresses where applicable. No deployment was performed.

## Static Review and Material Status

Includes entity models, migrations, snapshot, and task.txt. Requires SQL Server with matching schema and local connection settings. The presence of an Admin page does not establish access control. Upload type/size validation and deletion behavior were not exhaustively reviewed. Database initialization and migrations were not executed.

## Archive Notes

Imported from `ASP_HW5.zip` inside the supplied `ASP.7z`. The original solution layout, C# source, Razor views/pages, configuration, launch profiles, migrations, static assets, client libraries, and licenses are preserved without changes and checked against the extracted files using hashes. Assignment-only documents remain text files. Generated `bin`/`obj`, restored packages, `node_modules`, and Visual Studio's `.vs` data are excluded; bundled `wwwroot/lib` runtime assets and their licenses are retained.

The project was classified through static inspection. It was not built or run; database migrations and scripts were not executed. Review notes are not an exhaustive correctness audit, and no source corrections were applied.

