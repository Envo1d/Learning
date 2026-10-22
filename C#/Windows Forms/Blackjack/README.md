# Blackjack

**Topics:** Windows Forms, desktop events and application state.

**Difficulty:** Intermediate.

**Target:** .NET Framework 4.7.2 Windows Forms.

## Exercise and Implementation

A graphical card game with play, hit, and stand actions, card images, point calculations, and round state.

## Requirements and Material Status

The original solution is named WinformsLesson02.sln and its project remains under WinformsLesson02/. Includes all 53 card/back images in the project's Images directory. Their relative paths must resolve from the runtime working directory. Game rules and scoring were not validated.

Open the original `.sln` in this directory with Visual Studio on Windows and build tools for the declared target framework. Keep the project structure and supporting files together. Runtime image/XML paths are relative to the working directory unless the code specifies otherwise. Any database or external file requirements must be prepared separately.

## Archive Notes

The project explicitly references `WinformsLesson02/bin/Debug/Azure.png` as a content asset. This image is therefore retained at that original path as an exception to excluding generated build directories; executable and intermediate build outputs are not included.

Imported from `BlackJack` inside the supplied `WinForms.7z` archive. The original solution, project, C# source, designer files, form resources, properties, configuration, supplied user settings, and included data/assets were copied without changes and checked using file hashes. Generated `bin`/`obj` directories, restored `packages`, and Visual Studio's `.vs` data are excluded. Assignment-only documents retain their original text format and encoding.

The source was inspected for classification. The project was not built or run, and behavior and correctness were not exhaustively verified.

