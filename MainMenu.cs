using System;
using System.Collections.Generic;
using System.Linq;

namespace Dom
{
    class MainMenu : Menu
    {

        public MainMenu()
            : base()
        {
            Add(new MenuItem() { Function = InsertIntoHouse, Name = "Insert Sim into House", Distance = 1 });
            Add(new MenuItem() { Function = LookForSim, Name = "Look For Sim", Distance = 2 });
            Add(new MenuItem() { Function = CreateNewTennat, Name = "Create New Tennant", Distance = 1 });
            Add(new MenuItem() { Function = CreateNewHouse, Name = "Create New House", Distance = 1 });
            Add(new MenuItem() { Function = null, Name = string.Empty, Distance = 1 });
            Add(new MenuItem() { Function = WiecejLinq, Name = "#7 Linq", Distance = 2 });
            Add(new MenuItem() { Function = TabelaLinq, Name = "#8 Linq Table", Distance = 1 });
        }

        private void WiecejLinq(object obj)
        {
            Menu linqMenu = new LinqMenu();
            linqMenu.Start();
        }

        private void LookForSim(object obj)
        {
            Sim ret = null;
            string target;
            do
            {

                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("\n\tWho are we looking for, operator?");
                        Console.WriteLine("for abort, just order \"abort\"");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        target = Console.ReadLine();
                        if (target.ToUpper() == "ABORT")
                        {
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        target = string.Empty;
                    }

                } while (target.Length < 1);

                try
                {
                    ret = PopulationCensus.Instance.Sims.Find(x => x.Name.ToUpper().Equals(target.ToUpper()));
                }
                catch (Exception)
                {

                }
            } while (ret is null);
            Console.ResetColor();
            Console.WriteLine("\n\t\t{0}", ret.ToString());
            Console.WriteLine("\t\tI repeat: {0}", ret.LocatedAt);
            Console.ReadKey();
        }


        private void TabelaLinq(object obj)
        {
            LinqTable tabelaLinq = new LinqTable();
            List<Student> listOfStudents = tabelaLinq.CreateList();

            Console.WriteLine("\t\tL I N Q");
            Console.WriteLine("\n\tNumber of students loaded: {0}", listOfStudents.Count);

            tabelaLinq.AccessRecords();
        }


        private void CreateNewHouse(object obj)
        {
            string color = string.Empty;
            do
            {
                try
                {
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("What color symbolize best house you have in mind according to fate of its tennants?");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    color = Console.ReadLine();
                    if (!(color.All(x => char.IsLetter(x))))
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    color = string.Empty;
                }
            } while (color.Length < 1);
            Console.ResetColor();

            double size = 0.0;
            do
            {
                try
                {
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("How big is it? Aprox in sq meters: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    string _size = Console.ReadLine();
                    if (!(_size.All(x => char.IsDigit(x) || x.Equals('.'))))
                    {
                        throw new Exception();
                    }
                    size = Convert.ToDouble(_size);
                }
                catch (Exception)
                {
                    size = -1;
                }
            } while (size < 0);
            Console.ResetColor();

            House newHouse = new House(color, size);
            Console.Write("\nThere is ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", newHouse.ShortToString());
            Console.ResetColor();
            Console.Write(" in this very neighberhood...");
            Console.ReadKey();
        }


        private void InsertIntoHouse(object obj)
        {
            Console.Clear();
            Console.WriteLine("Which Sim will be allocated?\n");
            Menu simMenu = new SimMenu();
            simMenu.Start();
        }


        private void CreateNewTennat(object obj)
        {
            string name = string.Empty;
            do
            {
                try
                {
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("How do you call him/she?");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    name = Console.ReadLine();
                    if (!(name.All(x => char.IsLetter(x))))
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    name = string.Empty;
                }
            } while (name.Length < 1);
            Console.ResetColor();

            name = String.Concat(name.First().ToString().ToUpper(), name.Substring(1, name.Length - 1));
            Sim @new = new Sim(name);
            Console.WriteLine("He/She died at birth");
            ConsoleKey proceed;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@new.ToString());
                Console.ResetColor();
                Console.WriteLine(" has been created.");
                Console.Write("\n\tWelcome him with nice ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("enter!");
                Console.ResetColor();
                proceed = Console.ReadKey().Key;
            } while (proceed != ConsoleKey.Enter);
        }


    }
}
