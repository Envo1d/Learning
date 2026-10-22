# Network Tic-Tac-Toe: Player and Board State Variant

A Windows Forms network tic-tac-toe exercise, preserved separately from [Net_HW3](../Net_HW3/) and [TicTacToe](../TicTacToe/).

**Topics:** UDP peer discovery, TCP messaging, asynchronous operations, desktop events, player modeling, and board state representation.

**Difficulty:** advanced learning exercise. Combines networking, background operations, game rules, and a desktop interface.

## Differences from the Other Variants

- Targets `net6.0-windows` and references `SuperSimpleTcp` version 3.0.13, like `TicTacToe`.
- Keeps the main gameplay and networking implementation in the `Game` form rather than a separate `Core/Game.cs` class.
- Introduces a `Player` class storing the figure image path and a list of selected cells.
- Uses a nine-element `Boxes` array to distinguish local moves (`1`) from opponent moves (`2`); winning combinations are checked against this array.
- Includes two Visual Studio class diagrams.

Players discover each other through UDP, establish host/client roles, and exchange moves and win notifications over TCP. This is a distinct implementation; no claim is made about its chronological order or correctness relative to the other variants.

## Project Files

- `tic-toc-toe.sln` — the Visual Studio solution.
- `tic-toc-toe.csproj` and `tic-toc-toe.csproj.user` — the project and supplied user settings.
- `Program.cs` — the application entry point.
- `Game.cs`, `Game.Designer.cs`, and `Game.resx` — the main form and its resources.
- `Player.cs` — player data and reset logic.
- `ClassDiagram1.cd` and `ClassDiagram2.cd` — class diagrams.
- `Assets/` — circle and cross images used by the form.

## Requirements

Open `tic-toc-toe.sln` in Visual Studio with build tools supporting .NET 6 Windows Forms and restore the declared NuGet dependency. Running requires Windows and a compatible .NET runtime.

The project copies `Assets/circle.png` and `Assets/cross.png` to the output directory. The form loads images from `./Assets` relative to its working directory, so use the output directory as the working directory when launching the application. Network communication requires two peers and suitable local network settings for the discovery and TCP connection code in `Game.cs`.

## Archive Notes

Original source, project, solution, user settings, diagrams, and assets were copied without changes and checked against the originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

This description is based on the implementation. The project was not built or run, and networking and game correctness were not tested when adding it to the archive.
