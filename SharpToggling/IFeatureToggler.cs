namespace SharpToggling
{
    public interface IFeatureToggler
    {
        /// <summary>
        /// Check if a feature is enabled or not
        /// </summary>
        /// <param name="feature">Feature to check</param>
        /// <returns>Wether the feature is enabled or not</returns>
        bool IsOn(IFeature feature);
    }
}
