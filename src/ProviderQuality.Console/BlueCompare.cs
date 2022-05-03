namespace ProviderQuality.Console
{
    public class BlueCompare : Award
    {
        public BlueCompare(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {
            
        }

        /// <summary>
        /// Overrides the parent method to apply BlueCompare specific logic for updating quality before expiration is considered
        /// </summary>
        /// <remarks>
        /// BlueCompare quality changes accelerate depending on the number of expires in days remaining
        /// </remarks>
        protected override void UpdateQualityPreExpiration()
        {
            if (Quality < (int)NumericalConstants.Award_Maximum_Quality) Quality++;

            // If the expiration date is zero or more days away check for double or triple quality update
            if (ExpiresIn >= 0)
            {
                if (ExpiresIn <= (int)NumericalConstants.Blue_Compare_First_Expiration_Period) Quality++;

                if (ExpiresIn <= (int)NumericalConstants.Blue_Compare_Second_Expiration_Period) Quality++;
            }
            
        }

        /// <summary>
        /// Overrides the parent method to apply BlueCompare specific logic for updating quality after expiration is considered
        /// </summary>
        protected override void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed and is negative, set the quality to zero
            if (ExpiresIn < 0) Quality = 0;
        }
    }
}
