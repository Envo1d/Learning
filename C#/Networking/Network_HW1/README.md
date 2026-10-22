# Asynchronous Socket Chat

A Windows Forms chat exercise with separate server and client projects using asynchronous stream sockets.

**Topics:** socket connections, asynchronous accept/send/receive operations, background tasks, cancellation, concurrent collections, UTF-8 encoding, and UI updates from background code.

**Difficulty:** advanced learning exercise. Combines client/server communication, connection lifecycle management, multiple clients, and desktop interfaces.

## Assignment and Behavior

The original `Task.txt` contains the assignment statement: create a simple chat using asynchronous socket methods on both sides, allow choosing the server port, and let the client specify the server address and port. It contains no C# implementation and is retained as a text document.

The server tracks connected sockets in a `ConcurrentBag`, forwards a client's messages to the other clients, and can send its own messages. Each client provides connection controls and message input/output. The server binds specifically to `127.0.0.1`, so the preserved implementation is intended to be tried locally on one computer.

## Solution Structure

```text
Network_HW1.sln
Task.txt
Server/
    Server.csproj
    Server.csproj.user
    Program.cs
    ServerForm.cs
    ServerForm.Designer.cs
    ServerForm.resx
Client/
    Client.csproj
    Client.csproj.user
    Program.cs
    ClientForm.cs
    ClientForm.Designer.cs
    ClientForm.resx
```

Both projects target `net5.0-windows` with Windows Forms enabled and declare no NuGet package references.

## Opening and Running

Open `Network_HW1.sln` in Visual Studio on Windows with build tools supporting .NET 5 Windows Forms and a compatible runtime. Start the server, select an available port, and start listening. Launch one or more client instances and connect to `127.0.0.1` using the same port.

## Static Review Notes

- Both receive loops ignore the byte count returned by `ReceiveAsync` and decode the entire 1,024-byte buffer. The server checks `ArraySegment.Count`, which is the segment capacity rather than the received length, so it does not detect disconnects correctly.
- The implementation has no explicit message framing; stream reads do not necessarily correspond to individual sent messages. Send counts are also not checked for partial writes.
- Stop/disconnect closes the socket and cancels its token source, but starting again does not recreate either object. Restart and reconnect behavior needs review.
- Disconnected client sockets remain in the server's collection, and pending socket operations are not directly canceled by the cancellation token.

These notes are based on static inspection, not a complete correctness audit. All source code is preserved without corrections.

## Archive Notes

The solution, both complete projects, supplied user settings, form resources, and assignment statement were copied without changes and verified against the originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

The projects were not built or run, and socket communication was not tested when adding them to the archive.
