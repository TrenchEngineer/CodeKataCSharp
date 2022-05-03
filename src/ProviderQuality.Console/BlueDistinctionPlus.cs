using System;

namespace ProviderQuality.Console
{
    public class BlueDistinctionPlus : Award
    {
        public BlueDistinctionPlus(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {


        }

        /// <summary>
        /// Overrides the parent method to apply BlueDistinctionPlus specific logic for updating quality before expiration is considered
        /// </summary>
        protected override void UpdateQualityPreExpiration()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by quality updates
        }

        /// <summary>
        /// Overrides the parent method to apply BlueDistinctionPlus specific logic for updating quality after expiration is considered
        /// </summary>
        protected override void UpdateQualityPostExpiration()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by quality updates
        }

        /// <summary>
        /// Overrides the parent method to apply BlueDistinctionPlus specific logic for updating the expires in day
        /// </summary>
        protected override void UpdateExpiresIn()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by expiration dates
        }

        /// <summary>
        /// Overrides the parent method to apply BlueDistinctionPlus specific logic for validating the maximum quality
        /// </summary>
        protected override void ValidateMaximumQuality()
        {
            if (Quality > (int)NumericalConstants.Blue_Distinction_Plus_Maximum_Quality)
            {
                string message = $"Error detected in award {Name}:";

                message += $"\nQuality cannot be greater than {(int)NumericalConstants.Blue_Distinction_Plus_Maximum_Quality}";

                throw new ArgumentException(message);
            }
        }
    }
}
