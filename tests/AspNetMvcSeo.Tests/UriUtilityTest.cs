using System;

using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class UriUtilityTest
    {
        private const string Domain = "https://www.testdomain.co/";

        private static readonly Uri RequestUri = new Uri($"{Domain}testing/test.html?test1=ABC&test2=123");

        [Theory]
        [InlineData("/testpath/testitem.aspx")]
        [InlineData("/testpath/testitem.aspx?Testval1=ZXY&testVal2=987")]
        [InlineData("/testpath/testitem.aspx?Testval1=ZXY&testVal2=987#Fragment")]
        public void GetAbsoluteUrlInternal_ValidAbsolutePath_StartsWithDomainAndEndsWithAbsolutePath(
            string absolutePath)
        {
            // Arrange & Act
            string absoluteUrl = UriUtility.GetAbsoluteUrlInternal(absolutePath, RequestUri);

            // Assert
            bool startsWithDomain = absoluteUrl.StartsWith(Domain);
            bool endsWithAbsolutePath = absoluteUrl.EndsWith(absolutePath);

            Assert.True(startsWithDomain);
            Assert.True(endsWithAbsolutePath);
        }

        [Fact]
        public void GetAbsoluteUrlInternal_AppRelativePath_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => UriUtility.GetAbsoluteUrlInternal("~/absolutePath", RequestUri));
        }
    }
}