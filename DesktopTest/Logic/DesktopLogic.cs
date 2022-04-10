using FlaUI.Core;
using System;

namespace DesktopTest.Logic
{
    static class DesktopLogic
    {
        public static Application StartApp(string pathToExe)
        {
            try
            {
                return Application.Launch(pathToExe);
            }
            catch (Exception)
            {
                return Application.Attach(pathToExe);
            }
        }
    }
}
