using Xunit;
using FluentAssertions;

using System.Collections.Generic;

namespace SharpToggling.Tests
{
    public class FeatureSettingsProviderTest
    {
        [Fact(DisplayName = "[FeatureSettingsProvider] Contains : Should return true when given feature name is contained by provider")]
        public void Contains_Should_Return_True_When_Given_Feature_Name_Is_Contained_By_Provider()
        {
            // Given
            var featureName = "une feature au hasard";
            var availableFeatures = new Dictionary<string, bool>
            {
                { featureName, true }
            };

            IFeatureSettingsProvider featureSettingsProvider = new FeatureSettingsProvider(availableFeatures);

            // When
            bool isFeatureContained = featureSettingsProvider.Contains(featureName);

            // Then
            isFeatureContained.Should().BeTrue();
        }

        [Fact(DisplayName = "[FeatureSettingsProvider] Contains : Should return false when given feature name is not contained by provider")]
        public void Contains_Should_Return_False_When_Given_Feature_Name_Is_Not_Contained_By_Provider()
        {
            // Given
            var featureName = "une feature inconnue du bataillon";
            var availableFeatures = new Dictionary<string, bool> { };

            IFeatureSettingsProvider featureSettingsProvider = new FeatureSettingsProvider(availableFeatures);

            // When
            bool isFeatureContained = featureSettingsProvider.Contains(featureName);

            // Then
            isFeatureContained.Should().BeFalse();
        }

        [Fact(DisplayName = "[FeatureSettingsProvider] IsFeatureEnabled : Should return true when given feature name is enabled on provider")]
        public void Contains_Should_Return_True_When_Given_Feature_Name_Is_Enabled_On_Provider()
        {
            // Given
            var featureName = "une super mega feature";
            var availableFeatures = new Dictionary<string, bool>
            {
                { featureName, true }
            };

            IFeatureSettingsProvider featureSettingsProvider = new FeatureSettingsProvider(availableFeatures);

            // When
            bool isFeatureEnabled = featureSettingsProvider.IsFeatureEnabled(featureName);

            // Then
            isFeatureEnabled.Should().BeTrue();
        }

        [Fact(DisplayName = "[FeatureSettingsProvider] IsFeatureEnabled : Should return false when given feature name is not enabled on provider")]
        public void Contains_Should_Return_False_When_Given_Feature_Name_Is_Not_Enabled_On_Provider()
        {
            // Given
            var featureName = "une feature qui a été désactivé, au cas ou quoi ...";
            var availableFeatures = new Dictionary<string, bool>
            {
                { featureName, false }
            };

            IFeatureSettingsProvider featureSettingsProvider = new FeatureSettingsProvider(availableFeatures);

            // When
            bool isFeatureEnabled = featureSettingsProvider.IsFeatureEnabled(featureName);

            // Then
            isFeatureEnabled.Should().BeFalse();
        }
    }
}
