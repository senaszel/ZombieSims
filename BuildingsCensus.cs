using System.Collections.Generic;

namespace Dom
{
    public sealed class BuildingsCensus
    {
        private static BuildingsCensus instance = new BuildingsCensus();
        private List<House> buildings;

        private BuildingsCensus()
        {
            buildings = new List<House>();
        }

        public static BuildingsCensus Instance
        {
            get
            {


                return instance;
            }
        }

        internal List<House> Buildings { get => buildings; }
    }
}
