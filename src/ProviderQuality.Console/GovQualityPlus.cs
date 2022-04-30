using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class GovQualityPlus : Award
    {
        public GovQualityPlus(string name, int expiresIn, int quality)
        {
            Name = name;
            ExpiresIn = expiresIn;
            Quality = quality;
        }
    }
}
