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
        const string PathToMozila = @"C:\Program Files\Firefox Developer Edition\firefox.exe";
        private static TextModel modelToTest = new TextModel() { Text = "what r u know anout thes", ErrorCount = 2 };
        static void Main(string[] args)
        {
            GrammarlyLogic grammarlyLogic = new GrammarlyLogic();
            ITextInput wordLogic = new WordLogic(PathToWord);
            wordLogic.InputText(modelToTest);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            grammarlyLogic.IsValueCorrect(modelToTest);
            Console.ReadKey();
        }
    }
}
