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
        [InlineData(RobotsIndex.IndexNoFollow)]
        [InlineData(RobotsIndex.NoIndexFollow)]
        [InlineData(RobotsIndex.NoIndexNoFollow)]
        public void PopulateSeoModelValues_ModelSetsMetaNoIndex_SetsSeoHelperValue(RobotsIndex robotsIndex)
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.MetaRobotsIndex = robotsIndex);
            var seoHelper = SeoHelperTestUtility.Get();

            // Act
            attribute.PopulateSeoModelValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(robotsIndex, seoHelper.MetaRobotsIndex);
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