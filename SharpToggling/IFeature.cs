namespace SharpToggling
{
    public interface IFeature
    {
        bool IsOn(IFeatureSettingsProvider featureSettingsProvider);
    }
}
