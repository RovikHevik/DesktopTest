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
            Console.WriteLine($"{app.Name}: successfully, with proccesId: {app.ProcessId}");
        }
           
        
        public bool IsValueCorrect(TextModel model)
        {
            using (var automation = new UIA3Automation())
            {
                int count = 0;
                var window = app.GetMainWindow(automation);
                Console.WriteLine($"{app.Name} count: {window.FindFirstDescendant(cf => cf.ByAutomationId("AlertsCounterLabel")).Name}");
                if (count == model.ErrorCount) return true;
                else return false;
            }
        }
    }
}
