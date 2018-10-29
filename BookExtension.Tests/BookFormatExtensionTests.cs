using System;
using NUnit.Framework;
using System.Globalization;
using BookLibrary;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        private IFormatProvider provider = new BookFormatExtension();
        private Book book = new Book("title", "author", "year", "publishHous", "edition", "pages", "price");

        [TestCase("H", ExpectedResult = "Book record: author title publishHous new string result")]
        public string ToFormat(string format)
        {
            return String.Format(provider, "{0:" + format + "}", book);
        }

        [Test]
        public void MethodToString_DifferentFormats_CorrectResult()
        {
            Assert.Throws<FormatException>(() => String.Format(CultureInfo.CurrentCulture, "{0:e}", book));
        }

    }
}
