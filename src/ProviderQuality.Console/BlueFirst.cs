using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class BlueFirst : Award
    {
        public BlueFirst(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {

        }

        public override void UpdateQualityPreExpiration()
        {
            // Increment the quality until it reaches a value of 50
            if (Quality < 50) Quality++;
        }

        public override void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed and the quality is less than 50, increment the quality again
            if (ExpiresIn < 0 && Quality < 50) Quality++;
        }
    }
}
