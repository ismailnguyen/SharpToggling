using Xunit;
using NSubstitute;

namespace SharpToggling.Tests
{
    public class FeatureTogglerTest
    {
        [Fact(DisplayName = "[Feature toggler] IsOn : Should call IsOn method of given feature")]
        public void IsOn_Should_Call_IsOn_Of_Given_Feature()
        {
            // Given
            var someFeature = Substitute.For<IFeature>();
            var enabledFeaturesProvider = Substitute.For<IFeatureSettingsProvider>();
            var featureToggler = new FeatureToggler(enabledFeaturesProvider);

            // When
            bool isFeatureOn = featureToggler.IsOn(someFeature);

            // Then
            someFeature.Received().IsOn(enabledFeaturesProvider);
        }
    }
}
