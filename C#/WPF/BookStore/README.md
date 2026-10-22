# Book Store with Entity Framework

**Difficulty:** Advanced learning project.

**Target:** .NET Framework 4.7.2 WPF.

## Implementation

Display books with titles, cover images, and prices, perform a purchase action, and expose login and administration windows for adding and deleting books. Custom XAML dictionaries style buttons and lists.

## Requirements and Static Review Notes

Restore EntityFramework 6.4.4. BookDbContext stores books through EF6; database access depends on App.config and the configured/default EF connection. The archive includes four interface images, but book covers are loaded from model-provided absolute locations. Buying removes the selected book from the database. Task.txt also requests purchase history, which is not established merely by the presence of that requirement. Database schema creation and admin authorization behavior were not tested.

Open the original solution in this directory with Visual Studio on Windows and build tools for the declared target. Restore any dependencies listed in the original project or packages.config. Preserve adjacent XAML, code-behind, properties, resources, and configuration. A compatible runtime and any external database or data files are needed to run the application.

## Archive Notes

Imported from `Wpf4.7z` inside the supplied `WPF.zip`. All original solution/project files, C# source, XAML, supplied user settings, properties, configuration, included resources, SQL, and assignment documents were copied without changes and checked against the extracted originals using file hashes. Generated `bin`/`obj`, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment prose remains in its original text format and encoding.

This description is based on static inspection, not a full correctness audit. The project was not built or run, database scripts were not executed, and no source fixes were applied.

