using DesktopTest.Logic;
using DesktopTest.Logic.Interface;
using DesktopTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopTest
{
    internal class Program
    {
        const string PathToWord = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
        const string PathToMozila = @"C:\Program Files\Firefox Developer Edition\firefox.exe";
        readonly static TextModel TextToTest = new TextModel() { Text = "what r u know anout thes", ErrorCount = 2 };
        static void Main(string[] args)
        {
            WordLogic wordLogic = new WordLogic(PathToWord);
            Console.WriteLine(wordLogic.InputText(TextToTest));
            Console.ReadKey();
        }
    }
}
