using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TesteAutomacao.iLAB.Pages
{
    public class PageBase : IDisposable
    {
        protected IWebDriver _driver;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }

        public void Dispose()
        {
            Fechar();
        }

        public void TakeScreenshot(string path, string file)
        {
            ITakesScreenshot takesScreenshot = _driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            screenshot.SaveAsFile($"{path}{file}", ScreenshotImageFormat.Png);
        }
    }
}
