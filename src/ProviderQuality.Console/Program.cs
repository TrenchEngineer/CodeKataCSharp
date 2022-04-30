using System.Collections.Generic;

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
                    new GovQualityPlus ("Gov Quality Plus", 10, 20),
                    new BlueFirst ("Blue First", 2, 0),
                    new AcmePartnerFacility ("ACME Partner Facility", 5, 7),
                    new BlueDistinctionPlus ("Blue Distinction Plus", 0, 80),
                    new BlueCompare ("Blue Compare", 15, 20),
                    new TopConnectedProviders ("Top Connected Providers", 3, 6)
                }

            };

            //app.UpdateQuality();

            foreach(Award award in app.Awards)
            {
                award.UpdateAward();
                System.Console.WriteLine(award.GetType().Name);
                System.Console.WriteLine(award.getName());
                System.Console.WriteLine(award.getExpiresIn());
                System.Console.WriteLine(award.getQuality());
            }

            System.Console.ReadKey();

        }

        /*public void UpdateQuality()
        {
            for (var i = 0; i < Awards.Count; i++)
            {
                if (Awards[i].Name != "Blue First" && Awards[i].Name != "Blue Compare")
                {
                    if (Awards[i].Quality > 0)
                    {
                        if (Awards[i].Name != "Blue Distinction Plus")
                        {
                            Awards[i].Quality = Awards[i].Quality - 1;

                        }
                    }
                }
                else
                {
                    if (Awards[i].Quality < 50)
                    {
                        Awards[i].Quality = Awards[i].Quality + 1;

                        if (Awards[i].Name == "Blue Compare")
                        {
                            if (Awards[i].SellIn < 11)
                            {
                                if (Awards[i].Quality < 50)
                                {
                                    Awards[i].Quality = Awards[i].Quality + 1;
                                }
                            }

                            if (Awards[i].SellIn < 6)
                            {
                                if (Awards[i].Quality < 50)
                                {
                                    Awards[i].Quality = Awards[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Awards[i].Name != "Blue Distinction Plus")
                {
                    Awards[i].SellIn = Awards[i].SellIn - 1;
                }

                if (Awards[i].SellIn < 0)
                {
                    if (Awards[i].Name != "Blue First")
                    {
                        if (Awards[i].Name != "Blue Compare")
                        {
                            if (Awards[i].Quality > 0)
                            {
                                if (Awards[i].Name != "Blue Distinction Plus")
                                {
                                    Awards[i].Quality = Awards[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Awards[i].Quality = Awards[i].Quality - Awards[i].Quality;
                        }
                    }
                    else
                    {
                        if (Awards[i].Quality < 50)
                        {
                            Awards[i].Quality = Awards[i].Quality + 1;
                        }
                    }
                }
            }
        }*/

    }

}
