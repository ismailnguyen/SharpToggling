using System.Collections.Generic;

namespace SharpToggling
{
    public class FeatureSettingsProvider : IFeatureSettingsProvider
    {
        private readonly IDictionary<string, bool> _enabledFeatures;

        public FeatureSettingsProvider(IDictionary<string, bool> enabledFeatures)
        {
            _enabledFeatures = enabledFeatures;
        }

        public bool Contains(string featureName)
        {
            return _enabledFeatures.ContainsKey(featureName);
        }

        public bool IsFeatureEnabled(string featureName)
        {
            return _enabledFeatures[featureName];
        }
    }
}
