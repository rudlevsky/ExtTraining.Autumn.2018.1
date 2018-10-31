using System;
using NUnit.Framework;
using System.Globalization;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book book = new Book("title", "author", 2000, "publishHous", "edition", 350, 50);

        [TestCase("G", ExpectedResult = "Book record: author title publishHous")]
        [TestCase("ATP", ExpectedResult = "Book record: author title publishHous")]
        [TestCase("ATY", ExpectedResult = "Book record: author title 2000")]
        [TestCase("AT", ExpectedResult = "Book record: author title")]
        [TestCase("TYP", ExpectedResult = "Book record: title 2000 publishHous")]
        [TestCase("T", ExpectedResult = "Book record: title")]
        [TestCase("ATPE", ExpectedResult = "Book record: author title publishHous edition")]
        [TestCase("AEG", ExpectedResult = "Book record: author edition 350")]
        public string ToFormat(string format)
        {
            return string.Format(CultureInfo.CurrentCulture,"{0:" + format + "}",book);
        }

        [TestCase("AP", ExpectedResult = "Book record: author $50.00")]
        public string ToFormatDollarPrice(string format)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:" + format + "}", book);
        }

        [TestCase("AP", ExpectedResult = "Book record: author 50,00 €")]
        public string ToFormatEuroPrice(string format)
        {
            return string.Format(CultureInfo.GetCultureInfo("fr-FR"), "{0:" + format + "}", book);
        }

        [Test]
        public void MethodToString_DifferentFormats_CorrectResult()
        {
            Assert.Throws<FormatException>(() => string.Format(CultureInfo.CurrentCulture,"{0:test}",book));        
        }
    }
}
