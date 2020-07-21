using System;
using TechTalk.SpecFlow;
using TesteAutomacao.iLAB.Pages;
using TesteAutomacao.iLAB.Util;

namespace TesteAutomacao.iLAB.Steps
{
    [Binding]

    public class FazerPesquisaNoGoogleSteps : StepsBase
    {
        private GooglePage _googlePage;
        private static PesquisaGoogle _pesquisaGoogle;
       
        public FazerPesquisaNoGoogleSteps() : base()
        {
            _googlePage = new GooglePage(_browserContext);
            _pesquisaGoogle = new PesquisaGoogle(_browserContext);
        }

        [Given(@"que  eu estou na página do Google")]
        public void DadoQueEuEstouNaPaginaDoGoogle()
        {
            _googlePage.CarregarPagina();
            _pesquisaGoogle.TakeScreenshot(@"c:\Screenshot\EntaoOSistemaExibeOResultadoDaPesquisa\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");

        }
        
        [When(@"eu preencher o campo de busca")]
        public void QuandoEuPreencherOCampoDeBusca()
        {
            _googlePage.PreencheCampoDeTexto("iLAB Quality");
            _pesquisaGoogle.TakeScreenshot(@"c:\Screenshot\EntaoOSistemaExibeOResultadoDaPesquisa\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");

        }
        
        [When(@"eu clico  no botão de pesquisa")]
        public void QuandoEuClicoNoBotaoDePesquisa()
        {
            _googlePage.SubmeterAPesquisa();
            _pesquisaGoogle.TakeScreenshot(@"c:\Screenshot\EntaoOSistemaExibeOResultadoDaPesquisa\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");

        }
        
        [Then(@"o  sistema exibe o resultado da pesquisa")]
        public void EntaoOSistemaExibeOResultadoDaPesquisa()
        {
            _pesquisaGoogle.AcharBotao();
            _pesquisaGoogle.TakeScreenshot(@"c:\Screenshot\EntaoOSistemaExibeOResultadoDaPesquisa\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");


        }

        [AfterTestRun]

        public static void Log()
        {
            LogEvidenciaTeste.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "ArquivoLog");
            LogEvidenciaTeste.Log("Evidência de Teste");

            Console.WriteLine("Log criado e registrado com sucesso");
            Console.ReadLine();
        }
        public static void Fechar()
        {
            _pesquisaGoogle.Fechar();
        }
    }
}
