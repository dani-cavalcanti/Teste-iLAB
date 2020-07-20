using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAutomacao.iLAB.Util
{
    //responsável por retornar as instâncias específicas
    //para interação com cada tipo de browser acessado durante os testes
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(
            Browser browser, string pathDriver, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxDriverService service =
                        FirefoxDriverService.CreateDefaultService(pathDriver);

                    webDriver = new FirefoxDriver(service);

                    break;
                case Browser.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    webDriver = new ChromeDriver(pathDriver, chromeOptions);

                    break;
            }

            return webDriver;
        }
    }
}
