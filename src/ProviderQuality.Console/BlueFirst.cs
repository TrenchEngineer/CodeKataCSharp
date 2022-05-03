namespace ProviderQuality.Console
{
    public class BlueFirst : Award
    {
        public BlueFirst(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {

        }

        /// <summary>
        /// Overrides the parent method to apply BlueFirst specific logic for updating quality before expiration is considered
        /// </summary>
        protected override void UpdateQualityPreExpiration()
        {
            // Increment the quality until it reaches a value of 50
            if (Quality < (int)NumericalConstants.Award_Maximum_Quality) Quality++;
        }

        /// <summary>
        /// Overrides the parent method to apply BlueFirst specific logic for updating quality after expiration is considered
        /// </summary>
        protected override void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed and the quality is less than 50, increment the quality again
            if (ExpiresIn < 0 && Quality < 50) Quality++;
        }
    }
}
