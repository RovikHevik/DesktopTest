using DesktopTest.Model;
using FlaUI.UIA3;
using System;
using System.Windows;
using System.Threading;
using DesktopTest.Logic.Interface;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;

namespace DesktopTest.Logic
{
    internal class WordLogic : ITextInput
    {
        FlaUI.Core.Application app;

        public WordLogic(string pathToExe)
        {
            app = DesktopLogic.StartApp(pathToExe);
            Console.WriteLine($"{app.Name} start: successfully, with processId: {app.ProcessId}");
        }

        public bool CloseApp()
        {
            try
            {
                app.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InputText(TextModel model)
        {
            try
            {
                using (var automation = new UIA3Automation())
                {
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
                    Console.WriteLine($"{app.Name} write: \"{model.Text}\" with {model.ErrorCount} errors");
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