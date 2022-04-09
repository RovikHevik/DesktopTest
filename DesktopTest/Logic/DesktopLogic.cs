using FlaUI.Core;
using System;

namespace DesktopTest.Logic
{
    static class DesktopLogic
    {
        public static Application StartApp(string pathToExe) => Application.Launch(pathToExe);
    }
}
