using System;

using Xunit;

namespace AspNetMvcSeo.Tests
{
    public class SeoModelFilterAttributeTest
    {
        [Fact]
        public void PopulateSeoModelValues_ModelSetsLinkCanonical_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.LinkCanonical = TestData.TestLinkCanonical);
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            attribute.HandleSeoValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestLinkCanonical, seoHelper.LinkCanonical);
        }

        [Fact]
        public void PopulateSeoModelValues_ModelSetsMetaDescription_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.MetaDescription = TestData.TestMetaDescription);
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            attribute.HandleSeoValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestMetaDescription, seoHelper.MetaDescription);
        }

        [Fact]
        public void PopulateSeoModelValues_ModelSetsMetaKeywords_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.MetaKeywords = TestData.TestMetaKeywords);
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            attribute.HandleSeoValues(seoModel, seoHelper);

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
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            attribute.HandleSeoValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(robotsIndex, seoHelper.MetaRobotsIndex);
        }

        [Fact]
        public void PopulateSeoModelValues_ModelSetsPageTitle_SetsSeoHelperValue()
        {
            // Arrange
            var attribute = new SeoModelFilterAttribute();
            var seoModel = new MockSeoModel(x => x.Title = TestData.TestPageTitle);
            var seoHelper = SeoHelperTestFactory.Create();

            // Act
            attribute.HandleSeoValues(seoModel, seoHelper);

            // Assert
            Assert.Equal(TestData.TestPageTitle, seoHelper.Title);
        }

        private class MockSeoModel : ISeoModel
        {
            private readonly Action<SeoHelper> populateSeoAction;

            public MockSeoModel(Action<SeoHelper> populateSeoAction = null)
            {
                this.populateSeoAction = populateSeoAction;
            }

            public void OnHandleSeoValues(SeoHelper seoHelper)
            {
                this.populateSeoAction?.Invoke(seoHelper);
            }
        }
    }
}