# Calculator Commands, Input Filters, and Routed Events

**Difficulty:** Intermediate.

**Target:** .NET 5 WPF.

## Implementation

A calculator variant using RoutedCommand bindings and window resources, with separate windows for uppercase-only input, numeric input, and nested buttons whose colors change through routed click events.

## Requirements and Static Review Notes

The original solution/project names remain Wpf1.sln and Wpf1.csproj. task.txt uses Windows-1251 encoding and is preserved unchanged. The uppercase filter checks the Shift modifier rather than validating resulting text, and the numeric filter examines key names; paste, Caps Lock, and other input paths warrant review. Each extra XAML window remains in the project; no startup changes were made.

Open the original solution in this directory with Visual Studio on Windows and build tools for the declared target. Restore any dependencies listed in the original project or packages.config. Preserve adjacent XAML, code-behind, properties, resources, and configuration. A compatible runtime and any external database or data files are needed to run the application.

## Archive Notes

Imported from `Wpf6.7z` inside the supplied `WPF.zip`. All original solution/project files, C# source, XAML, supplied user settings, properties, configuration, included resources, SQL, and assignment documents were copied without changes and checked against the extracted originals using file hashes. Generated `bin`/`obj`, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment prose remains in its original text format and encoding.

This description is based on static inspection, not a full correctness audit. The project was not built or run, database scripts were not executed, and no source fixes were applied.

