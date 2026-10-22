# Event-Driven Calculator

**Difficulty:** Intermediate.

**Target:** .NET 5 WPF.

## Implementation

A desktop calculator with numeric entry, arithmetic operations, clear/backspace controls, sign/decimal handling, and display resizing.

## Requirements and Static Review Notes

The implementation is driven by button events and stores calculation state in the window. Decimal entry explicitly inserts a comma, so numeric parsing should be reviewed for the current culture. Preserved separately from the command-based calculator.

Open the original solution in this directory with Visual Studio on Windows and build tools for the declared target. Restore any dependencies listed in the original project or packages.config. Preserve adjacent XAML, code-behind, properties, resources, and configuration. A compatible runtime and any external database or data files are needed to run the application.

## Archive Notes

Imported from `Wpf1.7z` inside the supplied `WPF.zip`. All original solution/project files, C# source, XAML, supplied user settings, properties, configuration, included resources, SQL, and assignment documents were copied without changes and checked against the extracted originals using file hashes. Generated `bin`/`obj`, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment prose remains in its original text format and encoding.

This description is based on static inspection, not a full correctness audit. The project was not built or run, database scripts were not executed, and no source fixes were applied.

