# WPF Chat with a Dedicated Server

A socket-based chat solution with WPF server and client applications and a shared library of message types.

**Topics:** asynchronous TCP sockets, line-based text protocols, concurrent dictionaries, nicknames, message routing, WPF data binding, and dispatcher-based UI updates.

**Difficulty:** advanced learning project. Combines multiple clients, shared protocol definitions, connection state, desktop interfaces, and public/private messaging.

## Behavior

The server maintains a nickname-to-socket dictionary, sends lists of existing users, assigns a fallback name when a nickname is already taken, and notifies clients about connections and disconnections. Clients can send a message to all users or select a user for a private message. The client user list is backed by an `ObservableCollection<string>`.

Messages use numeric codes from `MessageLib.MessageType` followed by line-delimited payload fields transmitted through `NetworkStream`, `StreamReader`, and `StreamWriter`.

Unlike [Network_HW1](../Network_HW1/), this solution uses WPF and adds named users, user-list updates, private messages, and a shared protocol project.

## Solution Structure

- `Network_HW4.sln` — the solution connecting all three projects.
- `Server/` — the WPF server project, application startup, window XAML and code, assembly metadata, and supplied user settings.
- `Client/` — the WPF client project with its corresponding startup, window, metadata, and user settings files.
- `MessageLib/` — the shared class library containing `Messages.cs` and its project file. Both applications reference this library through relative project paths.
- `Task.txt` — the original list of examination assignments. Option 3, a socket chat with a dedicated server, is marked in the supplied text. It contains assignment prose and is retained as a text document.

Both WPF applications target `net5.0-windows`; MessageLib targets `net5.0`. No NuGet package references are declared in these projects.

## Opening and Running

Open `Network_HW4.sln` in Visual Studio on Windows with support for .NET 5 and WPF and a compatible runtime. Start the Server application and click Start, then launch client instances and enter nicknames to connect.

Both applications use the embedded endpoint `127.0.0.1:10000`. The archived configuration therefore runs on one computer. The server binds and starts listening when its window loads; the Start button launches its accept loop. Changing the endpoint for other environments requires changes to the preserved source.

## Static Review Notes

- Receive code repeatedly creates and disposes `StreamReader` instances around the same socket. Buffered readers can read ahead, so discarding one between protocol messages can lose buffered input.
- Several asynchronous handlers write separate parts of messages to the same recipient socket without a shared write queue or lock. Concurrent sends can interleave protocol fields.
- Protocol codes are parsed with `int.Parse` without consistently handling malformed input or an end-of-stream result.
- Stopping the server cancels its token source, but starting again does not recreate it. Cancellation also does not directly interrupt a pending `AcceptAsync` call.
- The client uses `Thread.Sleep` inside UI event handlers, temporarily blocking the interface.

These observations are based on static inspection, not a complete correctness audit. The original implementation is preserved without corrections.

## Archive Notes

The solution, all three projects, XAML, source, supplied user settings, and assignment statement were copied without changes and verified against the originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

The solution was not built or run, and communication, user updates, and message routing were not tested when archived.
