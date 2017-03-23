using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("CQRSLite - Contract")]
[assembly: AssemblyDescription("NeatCQRSLite is simple CQRS (command query responsibility segregation) framework. This peoject contain implementaton of CQRS basic bus definied in contract project")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
 [assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Sylwekqaz, NeatCode")]
[assembly: AssemblyProduct("Neat.CQRSLite.Contract")]
[assembly: AssemblyCopyright("Copyright © NeatCode 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("d10b176b-a3b1-4ff6-a764-f6eb36ef16ea")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

//Assembly versions are patched by appveyor build
[assembly: AssemblyVersion("0.0.1")]
[assembly: AssemblyFileVersion("0.0.1")]
[assembly: AssemblyInformationalVersion("0.0.1-local-build")]

