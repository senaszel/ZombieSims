using System;
using System.Collections.Generic;
using System.Linq;

namespace Dom
{
    public class LinqTable
    {
        private Dictionary<int, string> dictMayors;
        private Dictionary<int, string> dictNames;
        private Dictionary<int, string> dictLastNames;
        private List<Student> listOfStudents;

        public List<Student> ListOfStudents { get => listOfStudents; set => listOfStudents = value; }
        public Dictionary<int, string> DictMayors { get => dictMayors; }
        public Dictionary<int, string> DictNames { get => dictNames; }
        public Dictionary<int, string> DictLastNames { get => dictLastNames; }

        public LinqTable()
        {
            ListOfStudents = new List<Student>();
            LoadDictionaries();
        }

        private void LoadDictionaries()
        {
            dictMayors = new Dictionary<int, string>
            {
                { 0, "Teology" },
                { 1, "Biology" },
                { 2, "Math" },
                { 3, "IT" },
                { 4, "Sports" },
                { 5, "Enginering" },
                { 6, "Medicine" },
                { 7, "Languages" }
            };

            dictNames = new Dictionary<int, string>
            {
                { 0, "Sheldon" },
                { 1, "Marek" },
                { 2, "Grzegorz" },
                { 3, "Pawel" },
                { 4, "Artur" },
                { 5, "Kuba" },
                { 6, "Fuat" },
                { 7, "Oscar" }
            };

            dictLastNames = new Dictionary<int, string>
            {
                { 0, "Dar" },
                { 1, "Maer" },
                { 2, "Baer" },
                { 3, "Gaer" },
                { 4, "Rae" },
                { 5, "vdR" },
                { 6, "Szum" },
                { 7, "Grim" }
            };
        }

        /*
         * Co bym nie zapomnial. Ostatnio widzialem czyjes utyskiwanie na wprowadzanie zmiennych lokalnych.
         * Ja bym to zostawil w takiej formie jak jest dla czytelnosci.
         *
         * Wiadomo ze w tej petli mozna by dac wszystko w jednej linijce...
         * Tylko czy powinno sie?
         * Czy istnieje jakies wytyczne co tego?
         * 
         */
        public List<Student> CreateList()
        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int id = i + 1;
                dictNames.TryGetValue(rand.Next(8), out string firstname);
                dictLastNames.TryGetValue(rand.Next(8), out string lastname);
                dictMayors.TryGetValue(rand.Next(8), out string mayor);
                int semester = rand.Next(1, 9);

                ListOfStudents.Add(new Student(id, firstname, lastname, semester, mayor));

            }


            return ListOfStudents;
        }

        public List<Student> ShowRecordsPerPage(int elementsPerPage, int pageNumber)
        {
            if ((elementsPerPage * pageNumber) > this.ListOfStudents.Count || (elementsPerPage * pageNumber) <= 0)
            {
                return null;
            }


            return this.ListOfStudents.Skip(elementsPerPage * (pageNumber - 1)).Take(elementsPerPage).ToList();
        }

        /*
         * 
         *  Czy jest akceptowalnym 
         *  przerobic te metode aby umozliwic jej testowanie? 
         *  w sensie nie na czas pracy nad nia tylko na stale
         *  bo jakby powsadzac tutaj ifa odcinajacego input z konsoli 
         *  to moglbym to normalnie testowac xunitem za pomoca InlineData
         * 
         * 
         */
        public void AccessRecords()
        {
            int elementsPerPage;
            do
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\n\tHow would you like records to be presented?");
                Console.WriteLine("\n\t\tHow many records per page?");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    elementsPerPage = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    elementsPerPage = -1;
                    Console.Clear();
                }

            } while (elementsPerPage < 0);

            int pageNumber;
            do
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\t\tWhich page?");
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    pageNumber = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    /*
                     * Te 3 linijki totalnie leca do Extension Method
                     */
                }
                catch (Exception)
                {
                    pageNumber = -1;
                    Console.Clear();
                }

            } while (pageNumber < 1);

            ListOfStudents = ShowRecordsPerPage(elementsPerPage, pageNumber);

            if (ListOfStudents is null)
            {
                Console.WriteLine("There is no records to present!");
            }
            else
            {
                ListOfStudents.ForEach(x => Console.WriteLine(x.ToString()));
            }

            Console.ReadKey();
        }



    }
}