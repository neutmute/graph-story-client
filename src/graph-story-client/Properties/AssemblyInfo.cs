using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("API library for GraphStory.com")]

[assembly: ComVisible(false)]

#if DEBUG
    [assembly: AssemblyProduct("Graph Story Client (Debug)")]
    [assembly: AssemblyConfiguration("Debug")]
#else
    [assembly: AssemblyProduct("Graph Story Client (Release)")]
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion("1.0.0.*")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("Developer Build")]