namespace SharpToggling
{
    public interface IFeatureSettingsProvider
    {
        bool Contains(string featureName);
        bool IsFeatureEnabled(string featureName);
    }
}
