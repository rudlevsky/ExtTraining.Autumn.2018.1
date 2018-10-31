using System;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            CheckExceptions(source, @base);

            string alpf = "0123456789ABCDEF";
            string usedAlpf = alpf.Substring(0, @base);
            int result = 0;

            try
            {
                checked
                {
                    foreach (var letter in source)
                    {
                        if (usedAlpf.IndexOf(char.ToUpperInvariant(letter)) < 0)
                        {
                            throw new ArgumentException("Base system is incorrect.");
                        }

                        var i = letter < '0' || letter > '9' ? char.ToUpperInvariant(letter) - 'A' + 10 : letter - '0';
                        result = result * @base + i;
                    }
                }
            }
            catch (OverflowException ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return result;
        }

        private static void CheckExceptions(string source, int system)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(system)} was null.");
            }

            if (system < 2 || system > 16)
            {
                throw new ArgumentOutOfRangeException($"{nameof(system)} is not correct.");
            }
        }
    }
}
