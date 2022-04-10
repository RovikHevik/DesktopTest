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
        const string PathToGrammarly = @"C:\Users\Fridoleen\AppData\Local\Grammarly\DesktopIntegrations\Grammarly.Desktop.exe";
        private static readonly TextModel modelToTest = new TextModel() { Text = "what r u know anout thes", ErrorCount = 2 };
        private static readonly TextModel modelToTestTwo = new TextModel() { Text = "what r u know about this", ErrorCount = 0 };
        static void Main(string[] args)
        {
            GrammarlyLogic grammarlyLogic = new GrammarlyLogic(PathToGrammarly);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ITextInput wordLogic = new WordLogic(PathToWord);
            //ITextInput wordLogic = new BrowserLogic();
            wordLogic.InputText(modelToTest);
            Console.WriteLine("Test result: " + grammarlyLogic.IsValueCorrect(modelToTest));
            Console.ReadKey();
        }
    }
}
