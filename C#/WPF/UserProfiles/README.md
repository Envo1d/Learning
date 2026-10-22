# User Profile and Role Editor

**Difficulty:** Intermediate.

**Target:** .NET 5 WPF.

## Implementation

An examination-style interface with an ObservableCollection of person profiles, department choices, role controls, and profile add/update/delete buttons.

## Requirements and Static Review Notes

The source contains a compile-time mismatch: an object initializer uses Username, while Persone declares UserName. It also attempts to remove an item directly from ListUsers.Items while ItemsSource is set; bound collection changes require review. Presence of role controls does not establish completed role-management behavior. No separate assignment document was included, and the implementation is preserved as an incomplete exercise.

Open the original solution in this directory with Visual Studio on Windows and build tools for the declared target. Restore any dependencies listed in the original project or packages.config. Preserve adjacent XAML, code-behind, properties, resources, and configuration. A compatible runtime and any external database or data files are needed to run the application.

## Archive Notes

Imported from `WpfExam.7z` inside the supplied `WPF.zip`. All original solution/project files, C# source, XAML, supplied user settings, properties, configuration, included resources, SQL, and assignment documents were copied without changes and checked against the extracted originals using file hashes. Generated `bin`/`obj`, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment prose remains in its original text format and encoding.

This description is based on static inspection, not a full correctness audit. The project was not built or run, database scripts were not executed, and no source fixes were applied.

