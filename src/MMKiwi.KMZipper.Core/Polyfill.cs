using System.ComponentModel;

#if !NETCOREAPP
namespace System.Runtime.CompilerServices;

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IsExternalInit { }
#endif