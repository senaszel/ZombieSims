using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    public sealed class PopulationCensus
    {
        private static PopulationCensus instance = new PopulationCensus();
        private List<Sim> sims;

        private PopulationCensus()
        {
            sims = new List<Sim>();
        }

        public static PopulationCensus Instance
        {
            get
            {


                return instance;
            }
        }

        internal List<Sim> Sims { get => sims; }
    }
}
