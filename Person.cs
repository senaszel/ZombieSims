using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName}";
        }

        //nadpisz metodę ToString() dla klasy Person która będzie zwracać Imię.

    }
}