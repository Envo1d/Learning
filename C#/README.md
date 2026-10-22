# C#

C# programming exercises and examples.


## WinForms Archive Projects

The following projects were imported from the nested archives in `WinForms.7z`. Their original solution and project names are retained inside descriptive topic directories.

| Topic | Project | Difficulty |
| --- | --- | --- |
| Windows Forms | [Mouse-Drawn Labels](Windows%20Forms/MouseLabels/) | Intermediate |
| Windows Forms | [Fuel Station and Cafe Calculator](Windows%20Forms/FuelStation/) | Intermediate |
| Windows Forms | [XML Test Editor](Windows%20Forms/TestEditor/) | Intermediate |
| Windows Forms | [Car Dealership Catalog](Windows%20Forms/CarCatalog/) | Intermediate |
| ADO.NET and Windows Forms | [Database-Driven Dynamic Menu](ADO.NET/DynamicMenu/) | Advanced learning exercise |
| Windows Forms | [TreeView File Explorer](Windows%20Forms/FileExplorerTree/) | Intermediate |
| Windows Forms | [TreeView and ListView File Explorer](Windows%20Forms/FileExplorerList/) | Advanced learning exercise |
| Windows Forms | [C# Keyword Highlighter](Windows%20Forms/CSharpHighlighter/) | Intermediate |
| ADO.NET and Windows Forms | [Coffee Catalog with ADO.NET](ADO.NET/CoffeeCatalog/) | Intermediate |
| ADO.NET and Windows Forms | [Fruit and Vegetable Database Viewer](ADO.NET/ProduceCatalog/) | Advanced learning exercise |
| Windows Forms | [Blackjack](Windows%20Forms/Blackjack/) | Intermediate |
| Windows Forms | [Task Planner Examination Project](Windows%20Forms/TaskPlanner/) | Advanced learning project |

## System Programming Archive

The [System Programming section](SystemProgramming/) contains four solutions from `System.7z`: thread control, dynamic cipher assemblies, Windows hooks and Monitor synchronization, and mutex-based file exchange with cancelable tasks. Difficulty is advanced learning level overall; the independent ProgressBar exercise is intermediate. The original nine projects and their supporting files are preserved with English descriptions and static review notes.

## WPF Archive Projects

The [WPF section](WPF/) contains eight solutions from `WPF.zip`: an event-driven calculator, an image viewer, a feedback form, a book store, a car catalog, calculator commands and input exercises, asynchronous database queries, and a user-profile editor. Each has an English README with difficulty, dependencies, and material status. Source and resources are preserved without corrections, including incomplete examples.

## ASP.NET Core Archive

The [ASP.NET section](ASP.NET/) contains six solutions and eight projects from `ASP.7z`: notes and contacts, an arithmetic quiz, Fibonacci caching middleware, a quest-room catalog, Razor Pages image hosting, and a student REST API with a separate frontend and shared models. English READMEs record difficulty, dependencies, and static review findings. Original source, migrations, Razor templates, configuration, and frontend assets are preserved.

## Opening and Running Examples

The standalone homework files were archived as `.cs` files with descriptive names, following the C++ section's organization. Their contents, including assignment comments and commented-out solutions, are preserved without changes. The table retains the original homework numbers for reference; no HW 11 file was supplied.

Treat each standalone `.cs` file as a separate exercise. Many define their own entry point and reuse class or namespace names, so do not combine the entire archive into one project. No project file or target framework was supplied for these standalone exercises. To experiment, include the selected file in a separate compatible console project and avoid a second generated entry point. Existing complete projects retain their original project files and requirements.

## Material Status and Review Notes

- HM 1 contains a commented-out deposit simulation and an active repeated-number exercise. The deposit loop stops at `>= 2000` instead of strictly exceeding 2000, and its `byte` month counter has a limited range.
- HM 2 uses upper-exclusive `Random.Next` bounds, so 100 is not generated. Matrix row input is not checked against the array bounds.
- HW 3 requests Unicode uppercase extraction, but its implementation selects only ASCII A-Z. The Roman numeral input condition also accepts negative values.
- HW 4 does not check for a missing title before indexing in `FindBook`.
- HW 5 uses numeric apartment numbers despite the statement specifying strings; its apartment array is static and shared by House instances.
- HW 6 has incorrect reverse subtraction/division overloads and an inequality operator that is not the complement of equality. Floating-point conversion depends on a comma decimal separator.
- HW 7 implements six progressively extended payroll reports. Rates and currency examples belong to the historical assignment.
- HW 8 contains both geometry calculations and console drawing. Drawing uses Windows APIs from `user32.dll` and `kernel32.dll` and requires a suitable Windows console.
- HW 9 reads `words.txt` and uses a recovery file named `data`; neither was supplied. The interface can create recovery data. Parsing depends on hyphen-separated pairs, carriage returns, and the default encoding.
- HW 10 combines generic point/line models with a dictionary-based word counter and iterator.
- HW 12 uses Windows APIs for console graphics. It accesses the first two cars before checking the list size, and delegate subscriptions persist between races.
- HW 13 requires `alice.txt.gz` in the working directory; it was not supplied. Printing assumes at least ten distinct qualifying words.

These notes are based on static inspection and are not an exhaustive correctness audit. Renaming files does not imply that the solutions were compiled or validated. The code has not been corrected or run as part of archiving.
