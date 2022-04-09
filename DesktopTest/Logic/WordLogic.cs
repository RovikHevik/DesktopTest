using DesktopTest.Model;
using FlaUI.Core.Conditions;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;
using System.Windows;
using FlaUI.Core.Tools;
using System.Threading;
using DesktopTest.Logic.Interface;

namespace DesktopTest.Logic
{
    internal class WordLogic : ITextInput
    {
        FlaUI.Core.Application app;

        public WordLogic(string pathToExe)
        {
            app = DesktopLogic.StartApp(pathToExe);
        }

        public bool InputText(TextModel model)
        {
            try
            {
                using (var automation = new UIA3Automation())
                {                
                    var window = app.GetMainWindow(automation);
                    var button = window.FindFirstDescendant(cv => cv.ByAutomationId("AIOStartDocument")).AsButton();
                    button.Click();

                    return true;
                }
            }
            catch (Exception ex)
            {
                app.Close();
                MessageBox.Show(ex.Message);

                return false;
            }        
        }
    }
}
