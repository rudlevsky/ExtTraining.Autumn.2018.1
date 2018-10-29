using System;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            CheckExceptions(source, @base);
            int result = 0;

            try
            {
                checked
                {
                    foreach (var letter in source)
                    {
                        var i = letter < '0' || letter > '9' ? char.ToUpper(letter) - 'A' + 10 : letter - '0';
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
                throw new ArgumentNullException(nameof(system) + " was null.");
            }

            if (system < 2 || system > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(system) + " is not correct.");
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (char.IsLetter(source[i]) && system < 10  ||
                     (system == 2) && (source[i] != '0' && source[i] != '1') || (system == 3) && (source[i] >= '3'))
                {
                    throw new ArgumentException(nameof(source) + " contain's uncorrect elements.");
                }
            }
        }
    }
}
