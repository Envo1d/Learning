# Learning

A personal programming archive of homework, university assignments, notes, exercises, and small applications. It records my learning across languages and technologies and serves as a reference for revisiting topics and practicing them again.

The repository contains independent examples and projects, including unfinished exercises and commented-out solutions. It is not a single application, and there is no repository-wide build or test command.

## Repository Sections

| Section | Contents |
| --- | --- |
| [C++](%D0%A1%2B%2B/README.md) | Console fundamentals, arrays, functions, recursion, pointers, strings, structures, OOP, data structures, STL, files, exceptions, design patterns, and numerical methods. |
| [C#](C%23/README.md) | Console exercises, OOP, collections, generics, delegates and events, database access, Windows Forms, WPF, networking, system programming, numerical methods, and ASP.NET Core. |
| [Android](Android/README.md) | Separate Kotlin/Gradle projects covering layouts, activities, navigation, intents, dialogs, and the activity lifecycle. |
| [Go](Go/) | Hello World, a console BMI calculator, a TCP chat, and a book HTTP API exercise. Each project has its own Go module. |
| [HTML & CSS](HTML%20%26%20CSS/) | A login form, background and snow animations, a to-do list, browser JavaScript, and LESS examples. |
| [JavaScript](JavaScript/) | Notes and examples on syntax, functions, objects, classes, arrays, strings, built-in objects, promises, async/await, algorithms, and data structures. |
| [Node.js](Node/) | A static-file HTTP server, Jest testing exercises, and a React/TypeScript starter using Vite, Sass, and ESLint. |
| [SQL](PostgreSQL/) | Table definitions, CRUD, filtering, grouping, joins, subqueries, functions, views, procedures, and triggers. Check each file's SQL dialect before running it. |

The C++ directory starts with the Cyrillic letter `С`. The SQL directory is named `PostgreSQL`, but many examples use SQL Server / T-SQL syntax, including `GO`, `USE`, `IDENTITY`, and `NVARCHAR`.

## C# Project Areas

Standalone exercises use descriptive `.cs` filenames grouped by topic. Complete applications retain their solution/project files and related source, configuration, views, and resources.

| Area | Examples |
| --- | --- |
| [ADO.NET](C%23/ADO.NET/) and [LINQ to SQL](C%23/LINQ%20to%20SQL/) | Task management, database-driven menus, coffee and produce catalogs, and Northwind queries. |
| [Windows Forms](C%23/Windows%20Forms/) | Product accounting, a task planner, file explorers, a test editor, car catalogs, keyword highlighting, and Blackjack. |
| [WPF](C%23/WPF/README.md) | Calculators, an image viewer, input and binding exercises, book and car catalogs, asynchronous database queries, and a profile editor. |
| [Networking](C%23/Networking/) | Chat clients and servers, screenshot transfer over UDP, and distinct network tic-tac-toe implementations. |
| [System Programming](C%23/SystemProgramming/README.md) | Threads, dynamic assemblies, Windows hooks, synchronization with Monitor and Mutex, and task cancellation. |
| [ASP.NET Core](C%23/ASP.NET/README.md) | MVC, sessions, caching middleware, Entity Framework Core, Razor Pages, image uploads, and a student REST API with a web client. |
| [Algorithms](C%23/Algorithms/) and [Numerical Methods](C%23/NumericalMethods/) | Analytic Hierarchy Process and differential-equation calculations using improved Euler and Runge-Kutta methods. |

## Difficulty Guide

Difficulty depends on the individual exercise and the knowledge it requires.

| Level | Typical prerequisites |
| --- | --- |
| Beginner | Syntax, console input/output, conditions, loops, simple functions, and basic array/string operations. |
| Intermediate | Classes, composition, inheritance, collections, recursion, generics, SQL joins, DOM interaction, and testing. |
| Advanced learning level | Combining several topics, networking, concurrency, synchronization, APIs, database-backed applications, and numerical algorithms with a UI. |

Section and project READMEs provide more specific classifications and material status where available.

## Working with the Archive

1. Choose one exercise or project and read its local README and configuration, such as `package.json`, `go.mod`, `.csproj`, or Gradle files.
2. Prepare the tools and dependencies required by that specific project. Older examples may target older frameworks or depend on Windows, SQL Server, Microsoft Office, or external input files.
3. Open a complete solution/project with its supporting files. For a standalone `.cpp` or `.cs` exercise, use a separate compatible project; many examples define their own entry point and reuse class names.
4. Run only the selected example and its relevant checks. Review included SQL scripts and local configuration before using a database project.

Some folders contain multiple implementations of the same assignment. These variants are retained separately when their code or structure differs. Assignment-only documents remain text files, while source examples use their language's file extension.

## Material Status

This is a learning archive rather than a collection of validated reference solutions. Some exercises contain known issues, incomplete features, missing input data, or environment-specific dependencies. Project READMEs record relevant observations; the presence of a project does not imply that it builds or runs successfully.
