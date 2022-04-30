using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class AcmePartnerFacility : Award
    {
        public AcmePartnerFacility(string name, int epxiresIn, int quality)
        {
            Name = name;
            ExpiresIn = epxiresIn;
            Quality = quality;
        }


    }
}
