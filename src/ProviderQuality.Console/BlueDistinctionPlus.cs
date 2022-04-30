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

        public override void UpdateQualityPreExpiration()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by quality updates
        }

        public override void UpdateQualityPostExpiration()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by quality updates
        }

        public override void UpdateExpiresIn()
        {
            // Do nothing, the quality of Blue Distinction Plus uneffected by expiration dates
        }
    }
}
