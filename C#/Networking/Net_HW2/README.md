# Desktop Screenshots over UDP

A client/server exercise that captures the server computer's desktop and sends JPEG image data to a Windows Forms viewer through UDP datagrams.

**Topics:** UDP sockets, desktop capture, image encoding, packet segmentation and reassembly, asynchronous I/O, background tasks, and desktop UI updates.

**Difficulty:** advanced learning exercise. Combines operating-system graphics, network transport, image processing, and request scheduling.

## Assignment and Behavior

The original `task.txt` requests a console server and a Windows Forms or WPF client, UDP transport, an asynchronous server, and adjustable screenshot request frequency outside the UI thread. It contains assignment prose and is preserved as text.

The client sends an `ack` request. The server captures the desktop through `Graphics.CopyFromScreen`, encodes it as JPEG, and sends chunks with a two-byte header containing the chunk index and final chunk index. The client collects chunks in a dictionary, reconstructs the image, and displays it in a picture box. A slider selects a requested frequency from 1 to 20; actual throughput also depends on capture and transfer time.

## Solution Structure

```text
Net_HW2.sln
task.txt
Server/
    Server.csproj
    Program.cs
Client/
    Client.csproj
    Client.csproj.user
    Program.cs
    Form1.cs
    Form1.Designer.cs
    Form1.resx
```

The server targets `net5.0` and references `SharpDX.Direct2D1` 4.2.0 and `System.Drawing.Common` 6.0.0. Its capture implementation uses System.Drawing and Windows GDI calls. The client targets `net5.0-windows` with Windows Forms enabled and has no explicit package references.

## Opening and Running

Open `Net_HW2.sln` in Visual Studio on Windows with suitable .NET 5 and Windows Forms build tools. Restore the declared server packages and use a compatible runtime. Desktop capture requires an interactive Windows desktop.

Both applications use `127.0.0.1:10000`, so the preserved configuration runs locally on one computer. Start the console server, then the client, choose a frequency, and click Start. Running across computers requires adapting the embedded endpoints in the original source.

## Static Review Notes

- The server receives requests through synchronous `ReceiveFrom` despite the assignment's asynchronous-server requirement; sending uses `SendToAsync`.
- The server calculates the final packet index using the 65,002-byte buffer size, while payload offsets advance by 65,000 bytes. Boundary image sizes can therefore produce an incorrect packet count.
- Packet indices and client counters are bytes, which limits the representable number of chunks. The protocol has no frame identifier, retransmission, or timeout for missing chunks, and duplicate dictionary keys can cause exceptions.
- The client ignores the received byte count and copies entire fixed-size payload buffers, including padding.
- Canceling a request loop does not directly interrupt a pending receive. Resource disposal and closing an unconnected UDP socket with `Shutdown` also need review.

These observations are based on static inspection, not a complete correctness audit. The original code is preserved without corrections.

## Archive Notes

The solution, both projects, original C# sources, client designer and resources, supplied user settings, and assignment statement were copied without changes and verified against the originals using file hashes. Generated `bin` and `obj` directories and Visual Studio's `.vs` directory are excluded. The original source directory is preserved.

The solution was not built or run. No desktop screenshots were captured, and UDP transfer was not tested when archiving it.
