namespace LojaRepositorios.ExtensionMethods
{
    public static class StringExtensionMethod
    {
        public static string ObterCpfLimpo(this string texto)
        {
            return texto.Replace("-", "").Replace(".", "");
        }
    }
}
