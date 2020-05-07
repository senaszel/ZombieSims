using System;

namespace Dom
{
    class HousesMenu : Menu
    {
        public HousesMenu()
        {
            foreach (House house in BuildingsCensus.Instance.Buildings)
            {
                Add(new MenuItem() { Name = house.ToString(), Function = AddToThisHouse, Parameter = house });
            }
        }

        private static void AddToThisHouse(object obj)
        {
            House house = obj as House;
            int outcome = house.TryAddTennant(TempSim.Instance.Sim);
            switch (outcome)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0,100}", "S U C C E S S ! ");
                    Console.ResetColor();
                    Console.WriteLine($"{TempSim.Instance.Sim.ToString()}");
                    break;
                case -1:
                    Console.WriteLine("{0,100}", "Housing Limit Reached. Cannot allocate more tennants.");
                    break;
                case -2:
                    Console.WriteLine("{0,100}", $"{TempSim.Instance.Sim.Name} already lives there.");
                    break;
            }
            Console.ReadKey();

            //if (house.TryAddTennant(TempSim.Instance.Sim))
            //{
            //    Console.WriteLine("{0,100}",$"S U C C E S S ! {TempSim.Instance.Sim.ToString()}");
            //    System.Threading.Thread.Sleep(2000);
            //}
            //else
            //{
            //    Console.WriteLine("{0,100}","Housing Limit Reached. Cannot allocate more tennants.");
            //    System.Threading.Thread.Sleep(2000);
            //}

        }



    }
}
