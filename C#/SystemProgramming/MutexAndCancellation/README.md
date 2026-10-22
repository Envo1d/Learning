# Mutex File Exchange and Cancelable Progress

**Difficulty:** Advanced learning exercise; ProgressBar alone is intermediate.

## Implementation

A .NET 5 Windows Forms solution containing Writer and Reader applications that exchange file data through a named Mutex, plus a separate ProgressBar application using Task, CancellationToken, and IProgress<int>.

## Requirements and Layout

Open Sys_HW4.sln on Windows with build tools supporting net5.0-windows. Writer and Reader use the named mutex FileReadWrite and the fixed path C:/WriteRead/test.txt. The supplied design expects Writer to start first. ProgressBar is an independent startup project. Task.txt contains the original two assignment statements.

The original solution layout, project names, and relative paths are preserved. The projects declare no NuGet package references. Build prerequisites and runtime behavior were not verified.

## Static Review Notes

Writer deletes the existing exchange file during initialization. It releases and immediately reacquires the mutex, without guaranteed handoff fairness. Reader's ongoing loop and file-position handling need review. ProgressBar toggles its running flag both in the stop handler and in worker completion, allowing inconsistent button state and overlap on rapid restarts. No application was run and the fixed external path was not created.

## Archive Notes

Imported from the supplied `System.7z` archive. Original source, project and solution files, form designers and resources, supplied user settings, and assignment texts were copied without changes and verified using file hashes. Generated `bin`/`obj`, Visual Studio's `.vs` files, and build outputs are excluded. Assignment-only texts retain their original format. Input data explicitly described above is preserved separately when originally stored in build output.

This is a static archival review, not an exhaustive correctness audit. No source fixes were applied, and the projects were not built or run.

