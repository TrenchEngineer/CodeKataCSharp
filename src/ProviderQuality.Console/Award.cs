using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void UpdateAward()
        {
            UpdateQualityPreExpiration();

            UpdateExpiresIn();

            UpdateQualityPostExpiration();
        }

        protected virtual void UpdateQualityPreExpiration()
        {
            // If the quality is greater than zero always decrement it
            if (Quality > 0) Quality--;
        }

        protected virtual void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed decrement the quality again
            if (ExpiresIn < 0 && Quality > 0) Quality--;            
        }

        protected virtual void UpdateExpiresIn()
        {
            ExpiresIn--;
        }

        public virtual string GetName() { return Name; }

        public virtual int GetExpiresIn() { return ExpiresIn; }

        public virtual int GetQuality() { return Quality; }

        public void ValidateQuality()
        {
            ValidateMaximumQuality();
            ValidateMinimumQuality();
        }

        protected virtual void ValidateMaximumQuality()
        {
            if (Quality > (int)NumericalConstants.Award_Maximum_Quality)
            {
                string message = $"Error detected in award {Name}:";

                message += $"\nQuality cannot be greater than {(int)NumericalConstants.Award_Maximum_Quality}";

                throw new ArgumentException(message);
            }
        }

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
