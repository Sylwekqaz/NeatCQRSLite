using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Ogólne informacje o zestawie są kontrolowane poprzez następujący 
// zestaw atrybutów. Zmień wartości tych atrybutów, aby zmodyfikować informacje
// powiązane z zestawem.
[assembly: AssemblyTitle("CQRSLite - CQRS")]
[assembly: AssemblyDescription("NeatCQRSLite is simple CQRS (command query responsibility segregation) framework. This peoject contain implementaton of CQRS basic bus definied in contract project")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
 [assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Sylwekqaz, NeatCode")]
[assembly: AssemblyProduct("Neat.CQRSLite.CQRS")]
[assembly: AssemblyCopyright("Copyright © NeatCode 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Ustawienie elementu ComVisible na wartość false sprawia, że typy w tym zestawie są niewidoczne
// dla składników COM. Jeśli potrzebny jest dostęp do typu w tym zestawie z
// COM, ustaw wartość true dla atrybutu ComVisible tego typu.
[assembly: ComVisible(false)]

// Następujący identyfikator GUID jest identyfikatorem biblioteki typów w przypadku udostępnienia tego projektu w modelu COM
[assembly: Guid("aee676ff-2bae-405b-92a9-9ce7b217b1b6")]

// Informacje o wersji zestawu zawierają następujące cztery wartości:
//
//      Wersja główna
//      Wersja pomocnicza
//      Numer kompilacji
//      Rewizja
//
// Możesz określić wszystkie wartości lub użyć domyślnych numerów kompilacji i poprawki
// przy użyciu symbolu „*”, tak jak pokazano poniżej:
// [assembly: AssemblyVersion("1.0.*")]

//Assembly versions are patched by appveyor build
[assembly: AssemblyVersion("0.0.1")]
[assembly: AssemblyFileVersion("0.0.1")]
[assembly: AssemblyInformationalVersion("0.0.1-local-build")]