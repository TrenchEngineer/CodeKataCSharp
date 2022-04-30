using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class Award
    {
        protected string Name;

        protected int ExpiresIn;

        protected int Quality;

        public Award (string name, int epxiresIn, int quality) { 
            Name = name; 

            ExpiresIn = epxiresIn; 

            Quality = quality; 
        }

        public void UpdateAward()
        {
            UpdateQualityPreExpiration();

            UpdateExpiresIn();

            UpdateQualityPostExpiration();
        }

        public virtual void UpdateQualityPreExpiration()
        {
            // If the quality is greater than zero always decrement it
            if (Quality > 0) Quality--;
        }

        public virtual void UpdateQualityPostExpiration()
        {
            // If the expiration date has passed decrement the quality again
            if (ExpiresIn < 0 && Quality > 0) Quality--;            
        }

        public virtual void UpdateExpiresIn()
        {
            ExpiresIn--;
        }

        public virtual string getName() { return Name; }

        public virtual int getExpiresIn() { return ExpiresIn; }

        public virtual int getQuality() { return Quality; }
    }
}
