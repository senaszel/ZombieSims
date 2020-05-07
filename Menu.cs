using System;
using System.Collections.Generic;
using System.Linq;

namespace Dom
{
    abstract class Menu
    {
        private List<MenuItem> Items;
        private MenuItem SelectedItem
        {
            get
            {
                return Items.FirstOrDefault(x => x.IsSelected == true);
            }

        }

        private int SelectedIndex
        {
            get { return Items.IndexOf(SelectedItem); }
        }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void MoveNext()
        {
            if (SelectedItem != Items.Last())
            {
                int newIndex = SelectedIndex + 1;
                SelectedItem.IsSelected = false;
                Items[newIndex].IsSelected = true;

                if (Items[newIndex].Name == string.Empty)
                {
                    MoveNext();
                }
            }
        }

        public void MoveBack()
        {
            if (SelectedItem != Items.First())
            {
                int newIndex = SelectedIndex - 1;
                SelectedItem.IsSelected = false;
                Items[newIndex].IsSelected = true;

                if (Items[newIndex].Name == string.Empty)
                {
                    MoveBack();
                }

            }
        }

        public void Invoke()
        {
            SelectedItem.Invoke();
        }

        public void Add(MenuItem menuItem)
        {
            Items.Add(menuItem);
            if (Items.Count == 1)
            {
                menuItem.IsSelected = true;
            }
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            foreach (var item in Items)
            {
                if (item.IsSelected)
                {
                    Console.Write("{0}", "".PadLeft(100 - item.Name.Length));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", item.Name);
                    Console.ResetColor();
                }
                else Console.WriteLine("{0,100}", item.Name);
                if (item.Distance > 0)
                {
                    string space = new string('\n', item.Distance);
                    Console.Write("{0}", space);
                }
            }
        }

        public virtual int Start()
        {
            Print();

            ConsoleKey choice = Console.ReadKey(true).Key;
            switch (choice)
            {
                case ConsoleKey.DownArrow:
                    MoveNext();
                    Start();
                    return 0;
                case ConsoleKey.UpArrow:
                    MoveBack();
                    Start();
                    return 0;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.WriteLine("\n\n");
                    Invoke();
                    return 0;
                case ConsoleKey.Escape:
                    return 1;
                default:
                    Start();
                    return 0;
            }
        }

    } //end of Class
} //end of Namespace
