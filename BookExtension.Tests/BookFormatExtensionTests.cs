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
        private Book book = new Book("title", "author", 2000, "publishHous", "edition", 350, 50);

        [TestCase("H", ExpectedResult = "Book record: author title publishHous new string result")]
        public string ToFormat(string format)
        {
            return string.Format(provider, "{0:" + format + "}", book);
        }

        [Test]
        public void MethodToString_DifferentFormats_CorrectResult()
        {
            Assert.Throws<FormatException>(() => string.Format(CultureInfo.CurrentCulture, "{0:test}", book));
        }

    }
}
