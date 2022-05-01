using ProviderQuality.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Tests
{
    public static class TestHelpers
    {
        public static BlueDistinctionPlus GetBlueDistinctionPlusAward()
        {
            return new BlueDistinctionPlus(Constants.BlueDisctinctionPlus, 0, 80);
        }

        public static BlueStar GetBlueStarAward()
        {
            return new BlueStar(Constants.BlueStar, 5, 50);
        }

        public static BlueFirst GetBlueFirstAward()
        {
            return new BlueFirst(Constants.BlueFirst, 2, 0);
        }

        public static BlueCompare GetBlueCompareAward()
        {
            return new BlueCompare(Constants.BlueCompare, 12, 20);
        }

        public static Award GetBaseAward()
        {
            return new Award(Constants.GovQualityPlus, 10, 20);
        }

        public static Award GetBaseAward(int expiresIn, int quality)
        {
            return new Award(Constants.GovQualityPlus, expiresIn, quality);
        }
    }
}
