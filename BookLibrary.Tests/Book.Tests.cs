using System;
using NUnit.Framework;
using System.Globalization;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {

        private Book book = new Book("title", "author", "year", "publishHous", "edition", "pages", "price");

        [TestCase("G", ExpectedResult = "Book record: " + "author" + " title" + " publishHous")]
        [TestCase("ATP", ExpectedResult = "Book record: " + "author" + " title" + " publishHous")]
        [TestCase("ATY", ExpectedResult = "Book record: " + "author" + " title" + " year")]
        [TestCase("AT", ExpectedResult = "Book record: " + "author" + " title")]
        [TestCase("TYP", ExpectedResult = "Book record: " + "title" + " year" + " publishHous")]
        [TestCase("T", ExpectedResult = "Book record: " + "title")]
        [TestCase("ATPE", ExpectedResult = "Book record: " + "author" + " title" + " publishHous" + " edition")]
        [TestCase("AEG", ExpectedResult = "Book record: " + "author" +" edition" + " pages")]
        public string ToFormat(string format)
        {
            return String.Format(CultureInfo.CurrentCulture,"{0:" + format + "}",book);
        }

        [Test]
        public void MethodToString_DifferentFormats_CorrectResult()
        {
            Assert.Throws<FormatException>(() => String.Format(CultureInfo.CurrentCulture,"{0:e}",book));
            
        }
    }
}
