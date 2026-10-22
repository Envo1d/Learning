# Image Viewer with Registration and Metadata

**Difficulty:** Advanced learning exercise.

**Target:** .NET Framework 4.7.2 WPF.

## Implementation

An image viewer with registration/login dialogs, directory selection, image navigation, metadata display, and editable Windows Shell image ratings.

## Requirements and Static Review Notes

Restore WindowsAPICodePack-Core and WindowsAPICodePack-Shell 1.1.1 from packages.config. The application creates working-directory files named usrinfo and path; credentials are saved as plain text. Images come from a user-selected directory and are not bundled. Folder enumeration is not restricted to image formats, and empty/non-image folders need review. Image rating changes write file metadata.

Open the original solution in this directory with Visual Studio on Windows and build tools for the declared target. Restore any dependencies listed in the original project or packages.config. Preserve adjacent XAML, code-behind, properties, resources, and configuration. A compatible runtime and any external database or data files are needed to run the application.

## Archive Notes

Imported from `Wpf2.7z` inside the supplied `WPF.zip`. All original solution/project files, C# source, XAML, supplied user settings, properties, configuration, included resources, SQL, and assignment documents were copied without changes and checked against the extracted originals using file hashes. Generated `bin`/`obj`, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment prose remains in its original text format and encoding.

This description is based on static inspection, not a full correctness audit. The project was not built or run, database scripts were not executed, and no source fixes were applied.

