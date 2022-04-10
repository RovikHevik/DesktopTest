using DesktopTest.Model;
using FlaUI.UIA3;
using System;
using System.Windows;
using System.Threading;
using DesktopTest.Logic.Interface;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.AutomationElements;

namespace DesktopTest.Logic
{
    internal class WordLogic : ITextInput
    {
        FlaUI.Core.Application app;

        public WordLogic(string pathToExe) => app = DesktopLogic.StartApp(pathToExe);

        public bool CloseApp()
        {
            app.Close();
            return true;
        }

        public bool InputText(TextModel model)
        {
            try
            {
                using (var automation = new UIA3Automation())
                {
                    Console.WriteLine($"{app.Name} open: successfully");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    var window = app.GetMainWindow(automation);
                    var button = Retry.Find(() => window.FindFirstDescendant(cf => cf.ByName("Новый документ")),
                    new RetrySettings
                            {
                                Timeout = TimeSpan.FromSeconds(2),
                                Interval = TimeSpan.FromMilliseconds(500)
                            }
                        ); 
                    button.Click();
                    Keyboard.Type(model.Text);
                    Console.WriteLine($"{app.Name} write: successfully");
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