using System;

namespace Dom
{
    class SimMenu : Menu
    {
        public SimMenu()
        {
            foreach (Sim sim in PopulationCensus.Instance.Sims)
            {
                Add(new MenuItem() { Name = sim.ToString(), Function = ChooseHouse, Parameter = sim });
            }
        }

        private void ChooseHouse(object obj)
        {
            Sim sim = obj as Sim;
            TempSim.Instance.Sim = sim;

            Console.Clear();
            Console.WriteLine("Pick a house where {0} will be lived for a moment:", "he/she");
            HousesMenu houses = new HousesMenu();
            houses.Start();
        }

    }
}
