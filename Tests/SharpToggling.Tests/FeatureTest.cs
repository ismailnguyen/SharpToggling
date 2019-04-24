using Xunit;
using NSubstitute;
using FluentAssertions;

namespace SharpToggling.Tests
{
    public class FeatureTest
    {
        [Fact(DisplayName = "[Feature] IsOn : Should return true when feature is enabled on given feature settings provider")]
        public void IsOn_Should_Return_True_When_Feature_Is_Enabled_On_Given_Feature_Settings_Provider()
        {
            // Given
            var featureName = "some feature name";
            IFeature feature = new Feature(featureName);
            var featureSettingsProvider = Substitute.For<IFeatureSettingsProvider>();

            featureSettingsProvider.Contains(featureName).Returns(true);
            featureSettingsProvider.IsFeatureEnabled(featureName).Returns(true);

            // When
            bool isFeatureEnabled = feature.IsOn(featureSettingsProvider);

            // Then
            isFeatureEnabled.Should().BeTrue();
        }

        [Theory(DisplayName = "[Feature] IsOn : Should call Contains method of given feature settings provider")]
        [InlineData("featureName")]
        [InlineData("another feature name")]
        [InlineData("superFeatureOfTheWorldOFTheUniverse")]
        public void IsOn_Should_Call_Contains_Method_Of_Given_Feature_Settings_Provider(string featureName)
        {
            // Given
            IFeature feature = new Feature(featureName);
            var featureSettingsProvider = Substitute.For<IFeatureSettingsProvider>();

            // When
            bool isFeatureEnabled = feature.IsOn(featureSettingsProvider);

            // Then
            featureSettingsProvider.Received().Contains(featureName);
        }

        [Fact(DisplayName = "[Feature] IsOn : Should return false when feature is missing on given feature settings provider")]
        public void IsOn_Should_Return_False_When_Feature_Is_Missing_From_Given_Feature_Settings_Provider()
        {
            // Given
            IFeature feature = new Feature("some feature name");
            var featureSettingsProvider = Substitute.For<IFeatureSettingsProvider>();

            // When
            bool isFeatureEnabled = feature.IsOn(featureSettingsProvider);

            // Then
            isFeatureEnabled.Should().BeFalse();
        }

        [Fact(DisplayName = "[Feature] IsOn : Should call IsFeatureEnabled method of given feature settings provider")]
        public void IsOn_Should_Call_IsFeatureEnabled_Method_Of_Given_Feature_Settings_Provider()
        {
            // Given
            var featureName = "some feature name";
            IFeature feature = new Feature(featureName);
            var featureSettingsProvider = Substitute.For<IFeatureSettingsProvider>();

            featureSettingsProvider.Contains(featureName).Returns(true);

            // When
            bool isFeatureEnabled = feature.IsOn(featureSettingsProvider);

            // Then
            featureSettingsProvider.Received().IsFeatureEnabled(featureName);
        }

        [Fact(DisplayName = "[Feature] IsOn : Should return false when feature is disabled on given feature settings provider")]
        public void IsOn_Should_Return_False_When_Feature_Is_Disabled_From_Given_Feature_Settings_Provider()
        {
            // Given
            var featureName = "some feature name";
            IFeature feature = new Feature(featureName);
            var featureSettingsProvider = Substitute.For<IFeatureSettingsProvider>();

            featureSettingsProvider.Contains(featureName).Returns(true);
            featureSettingsProvider.IsFeatureEnabled(featureName).Returns(false);

            // When
            bool isFeatureEnabled = feature.IsOn(featureSettingsProvider);

            // Then
            isFeatureEnabled.Should().BeFalse();
        }
    }
}
