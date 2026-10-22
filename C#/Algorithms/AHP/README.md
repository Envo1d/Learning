# Analytic Hierarchy Process (AHP)

A C# console exercise implementing a hierarchy of criteria and alternatives with interactive pairwise comparisons.

**Topics:** classes, collections, hierarchical data models, matrix calculations, and multicriteria decision analysis.

**Difficulty:** advanced learning exercise. Combines object modeling, nested collections, numerical calculations, and an interactive console workflow.

## Example

The program defines economic, environmental, and social criteria, each with three subcriteria. It evaluates three alternatives: New Factory, Old Factory, and Modernization.

The application prints the hierarchy, prompts for pairwise comparison matrices, calculates local priorities using normalized geometric means, checks matrix consistency against a threshold of 0.10, and computes global criteria weights and final alternative scores. A failed check produces `Matrix Error`.

## Project Files

- `Program.cs` — defines the example hierarchy and calculation sequence.
- `Level.cs` — groups components and connects hierarchy levels.
- `Component.cs` — groups criteria and connects parent and child components.
- `Criteria.cs` — stores criterion titles, priorities, and alternative scores.
- `Operations.cs` — handles console input, matrix calculations, consistency checks, and final scores.
- `AHP.csproj` — a .NET 6 console project with implicit usings and nullable reference types enabled; no explicit package references.

## Running

With an SDK capable of building `net6.0` and a compatible runtime, run this command from the project directory:

```powershell
dotnet run --project AHP.csproj
```

Use an interactive terminal: the input routine adjusts the console cursor position. Enter matrix values when prompted. Negative inputs are converted to reciprocals of their absolute values; for example, `-3` becomes `1/3`. Decimal parsing follows the current system culture.

## Archive Notes

All six original files were copied without changes. Generated `bin` and `obj` directories are excluded. No separate assignment statement was provided; this description is based on the implementation. The project was not built or run, and numerical correctness was not verified when adding it to the archive.
