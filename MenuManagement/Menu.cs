using System;
using System.Collections.Generic;
using System.IO;

namespace MenuManagement
{
    public class Menu : IdentifiableEntities
    {
        //<summary>
        // Menu class are inherited from IdentifiableEntities.
        // A menu stores a list of dishes in it.
        // Menu can be add and delect from here.
        // Menu can be displayed.
        // </summary>
        private List<Dish> _dishes;
        public Menu(String[] ids, String name)
            : base(ids, name)
        {
            _dishes = new List<Dish>();
        }

        public void Write(StreamWriter writer)
        {
            writer.WriteLine(this.Identifiers.Count);
            writer.WriteLine(_dishes.Count);
            foreach(Dish dish in _dishes)
            {
                dish.Write(writer);
            }
        }

        public List<Dish> Dishes
        {
            get { return _dishes; }
        }

        //This function can add dish to the dish list in the menu
        public void addDish(Dish d)
        {
            _dishes.Add(d);
        }

        //This function can delect dish to the dish list in the menu
        public void deleteDish(int num)
        {
            _dishes.RemoveAt(num - 1);
        }
        //This function can display the menus
        public void DisplayDish()
        {
            Console.WriteLine("      *****" + Name + "*****");
            for (int i = 0; i < _dishes.Count; i++)
            {   
                Console.WriteLine((i+1).ToString() + ". " + _dishes[i].Name + " ");
                Console.WriteLine("  " + _dishes[i].Description);
                Console.WriteLine("  Price: " + _dishes[i].Price.ToString());
            }
        }
    }
}
