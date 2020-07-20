using Microsoft.Extensions.Configuration;
using System;
using TesteAutomacao.iLAB.Extensions.TesteAutomacao.iLAB.Extensions;
using TesteAutomacao.iLAB.Util;

namespace TesteAutomacao.iLAB.Steps
{
        public class StepsBase
        {
            public StepsBase()
            {
                var fileName = "appsettings.json";

                var path = new ConfigurationBuilder()
                    .SetBasePath(fileName.ToApplicationPath());

                var builder = path
                   .AddJsonFile(fileName);

                _configuration = builder.Build();


                _browserContext = new BrowserContext(Browser.Chrome, _configuration);

            }

            protected readonly IConfiguration _configuration;
            protected static BrowserContext _browserContext;
        }
}
