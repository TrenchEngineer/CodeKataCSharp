using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class BlueDistinctionPlus : Award
    {
        public BlueDistinctionPlus(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {


        }

        protected override void UpdateQualityPreExpiration()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by quality updates
        }

        protected override void UpdateQualityPostExpiration()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by quality updates
        }

        protected override void UpdateExpiresIn()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by expiration dates
        }

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
