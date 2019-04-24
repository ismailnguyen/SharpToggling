namespace SharpToggling
{
    public class Feature : IFeature
    {
        private readonly string _name;

        public Feature(string name)
        {
            _name = name;
        }

        public bool IsOn(IFeatureSettingsProvider featureSettingsProvider)
        {
            if (!featureSettingsProvider.Contains(_name))
                return false;

            return featureSettingsProvider.IsFeatureEnabled(_name);
        }
    }
}
