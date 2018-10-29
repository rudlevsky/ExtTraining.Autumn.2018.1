using System;
using System.Globalization;

namespace BookLibrary
{
    public class Book: IFormattable
    {
        private string Title;
        private string Author;
        private string Year;
        private string PublishingHous;
        private string Edition;
        private string Pages;
        private string Price;

        public Book(string title, string author, string year, string publishHous, string edition, string pages, string price)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHous = publishHous;
            Edition = edition;
            Pages = pages;
            Price = price;
        }

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "ATP":
                    return "Book record: " + Author +  " " + Title + " " + PublishingHous;
                case "ATY":
                    return "Book record: " + Author + " " + Title + " " + Year;
                case "AT":
                    return "Book record: " + Author + " " + Title;
                case "TYP":
                    return "Book record: " + Title + " " + Year + " " + PublishingHous;
                case "T":
                    return "Book record: " + Title;
                case "ATPE":
                    return "Book record: " + Author + " " + Title + " " + PublishingHous + " " + Edition;
                case "AEG":
                    return "Book record: " + Author + " " + Edition + " " + Pages;
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
