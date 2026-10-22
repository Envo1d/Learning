# Network Tic-Tac-Toe

A two-player Windows Forms game with UDP peer discovery and TCP communication.

**Topics:** UDP broadcasts, TCP clients and servers, asynchronous operations, cancellation, events, and updating a desktop interface from background tasks.

**Difficulty:** advanced learning exercise. Combines networking, concurrent operations, user interface state, and game logic.

## Behavior

The main form searches for another player through UDP messages, assigns host/client roles, and exchanges the TCP port. The host starts a `SimpleTcpServer`, while the other player connects with a `SimpleTcpClient`. Players exchange byte messages for board moves and game results. The form displays circle/cross images and checks horizontal, vertical, and diagonal winning combinations.

The main gameplay implementation is in `Form1.cs`. The separate `Core/` directory contains additional game, player, client, and network classes, including partial scaffolding, preserved as supplied.

## Archive Structure

```text
Net_HW3.sln
Net_HW3/
    Net_HW3.csproj
    Net_HW3.csproj.user
    Program.cs
    Form1.cs
    Form1.Designer.cs
    Form1.resx
    Assets/
        circle.png
        cross.png
    Core/
        Client.cs
        Game.cs
        Network.cs
        Player.cs
```

## Requirements

The project targets `net5.0-windows` with Windows Forms enabled and references the `SuperSimpleTcp` NuGet package, version 2.4.1.2. Open `Net_HW3.sln` in Visual Studio with suitable Windows/.NET build tools and restore the declared package.

The original discovery code uses UDP port `10102` and the broadcast address `192.168.0.255`; the host assigns TCP port `5000`. Running the example requires two peers on a compatible local network with those ports available. The broadcast address is embedded in the source and may require adaptation for a different subnet.

Images are loaded from `./Assets` relative to the working directory. The project copies both images to the output directory; start the application with that directory as its working directory.

## Archive Notes

The solution, project files, form source and resources, `Assets/`, and `Core/` were copied without changes and verified against the originals using file hashes. The supplied `.csproj.user` file is included. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

This description is based on the implementation. The project was not built or run, and peer discovery, communication, and game correctness were not tested when adding it to the archive.
