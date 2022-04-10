using DesktopTest.Model;
using FlaUI.Core;
using FlaUI.UIA3;
using System;

namespace DesktopTest.Logic
{
    internal class GrammarlyLogic
    {
        Application app;
        public GrammarlyLogic(string pathToExe)
        {
            app = Application.Attach(pathToExe);
            Console.WriteLine($"{app.Name}: successfully, with processId: {app.ProcessId}");
        }
           
        
        public bool IsValueCorrect(TextModel model)
        {
            using (var automation = new UIA3Automation())
            {
                var screen = app.GetMainWindow(automation);
                int count = 0;
                Console.WriteLine($"{app.Name} count {screen.FindFirstDescendant(cf => cf.ByAutomationId("AlertsCounterLabel")).Name} errors");
                if (count == model.ErrorCount) return true;
                else                           return false;
            }
        }
    }
}
