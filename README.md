# Any CPU Demo application for architecture-specific assemblies
Any CPU solution for your architecture-specific problems!

## Description

Demo application demonstrates basic skeleton for AnyCPU application that relies on architecture-specific dependencies (x86 and x64). The idea is to load correct version of the assembly at runtime, depending on current process architecture.

The same approach is also working under IIS with shadow copy enabled, so it is really generic approach that can be universally used.

There is nothing specific about Atalasoft assemblies in this approach. The same trick can be used with other architecture-specific libraries.

## Licensing
To run the demo locally, you need to have DotImage license. There are various way to acquire the license:

 - Use [DotImage Activation Wizard Visual Studio extension](https://visualstudiogallery.msdn.microsoft.com/88ff07c9-fe68-48bd-bfdc-3fbc8a0ec1db)
 - Download complete DotImage installation package from [Atalasoft web site](https://atalasoft.com). You will be prompted to activate the product during installation

## Related Articles

 - [Any CPU Support (kind of)](http://atalasoft.github.io/2016/10/28/any-cpu-support/) 
 - [Introducing NuGet Packages](http://atalasoft.github.io/2016/05/03/introducing-nuget/)
 
