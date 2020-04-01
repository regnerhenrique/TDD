using System.Text.RegularExpressions;

namespace TDD.Original.Web.Utils
{
    public static class StringExtensions
    {
        public static string RemoverCaracteresEspeciais(this string texto)
        {
            return Regex.Replace(texto, @"[^\w\d]", "");
        }
    }
}
