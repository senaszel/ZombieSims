using System;
using System.Collections.Generic;
using System.Linq;

namespace Dom
{
    internal class LinqMenu : Menu
    {
        private List<Person> people;

        public LinqMenu()
            : base()
        {
            people = new List<Person>();
            LoadListOfPeople();

            Add(new MenuItem() { Function = MPeople, Name = "People whose names start with M", Distance = 1 });
            Add(new MenuItem() { Function = Forty, Name = "40yo Person from unalphabetical", Distance = 1 });


        }

        private void Forty(object obj)
        {
            var forty = people.OrderByDescending(x => x.Age).ThenByDescending(x => x.FirstName).First(x => x.Age > 40);
            Console.Write("First person from unalphabetically ordered list that is 40 years old is:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{forty}");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void MPeople(object obj)
        {
            List<Person> mPeople = people.Where(x => x.LastName.StartsWith("M")).ToList();
            Console.Clear();
            Console.WriteLine("Nuber of people whose names start with M: {0}\n", mPeople.Count);
            mPeople.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        private void LoadListOfPeople()
        {
            people.Add(new Person("Marek", "Marecki", 41));
            people.Add(new Person("Wojtek", "Wojciechowski", 22));
            people.Add(new Person("Maciej", "Maciejewski", 21));
            people.Add(new Person("Kajetan", "Kajetanowicz", 19));
            people.Add(new Person("Darek", "Darecki", 49));
            people.Add(new Person("Michał", "Michałowski", 51));
            people.Add(new Person("Grzegorz", "Grzegorzewski", 19));
            people.Add(new Person("Andrzej", "Andrzejewski", 18));
            people.Add(new Person("Marcin", "Marcinkiewicz", 58));
            people.Add(new Person("Jan", "Janowski", 58));
            people.Add(new Person("Paweł", "Pawelski", 84));
            people.Add(new Person("Zbigniew", "Hołdys", 19));
        }
    }
}