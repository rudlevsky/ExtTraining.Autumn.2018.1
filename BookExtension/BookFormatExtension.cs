using System;
using BookLibrary;
using System.Globalization;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {

            if (arg.GetType() != typeof(Book))
            {
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }
          
            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (ufmt != "H")
            {
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }
    
            return arg.ToString() + " new string result";
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return string.Empty;
        }
    }


}

