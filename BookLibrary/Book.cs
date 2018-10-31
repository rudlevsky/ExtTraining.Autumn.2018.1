using System;
using System.Globalization;

namespace BookLibrary
{
    public class Book: IFormattable, IComparable<Book>, IEquatable<Book>
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string PublishingHous { get; private set; }
        public string Edition { get; private set; }
        public int Pages { get; private set; }
        public decimal Price { get; private set; }

        public Book(string title, string author, int year, string publishHous, string edition, int pages, decimal price)
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
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "ATP":
                    return $"Book record: {Author} {Title} {PublishingHous}";
                case "ATY":
                    return $"Book record: {Author} {Title} {Year}";
                case "AT":
                    return $"Book record: {Author} {Title}";
                case "TYP":
                    return $"Book record: {Title} {Year} {PublishingHous}";
                case "T":
                    return $"Book record: {Title}";
                case "ATPE":
                    return $"Book record: {Author} {Title} {PublishingHous} {Edition}";
                case "AEG":
                    return $"Book record: {Author} {Edition} {Pages}";
                case "AP":
                    return $"Book record: {Author} {Price.ToString("C", provider)}";
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }

        public int CompareTo(Book other)
        {
            if (Price == other.Price)
            {
                return 0;
            }

            if (Price > other.Price)
            {
                return 1;
            }

            return -1;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Title == other.Title && Author == other.Author)
            {
                return true;
            }

            return false;
        }
    }
}
