# Windows Keyboard Hook and Monitor File Copy

**Difficulty:** Advanced learning exercise.

## Implementation

Two independent .NET 5 projects share a solution: WinFormsApp1 demonstrates a low-level Windows keyboard hook that appends key names to keylog.log, and ConsoleApp1 attempts to copy a Windows-1251 text file using ten threads and Monitor locks.

## Requirements and Layout

Open Sys_HW3.sln on Windows. The Windows Forms project targets net5.0-windows; the console project targets net5.0. The hook demonstration is recorded here for static study and was not activated. The input alisa.txt was found inside the original console build output and preserved separately as data/alisa.txt; place a copy in the console application's working directory if studying the copy exercise. Generated copy.txt is excluded.

The original solution layout, project names, and relative paths are preserved. The projects declare no NuGet package references. Build prerequisites and runtime behavior were not verified.

## Static Review Notes

The hook logs virtual-key names rather than translated text, and its unhook call is commented out. The file-copy lambda captures the mutable for-loop variable i. Monitor locks serialize access, but no turn-taking scheme establishes fair alternation. The shared completion counter and busy-wait loop lack a suitable completion mechanism, and byte length is mixed with character reads. These are static observations; no keyboard events were recorded and no copy operation was run.

## Archive Notes

Imported from the supplied `System.7z` archive. Original source, project and solution files, form designers and resources, supplied user settings, and assignment texts were copied without changes and verified using file hashes. Generated `bin`/`obj`, Visual Studio's `.vs` files, and build outputs are excluded. Assignment-only texts retain their original format. Input data explicitly described above is preserved separately when originally stored in build output.

This is a static archival review, not an exhaustive correctness audit. No source fixes were applied, and the projects were not built or run.

