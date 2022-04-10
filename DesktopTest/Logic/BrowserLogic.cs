using DesktopTest.Logic.Interface;
using DesktopTest.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace DesktopTest.Logic
{
    internal class BrowserLogic : ITextInput
    {
        IWebDriver driver;
        public BrowserLogic()
        {
            driver = new FirefoxDriver(@"C:\Users\HohloCit\source\repos\DesktopTest\DesktopTest/");
            driver.Manage().Window.Maximize();
            Console.WriteLine($"Firefox start: successfully");
        }

        public bool CloseApp()
        {
            try
            {
                driver.Close();
                driver.Quit();
                Console.WriteLine($"Firefox close: successfully");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"Firefox close: failed");
                return false;
            }
        }


        public bool InputText(TextModel model)
        {
            try
            {
                driver.Navigate().GoToUrl($"https://translate.google.com/?sl=ru&tl=en&text={model.Text}&op=translate");
                Console.WriteLine($"Firefox: {driver.Url} successfully");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
