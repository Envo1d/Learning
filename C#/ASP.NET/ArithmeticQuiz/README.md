# Session-Based Arithmetic Quiz

**Difficulty:** Intermediate.

**Target:** .NET 5 / ASP.NET Core 5; all supplied projects target `net5.0`.

## Implementation

An MVC arithmetic quiz with generated addition/subtraction questions, session-based answer history, skipped answers, scores, and result views. Result storage is injected through ISaver.

## Dependencies

No explicit NuGet package references.

Open the original solution in this directory with compatible .NET SDK/ASP.NET tooling and restore its declared packages. Running requires a compatible ASP.NET Core runtime. Original `Properties/launchSettings.json` and `appsettings*.json` files are included. Use local environment settings for database connections and endpoint addresses where applicable. No deployment was performed.

## Static Review and Material Status

Tasker stores the current question, counter, and correct answer in static properties, so different sessions share quiz state despite storing answers in Session. The in-memory score dictionary and missing-session paths require review. The timer is part of the supplied interface and was not validated.

## Archive Notes

Imported from `ASP_HW2.zip` inside the supplied `ASP.7z`. The original solution layout, C# source, Razor views/pages, configuration, launch profiles, migrations, static assets, client libraries, and licenses are preserved without changes and checked against the extracted files using hashes. Assignment-only documents remain text files. Generated `bin`/`obj`, restored packages, `node_modules`, and Visual Studio's `.vs` data are excluded; bundled `wwwroot/lib` runtime assets and their licenses are retained.

The project was classified through static inspection. It was not built or run; database migrations and scripts were not executed. Review notes are not an exhaustive correctness audit, and no source corrections were applied.

