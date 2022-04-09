using DesktopTest.Logic.Interface;
using DesktopTest.Model;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DesktopTest.Logic
{
    internal class BrowserLogic : ITextInput
    {
       FlaUI.Core.Application app;

        public BrowserLogic(string pathToExe)
        {
            app = DesktopLogic.StartApp(pathToExe);
        }
        public bool InputText(TextModel model)
        {
            using (var automation = new UIA3Automation())
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));

                var window = app.GetMainWindow(automation);

                var urlEditor = window.FindFirstDescendant(cv => cv.ByAutomationId("urlbar-input"));
                urlEditor.Focus();
                Keyboard.Type(model.Text);
                Keyboard.Press(VirtualKeyShort.ENTER);
                app.WaitWhileBusy(TimeSpan.FromMilliseconds(500));

                return true;
            }
        }
    }
}
