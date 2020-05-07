using System;

namespace Dom
{
    class Program
    {
        static void Main()
        {
            LoadDemoData();

            Console.WriteLine("\n\n{0,100}","Press F11 for full screen.");
            Console.ReadKey();
            Console.Clear();

            int escapeX3 = 0;
            do
            {
                Menu simsy = new MainMenu();
                escapeX3 += simsy.Start();

            } while (escapeX3 < 4);



        }

        private static void LoadDemoData()
        {
            Sim adolf = new Sim("Adi");
            Sim jozef = new Sim("Jozef");
            House red = new House("Red", 54.33);
            House blue = new House("Blue", 4486.215);
        }
    }
}
