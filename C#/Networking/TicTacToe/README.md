# TicTacToe

A Windows Forms network tic-tac-toe exercise, preserved as a separate variant of [Net_HW3](../Net_HW3/).

**Topics:** UDP discovery, TCP communication, asynchronous operations, cancellation, events, and organizing game logic separately from form code.

**Difficulty:** advanced learning exercise. Combines networking, background operations, game state, and a desktop interface.

## Differences from Net_HW3

- Targets `net6.0-windows` instead of `net5.0-windows`.
- References `SuperSimpleTcp` version 3.0.13 instead of 2.4.1.2.
- Moves game and networking operations into `Core/Game.cs`; the form calls methods such as `Step`, `Connect`, and `EndGame`.
- Uses `ApplicationConfiguration.Initialize()` at startup.

Both variants use UDP to find another player and TCP to exchange game moves. This version is stored separately because its implementation differs substantially from the archived `Net_HW3` project. No assumption is made that either version is fully working.

## Project Files

- `TicTacToe.sln` — the Visual Studio solution.
- `TicTacToe.csproj` and `TicTacToe.csproj.user` — the project and supplied user settings.
- `Program.cs` — the application entry point.
- `Form1.cs`, `Form1.Designer.cs`, and `Form1.resx` — the game form and its resources.
- `Core/Game.cs` — game state, win checks, peer discovery, and TCP connection operations.
- `Assets/circle.png` and `Assets/cross.png` — player images.

## Requirements

Open `TicTacToe.sln` in Visual Studio with build tools supporting .NET 6 Windows Forms, and restore the declared NuGet package. Running the application requires Windows and a compatible .NET runtime.

The original code uses UDP port `10102`, broadcast address `192.168.0.255`, and TCP port `5000`. Two peers need a compatible local network with the required ports available. A different subnet may require adapting the embedded broadcast address.

Images are loaded from `./Assets` relative to the working directory. The project copies the images to the output directory; use that directory as the application's working directory.

## Archive Notes

All original project, solution, source, settings, and asset files were copied without changes and verified against the originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original directory is preserved.

This description is based on the implementation. The project was not built or run, and network communication and game correctness were not tested when adding it to the archive.
