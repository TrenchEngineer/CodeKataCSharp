using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class BlueDistinctionPlus : Award
    {
        public BlueDistinctionPlus(string name, int expiresIn, int quality)
        {
            Name = name;
            ExpiresIn = expiresIn;
            Quality = quality;

        }

        public override void UpdateQuality()
        {
            // Do nothing
        }

        public override void UpdateExpiresIn()
        {
            // Do nothing
        }
    }
}
