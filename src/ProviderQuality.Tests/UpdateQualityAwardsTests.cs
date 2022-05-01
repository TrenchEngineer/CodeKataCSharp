using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class UpdateQualityAwardsTests
    {
        [TestMethod]
        public void TestImmutabilityOfBlueDistinctionPlus()
        {
            // Arrange

            var blueDisctionPlusPreChange = TestHelpers.GetBlueDistinctionPlusAward();

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    blueDisctionPlusPreChange
                }
            };

            // Act

            app.Awards.ToList().ForEach(award => award.UpdateAward());

            var blueDisctionPlusPostChange = app.Awards[0];

            // Assert

            Assert.IsTrue(app.Awards.Count == 1);

            Assert.IsTrue(blueDisctionPlusPreChange.GetName() == Constants.BlueDisctinctionPlus);

            Assert.IsTrue(blueDisctionPlusPreChange.GetQuality() == (int)NumericalConstants.Blue_Distinction_Plus_Maximum_Quality);

            Assert.IsTrue(blueDisctionPlusPostChange.GetQuality() == (int)NumericalConstants.Blue_Distinction_Plus_Maximum_Quality);
        }

        [TestMethod]
        public void TestBlueStarQualityDecreasesTwiceAsFastAsNormalAward()
        {
            // Arrange
            var blueStarAwardPreChange = TestHelpers.GetBlueStarAward();
            var genericAwardPreChange = TestHelpers.GetBaseAward(blueStarAwardPreChange.GetExpiresIn(), blueStarAwardPreChange.GetQuality());

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    blueStarAwardPreChange,
                    genericAwardPreChange
                }
            };

            var random = new Random();

            // Act

            // Create enough days to test to ensure that the expiration date is passed
            int daysToTest = random.Next(app.Awards[0].GetExpiresIn() + 1, app.Awards[0].GetExpiresIn() + 10);

            int daysPassed = 0;

            // Used to determine when doubling of quality loss must occur because expiration date has passed
            int daysInExcessOfExpiration = daysToTest - app.Awards[0].GetExpiresIn();

            int initialBlueStarQuality = blueStarAwardPreChange.GetQuality();

            int initialGenericAwardQuality = genericAwardPreChange.GetQuality();

            while (daysToTest > 0)
            {
                app.Awards.ToList().ForEach(award => award.UpdateAward());
                daysToTest--;
                daysPassed++;
            }

            var blueStarAwardPostChange = app.Awards.Where(award => award.GetName() == Constants.BlueStar).FirstOrDefault();

            var genericAwardPostChange = app.Awards.Where(award => award.GetName() == genericAwardPreChange.GetName()).FirstOrDefault();

            int genericAwardQualityPostChange = initialGenericAwardQuality - daysPassed - daysInExcessOfExpiration;

            // Assert

            if (blueStarAwardPostChange != null)
            {
                Assert.IsTrue(blueStarAwardPostChange.GetQuality() == (initialBlueStarQuality - (daysPassed + daysInExcessOfExpiration) * 2));
            }
            else
            {
                Assert.Fail("blueStarAward variable is null");
            }

            if (genericAwardPostChange != null)
            {
                Assert.IsTrue(genericAwardPostChange.GetQuality() == genericAwardQualityPostChange);
            }
            else
            {
                Assert.Fail("genericAwardPostChange variable is null");
            }

            Assert.IsTrue(blueStarAwardPostChange.GetQuality() == 2 * genericAwardQualityPostChange - initialGenericAwardQuality);
        }

        [TestMethod]
        public void TestGenericAwardQualityIsNeverNegativeWhenUpdatingAward()
        {
            //Arrange

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    TestHelpers.GetBaseAward()
                }
            };

            var random = new Random();

            // Act

            // Create enough days to test to ensure that the expiration date is passed
            int daysToTest = random.Next(app.Awards[0].GetExpiresIn() + 100, app.Awards[0].GetExpiresIn() + 1000);

            while (daysToTest > 0)
            {
                app.Awards.ToList().ForEach(award => award.UpdateAward());
                daysToTest--;
            }

            // Assert
            Assert.IsTrue(app.Awards[0].GetQuality() >= 0);
        }

        [TestMethod]
        public void TestAfterExpirationDateQualityDecreasesTwiceAsFast()
        {
            // Arrange

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    TestHelpers.GetBaseAward()
                }
            };

            var random = new Random();

            // Act

            // Create enough days to test to ensure that the expiration date is passed
            int daysToTest = random.Next(app.Awards[0].GetExpiresIn() + 1, app.Awards[0].GetExpiresIn() + 10);

            int daysPassed = 0;

            // Used to determine when doubling of quality loss must occur because expiration date has passed
            int daysInExcessOfExpiration = daysToTest - app.Awards[0].GetExpiresIn();

            int initialGenericAwardQuality = app.Awards[0].GetQuality();

            while (daysToTest > 0)
            {
                app.Awards.ToList().ForEach(award => award.UpdateAward());
                daysToTest--;
                daysPassed++;
            }

            var genericAwardPostChange = app.Awards.Where(award => award.GetName() == app.Awards[0].GetName()).FirstOrDefault();

            int genericAwardQualityPostChange = initialGenericAwardQuality - daysPassed - daysInExcessOfExpiration;

            genericAwardQualityPostChange = (genericAwardQualityPostChange < 0) ? 0 : genericAwardQualityPostChange;

            // Assert

            Assert.IsTrue(genericAwardPostChange.GetQuality() == genericAwardQualityPostChange);
        }

        [TestMethod]
        public void TestBlueFirstQualityIncreasesOverTime()
        {
            // Arrange

            var blueFirstAwardPreChange = TestHelpers.GetBlueFirstAward();

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    blueFirstAwardPreChange
                }
            };

            var random = new Random();

            // Act

            int qualityPreChange = blueFirstAwardPreChange.GetQuality();

            // Create enough days to test to ensure that the expiration date is passed
            int daysToTest = random.Next(app.Awards[0].GetExpiresIn() + 100, app.Awards[0].GetExpiresIn() + 1000);

            while (daysToTest > 0)
            {
                app.Awards.ToList().ForEach(award => award.UpdateAward());
                daysToTest--;
            }

            // Assert

            Assert.IsTrue(app.Awards[0].GetQuality() > qualityPreChange);
        }

        [TestMethod]
        public void TestBlueCompareQualityAcceleratesThenDropsToZeroOverTime()
        {
            // Arrange

            var blueCompareAwardPreChange = TestHelpers.GetBlueCompareAward();

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    blueCompareAwardPreChange
                }
            };

            var random = new Random();

            // Act

            int expiresInPreChange = blueCompareAwardPreChange.GetExpiresIn();

            int qualityPreChange = blueCompareAwardPreChange.GetQuality();

            // Create enough days to test to ensure that the expiration date is passed
            int daysToTest = app.Awards[0].GetExpiresIn() + 1;

            int doublingDay = random.Next((int)NumericalConstants.Blue_Compare_Second_Expiration_Period + 1, (int)NumericalConstants.Blue_Compare_First_Expiration_Period);

            int triplingDay = random.Next(0, (int)NumericalConstants.Blue_Compare_Second_Expiration_Period);

            int qualityOnDoublingDay = 0;

            int qualityOnTriplingDay = 0;

            int qualityAtNegativeOneDay = 0;

            while (daysToTest > 0)
            {
                app.Awards.ToList().ForEach(award => award.UpdateAward());

                // Store the quality on a random day in variables for later re-calculation
                if (app.Awards[0].GetExpiresIn() == doublingDay) qualityOnDoublingDay = app.Awards[0].GetQuality();

                if (app.Awards[0].GetExpiresIn() == triplingDay) qualityOnTriplingDay = app.Awards[0].GetQuality();

                daysToTest--;
            }


            int recalcedDoublingQuality = qualityPreChange
                + (expiresInPreChange - (int)NumericalConstants.Blue_Compare_First_Expiration_Period)
                + ((int)NumericalConstants.Blue_Compare_First_Expiration_Period - doublingDay) * 2;

            int recalcedTriplingQuality = qualityPreChange
                + (expiresInPreChange - (int)NumericalConstants.Blue_Compare_First_Expiration_Period)
                + ((int)NumericalConstants.Blue_Compare_First_Expiration_Period - (int)NumericalConstants.Blue_Compare_Second_Expiration_Period) * 2
                + ((int)NumericalConstants.Blue_Compare_Second_Expiration_Period - triplingDay) * 3;

            // Assert

            Assert.IsTrue(qualityOnDoublingDay == recalcedDoublingQuality);

            Assert.IsTrue(qualityOnTriplingDay == recalcedTriplingQuality);

            Assert.IsTrue(app.Awards[0].GetQuality() == qualityAtNegativeOneDay);
        }
    }
}
