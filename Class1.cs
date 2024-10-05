using Microsoft.Win32;
using System.Runtime.Versioning;

namespace demo_roslyn_sop;

public class Class1
{
    [SupportedOSPlatform("windows")]
    private static void X()
    {
        _ = Registry.LocalMachine;
    }

    private static void Y()
    {
        [SupportedOSPlatform("windows")]
        static void L()
        {
            // CA1416: This call site is reachable on all platforms. 'Registry.LocalMachine' is only supported on: 'windows'.
            _ = Registry.LocalMachine;
        }
    }

    [SupportedOSPlatform("windows")]
    private static void Z()
    {
        static void L()
        {
            _ = Registry.LocalMachine;
        }
    }
}
