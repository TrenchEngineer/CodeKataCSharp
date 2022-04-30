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

        public void UpdateAward()
        {
            UpdateQuality();
            UpdateExpiresIn();
        }

        public virtual void UpdateQuality()
        {
            if (Quality > 0) Quality--;
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
