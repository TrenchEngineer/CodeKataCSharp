using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class BlueStar : Award
    {
        public BlueStar(string name, int expiresIn, int quality) : base(name, expiresIn, quality)
        {

        }

        protected override void UpdateQualityPreExpiration()
        {
            base.UpdateQualityPreExpiration();
            base.UpdateQualityPreExpiration();
        }

        protected override void UpdateQualityPostExpiration()
        {
            base.UpdateQualityPostExpiration();
            base.UpdateQualityPostExpiration();
        }
    }
}
