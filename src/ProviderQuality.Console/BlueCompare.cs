using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class BlueCompare : Award
    {
        public BlueCompare(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {
            
        }

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

        protected override void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed and is negative, set the quality to zero
            if (ExpiresIn < 0) Quality = 0;
        }
    }
}
