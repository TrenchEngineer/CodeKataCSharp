using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class BlueFirst : Award
    {
        public BlueFirst(string name, int expiresIn, int quality)
        {
            Name = name;
            ExpiresIn = expiresIn;
            Quality = quality;
        }
    }
}
