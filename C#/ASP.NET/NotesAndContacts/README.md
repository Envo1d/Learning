# MVC Notes and Contacts

**Difficulty:** Intermediate.

**Target:** .NET 5 / ASP.NET Core 5; all supplied projects target `net5.0`.

## Implementation

An ASP.NET Core MVC exercise for adding/deleting notes and contacts, displaying collections through Razor views, and exporting/importing records through files.

## Dependencies

No explicit NuGet package references.

Open the original solution in this directory with compatible .NET SDK/ASP.NET tooling and restore its declared packages. Running requires a compatible ASP.NET Core runtime. Original `Properties/launchSettings.json` and `appsettings*.json` files are included. Use local environment settings for database connections and endpoint addresses where applicable. No deployment was performed.

## Static Review and Material Status

Uses static model collections and file storage under wwwroot/Files. The empty Files directory is preserved. Uploaded and requested filenames are used in filesystem operations and need validation review. Static collections are shared across requests; the implementation is not a per-user persistent store.

## Archive Notes

Imported from `ASP_HW1.zip` inside the supplied `ASP.7z`. The original solution layout, C# source, Razor views/pages, configuration, launch profiles, migrations, static assets, client libraries, and licenses are preserved without changes and checked against the extracted files using hashes. Assignment-only documents remain text files. Generated `bin`/`obj`, restored packages, `node_modules`, and Visual Studio's `.vs` data are excluded; bundled `wwwroot/lib` runtime assets and their licenses are retained.

The project was classified through static inspection. It was not built or run; database migrations and scripts were not executed. Review notes are not an exhaustive correctness audit, and no source corrections were applied.

