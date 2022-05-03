using System;

namespace ProviderQuality.Console
{
    public class Award
    {
        protected string Name;

        protected int ExpiresIn;

        protected int Quality;

        public Award (string name, int epxiresIn, int quality) {

            Name = name; 

            ExpiresIn = epxiresIn; 

            Quality = quality; 
        }

        /// <summary>
        /// PUblic runner to update award quality
        /// </summary>
        public void UpdateAward()
        {
            UpdateQualityPreExpiration();

            UpdateExpiresIn();

            UpdateQualityPostExpiration();
        }

        /// <summary>
        /// Updates the quality calculation before considering the expiration days
        /// </summary>
        protected virtual void UpdateQualityPreExpiration()
        {
            // If the quality is greater than zero always decrement it
            if (Quality > 0) Quality--;
        }

        /// <summary>
        /// Updates the quality calculation after considering the expiration days
        /// </summary>
        protected virtual void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed decrement the quality again
            if (ExpiresIn < 0 && Quality > 0) Quality--;            
        }

        /// <summary>
        /// Decrements the expires in day
        /// </summary>
        protected virtual void UpdateExpiresIn()
        {
            ExpiresIn--;
        }

        public virtual string GetName() { return Name; }

        public virtual int GetExpiresIn() { return ExpiresIn; }

        public virtual int GetQuality() { return Quality; }

        /// <summary>
        /// A public runner used to validate the data input for awards
        /// </summary>
        public void ValidateQuality()
        {
            ValidateMaximumQuality();
            ValidateMinimumQuality();
        }

        /// <summary>
        /// Validates the maximum quality of an award
        /// </summary>
        protected virtual void ValidateMaximumQuality()
        {
            if (Quality > (int)NumericalConstants.Award_Maximum_Quality)
            {
                string message = $"Error detected in award {Name}:";

                message += $"\nQuality cannot be greater than {(int)NumericalConstants.Award_Maximum_Quality}";

                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Validates the minimum quality of an award
        /// </summary>
        private void ValidateMinimumQuality()
        {
            if (Quality < 0)
            {
                string message = $"Error detected in award {Name}:";

                message += $"\nQuality cannot be less than zero";

                throw new ArgumentException(message);
            }
        }
    }
}
