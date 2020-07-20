using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAutomacao.iLAB.Util
{
    //Classe que contém os métodos que simplificarão a manipulação de controles HTML
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
     TimeSpan timeout, string url)
        {
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().PageLoad = timeout;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }

        public static void SetText(this IWebDriver webDriver,
            By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Click();
        }

    }
}
