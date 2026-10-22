# Thread Control: Primes and Fibonacci

**Difficulty:** Advanced learning exercise.

## Implementation

A .NET 5 Windows Forms application that generates prime numbers and a Fibonacci sequence on separate background Thread instances. Controls provide start/restart, interruption, and pause/resume operations using AutoResetEvent.

## Requirements and Layout

Open Sys_HW1.sln on Windows with build tools supporting net5.0-windows and a compatible runtime.

The original solution layout, project names, and relative paths are preserved. The projects declare no NuGet package references. Build prerequisites and runtime behavior were not verified.

## Static Review Notes

The Fibonacci pause branch waits on pauseNum while its resume handler signals pauseFib. Thread objects are created once and cannot be started again after termination. The prime test also returns true for values below 2 if supplied. These issues are preserved without corrections.

## Archive Notes

Imported from the supplied `System.7z` archive. Original source, project and solution files, form designers and resources, supplied user settings, and assignment texts were copied without changes and verified using file hashes. Generated `bin`/`obj`, Visual Studio's `.vs` files, and build outputs are excluded. Assignment-only texts retain their original format. Input data explicitly described above is preserved separately when originally stored in build output.

This is a static archival review, not an exhaustive correctness audit. No source fixes were applied, and the projects were not built or run.

