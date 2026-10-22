# Asynchronous ADO.NET Query Coordination

**Difficulty:** Advanced learning exercise.

**Target:** .NET Framework 4.7.2 WPF.

## Implementation

Query Authors and Books through asynchronous SqlCommand callbacks, count author-name and book-title characters, and display results in two fields. Artificial delays make the overlap visible.

## Requirements and Static Review Notes

Includes BD.sql and the assignment TextFile1.txt. The original connection string is machine-specific and supplied through the UI; the SQL Server database is AsyncHM and uses MultipleActiveResultSets. The author callback starts the book query but displays both results and closes the connection without waiting for book processing to finish. This does not guarantee the assignment's required completion barrier. Source credentials and configuration are preserved without changes.

Open the original solution in this directory with Visual Studio on Windows and build tools for the declared target. Restore any dependencies listed in the original project or packages.config. Preserve adjacent XAML, code-behind, properties, resources, and configuration. A compatible runtime and any external database or data files are needed to run the application.

## Archive Notes

Imported from `WpfADOAsync.7z` inside the supplied `WPF.zip`. All original solution/project files, C# source, XAML, supplied user settings, properties, configuration, included resources, SQL, and assignment documents were copied without changes and checked against the extracted originals using file hashes. Generated `bin`/`obj`, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment prose remains in its original text format and encoding.

This description is based on static inspection, not a full correctness audit. The project was not built or run, database scripts were not executed, and no source fixes were applied.

