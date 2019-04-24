namespace SharpToggling
{
    public class FeatureToggler : IFeatureToggler
    {
        private readonly IFeatureSettingsProvider _featureSettingsProvider;

        public FeatureToggler(IFeatureSettingsProvider featureSettingsProvider)
        {
            _featureSettingsProvider = featureSettingsProvider;
        }

        public bool IsOn(IFeature feature)
        {
            return feature.IsOn(_featureSettingsProvider);
        }
    }
}
