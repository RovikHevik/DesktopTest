using DesktopTest.Model;
using FlaUI.Core;
using FlaUI.UIA3;
using System;

namespace DesktopTest.Logic
{
    internal class GrammarlyLogic
    {
        Application app;
        public GrammarlyLogic()
        {
            app = Application.Attach(@"C:\Users\HohloCit\AppData\Local\Grammarly\DesktopIntegrations\Grammarly.Desktop.exe");
            Console.WriteLine($"{app.Name} open: successfully");
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
