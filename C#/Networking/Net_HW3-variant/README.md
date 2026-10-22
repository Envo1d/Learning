# Network Tic-Tac-Toe: Separate Net_HW3 Snapshot

A two-player Windows Forms game with UDP peer discovery and TCP communication, preserved as a distinct snapshot from [the previously archived Net_HW3](../Net_HW3/).

**Topics:** asynchronous networking, UDP broadcasts, TCP client/server roles, events, cancellation, console-free desktop interaction, and game state.

**Difficulty:** advanced learning exercise. Combines networking, background tasks, user interface updates, and game rules.

## Differences from the Existing Snapshot

- `Form1.cs` declares additional `EndPoint` and `Game` properties.
- Some exception handlers name their exception variable.
- The client-disconnection handler stops and disposes the TCP server without the existing snapshot's `IsListening` guard.
- The supplied source directory has no `Core/` directory, while the existing archived snapshot contains four additional classes there.

The other eight supplied files match their counterparts in the existing snapshot. Both snapshots are retained without modifying their source. Their chronological order and relative correctness have not been established.

## Structure

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
```

## Requirements

The project targets `net5.0-windows`, enables Windows Forms, and references `SuperSimpleTcp` 2.4.1.2. Open `Net_HW3.sln` in Visual Studio on Windows with suitable build tools, restore its NuGet dependency, and use a compatible runtime.

Discovery uses UDP port `10102` and the embedded broadcast address `192.168.0.255`; the host assigns TCP port `5000`. Two peers need compatible local network settings. The form loads player images from `./Assets`, so launch with the output directory as the working directory. The project copies both images there.

## Archive Notes

All nine supplied solution, project, source, user-settings, and asset files were copied without changes and verified against their originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory and the existing archived snapshot are preserved.

The project was not built or run, and networking and game correctness were not tested when archived.
