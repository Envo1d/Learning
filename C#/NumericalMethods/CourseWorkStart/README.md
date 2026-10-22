# Differential Equation Calculator

A solution containing numerical methods for first-order differential equations and a WPF interface for entering a function, initial conditions, interval, and step, then displaying calculation tables and a chart.

**Topics:** numerical integration, expression evaluation, reusable calculation classes, project references, WPF/XAML, and charting.

**Difficulty:** advanced learning project. Combines mathematical algorithms, expression parsing, desktop controls, tabular output, and visualization.

## Projects and Files

The original solution structure and relative project references are preserved:

```text
CourseWorkStart.sln
CourseWorkStart/
    CourseWorkStart.csproj
    Program.cs
    ImprovedEilerMethod.cs
    RungeKuttaMethod.cs
Calculator/
    Calculator.csproj
    Calculator.csproj.user
    App.xaml
    App.xaml.cs
    AssemblyInfo.cs
    MainWindow.xaml
    MainWindow.xaml.cs
    Fonts/Dosis.ttf
    Images/Logo.png
```

- `CourseWorkStart` targets `net5.0`. It includes improved Euler and fourth-order Runge-Kutta implementations, stores intermediate calculation values, and evaluates function expressions with `CoreCLR-NCalc` 2.2.92. Its console entry point runs a sample Runge-Kutta calculation; the Euler example is commented out.
- `Calculator` targets `net5.0-windows` with WPF enabled. It references the calculation project and `LiveCharts.Wpf.Core` 0.9.8. Its interface selects the method and displays iteration tables and a chart. The bundled font and logo are included as resources.

## Opening and Running

Open `CourseWorkStart.sln` in Visual Studio with support for .NET 5 and WPF on Windows, and restore the packages declared in both project files. Select `Calculator` as the startup project for the graphical interface, or `CourseWorkStart` for the console example. A compatible runtime is required to run either application.

## Static Review Notes

- In `MainWindow.xaml.cs`, the expression fallback for both the step and initial-y inputs assigns the evaluated value to `end`, rather than to `step` or `startY`. This can alter the interval and leave the intended value at zero.
- The calculation loops do not validate a positive step or impose an iteration limit. A zero or unsuitable step can prevent progress toward the interval end.
- Both methods use `Math.Round(x, 2)` in the interval termination check, which warrants review for small steps or precise interval boundaries.
- The chart maps x coordinates through a base-10 logarithm. Nonpositive x values require review before using this visualization.

These observations are from static inspection, not a complete numerical or application audit. The source is preserved without corrections.

## Archive Notes

Both projects, their solution, supplied user settings, XAML, source files, font, and logo were copied without changes and verified against the originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

The solution was not built or run, and numerical accuracy and chart behavior were not tested when adding it to the archive.
