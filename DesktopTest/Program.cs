using DesktopTest.Logic;
using DesktopTest.Logic.Interface;
using DesktopTest.Model;
using System;
using System.Threading;

namespace DesktopTest
{
    internal class Program
    {
        const string PathToWord = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
        const string PathToGrammarly = @"C:\Users\HohloCit\AppData\Local\Grammarly\DesktopIntegrations\Grammarly.Desktop.exe";
        private static TextModel modelToTest = new TextModel() { Text = "what r u know anout thes", ErrorCount = 2 };
        static void Main(string[] args)
        {
            GrammarlyLogic grammarlyLogic = new GrammarlyLogic(PathToGrammarly);
            ITextInput wordLogic = new BrowserLogic();
            wordLogic.InputText(modelToTest);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            grammarlyLogic.IsValueCorrect(modelToTest);
            Console.ReadKey();
        }
    }
}
