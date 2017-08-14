namespace FCamara.Comum.Extensions
{
    public static class DecimalExtension
    {
        public static string ToString(this decimal value)
        {
            return value.ToString("N2");
        }
    }
}
