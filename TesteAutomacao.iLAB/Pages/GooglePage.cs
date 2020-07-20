using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TesteAutomacao.iLAB.Util;

namespace TesteAutomacao.iLAB.Pages
{
    public class GooglePage : PageBase
    {
        private readonly IConfiguration _configuration;
        public GooglePage(BrowserContext browserContext)
                    : base(browserContext.WebDriver) => _configuration = browserContext.Configuration;

        public void CarregarPagina()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(5),
                _configuration.GetSection("Selenium:UrlTelaGoogle").Value);
        }

        public void PreencheCampoDeTexto(string texto)
        {
            _driver.SetText(
                By.Name("q"),
                texto.ToString());
        }

        public void SubmeterAPesquisa()
        {
            WebDriverWait wait = _driver.Wait(10);

            wait.Until().NameAppears("btnK");

            _driver.Submit(By.Name("btnK"));
        }
    }
}
