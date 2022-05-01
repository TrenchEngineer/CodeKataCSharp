using System;
using System.Collections.Generic;
using System.Linq;

namespace ProviderQuality.Console
{
    public class Program
    {
        public IList<Award> Awards
        {
            get;
            set;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Updating award metrics...!");

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award (Constants.GovQualityPlus, 10, 20),
                    new BlueFirst (Constants.BlueFirst, 2, 0),
                    new Award (Constants.AcmePartnerFacility, 5, 7),
                    new BlueDistinctionPlus (Constants.BlueDisctinctionPlus, 0, 80),
                    new BlueCompare (Constants.BlueCompare, 15, 20),
                    new Award (Constants.TopConnectedProviders, 3, 6),
                    new BlueStar(Constants.BlueStar, 5, 50)
                }

            };

            // Verifies that any initial data does not violate the award quality constraints
            try
            {
                app.Awards.ToList().ForEach(award => award.ValidateQuality());
            }
            catch(Exception e)
            {
                System.Console.WriteLine($"{e.Message}\n\nPress any key to exit application.");

                System.Console.ReadKey();

                Environment.Exit(0);
            }
            
            app.Awards.ToList().ForEach(award => award.UpdateAward());

            System.Console.WriteLine("Awards updated, press any key to exit application.");

            System.Console.ReadKey();

        }
    }
}
