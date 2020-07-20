using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TesteAutomacao.iLAB.Extensions
{
    namespace TesteAutomacao.iLAB.Extensions
    {
        public static class ApplicationPathExtensions
        {
            public static string ToApplicationPath(this string fileName, string folder = null)
            {
                var exePath = Path.GetDirectoryName(System.Reflection
                                    .Assembly.GetExecutingAssembly().CodeBase);
                Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
                var path = appPathMatcher.Match(exePath).Value;

                if (!string.IsNullOrEmpty(folder))
                {
                    path = $"{path}\\{folder}";
                }
                Console.WriteLine("Teste");
                Console.WriteLine(path);
                return path;
            }
        }
    }
}
