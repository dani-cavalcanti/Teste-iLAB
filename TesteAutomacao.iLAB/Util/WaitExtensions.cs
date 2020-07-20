using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAutomacao.iLAB.Util
{
    public static class WaitExtensions
    {
        public static WebDriverWait Until(this WebDriverWait wait)
    => wait;

        public static bool NameAppears(this WebDriverWait wait, string name)
            => wait.Until((d) => d.FindElement(By.Name(name)).Displayed);

        public static WebDriverWait Wait(this IWebDriver webdriver, long seconds)
            => new WebDriverWait(webdriver, TimeSpan.FromSeconds(seconds));
    }
}
