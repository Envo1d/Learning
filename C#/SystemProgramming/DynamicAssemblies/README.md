# Dynamic Cipher Assemblies

**Difficulty:** Advanced learning exercise.

## Implementation

A Windows Forms application dynamically discovers *Method.dll files and calls their Encrypt/Decrypt methods through reflection and AssemblyLoadContext. Caesar_Method and XOR_Method provide separate .NET 5 class libraries. File processing is queued through ThreadPool.

## Requirements and Layout

Open Sys_HW2.sln, build both algorithm projects and the net5.0-windows WinformApp, and place the resulting algorithm DLLs in the application's working directory. The application discovers them at runtime; its project has no project references or copy rules for those DLLs. Original task.txt is in WinformApp/.

The original solution layout, project names, and relative paths are preserved. The projects declare no NuGet package references. Build prerequisites and runtime behavior were not verified.

## Static Review Notes

FileProcces calls File.WriteAllText for each input line, replacing the previous output so only the last line remains. Reflection results are used without consistently checking for missing assemblies/types/methods. Caesar processing cycles over a combined uppercase/lowercase alphabet. This is an educational cipher and dynamic-loading exercise; algorithm behavior was not validated.

## Archive Notes

Imported from the supplied `System.7z` archive. Original source, project and solution files, form designers and resources, supplied user settings, and assignment texts were copied without changes and verified using file hashes. Generated `bin`/`obj`, Visual Studio's `.vs` files, and build outputs are excluded. Assignment-only texts retain their original format. Input data explicitly described above is preserved separately when originally stored in build output.

This is a static archival review, not an exhaustive correctness audit. No source fixes were applied, and the projects were not built or run.

