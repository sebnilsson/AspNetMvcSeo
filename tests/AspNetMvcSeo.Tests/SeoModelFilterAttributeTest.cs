using System;

using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoModelFilterAttributeTest
    {
        [Fact]
        public void PopulateSeoModelValues_ModelSetsCanonicalLink_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.CanonicalLink = TestData.TestCanonicalLink);
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            attribute.PopulateSeoModelValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestCanonicalLink, seoHelper.CanonicalLink);
        }

        [Fact]
        public void PopulateSeoModelValues_ModelSetsMetaDescription_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.MetaDescription = TestData.TestMetaDescription);
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            attribute.PopulateSeoModelValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestMetaDescription, seoHelper.MetaDescription);
        }

        [Fact]
        public void PopulateSeoModelValues_ModelSetsMetaKeywords_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.MetaKeywords = TestData.TestMetaKeywords);
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            attribute.PopulateSeoModelValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestMetaKeywords, seoHelper.MetaKeywords);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PopulateSeoModelValues_ModelSetsMetaNoIndex_SetsSeoHelperValue(bool noIndex)
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.MetaNoIndex = noIndex);
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            attribute.PopulateSeoModelValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(noIndex, seoHelper.MetaNoIndex);
        }

        [Fact]
        public void PopulateSeoModelValues_ModelSetsPageTitle_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.PageTitle = TestData.TestPageTitle);
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            attribute.PopulateSeoModelValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seoHelper.PageTitle);
        }

        private class MockSeoModel : ISeoModel
        {
            private readonly Action<SeoHelper> populateSeoAction;

            public MockSeoModel(Action<SeoHelper> populateSeoAction = null)
            {
                this.populateSeoAction = populateSeoAction;
            }

            public void PopulateSeo(SeoHelper seoHelper)
            {
                this.populateSeoAction?.Invoke(seoHelper);
            }
        }
    }
}