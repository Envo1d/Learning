# Fibonacci Caching Middleware

**Difficulty:** Advanced learning exercise.

**Target:** .NET 5 / ASP.NET Core 5; all supplied projects target `net5.0`.

## Implementation

A custom middleware and singleton cache service calculate and retain Fibonacci values for controller requests.

## Dependencies

Microsoft.VisualStudio.Web.CodeGeneration.Design 5.0.2.

Open the original solution in this directory with compatible .NET SDK/ASP.NET tooling and restore its declared packages. Running requires a compatible ASP.NET Core runtime. Original `Properties/launchSettings.json` and `appsettings*.json` files are included. Use local environment settings for database connections and endpoint addresses where applicable. No deployment was performed.

## Static Review and Material Status

task.txt asks for cached HTTP responses, but the implementation caches numeric Fibonacci results and still invokes the downstream controller on every request. The singleton uses an ordinary Dictionary without concurrent access coordination. Route/query parsing and the Fibonacci result for n=1 need review.

## Archive Notes

Imported from `ASP_HW3.zip` inside the supplied `ASP.7z`. The original solution layout, C# source, Razor views/pages, configuration, launch profiles, migrations, static assets, client libraries, and licenses are preserved without changes and checked against the extracted files using hashes. Assignment-only documents remain text files. Generated `bin`/`obj`, restored packages, `node_modules`, and Visual Studio's `.vs` data are excluded; bundled `wwwroot/lib` runtime assets and their licenses are retained.

The project was classified through static inspection. It was not built or run; database migrations and scripts were not executed. Review notes are not an exhaustive correctness audit, and no source corrections were applied.

