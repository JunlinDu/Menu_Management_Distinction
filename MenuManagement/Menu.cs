using System;
using System.Collections.Generic;
namespace MenuManagement
{
    public class Menu : IdentifiableEntities
    {
        private List<Dish> _dishes;
        public Menu(String[] ids, String name)
            : base(ids, name)
        {
            _dishes = new List<Dish>();
        }

        public List<Dish> Dishes
        {
            get { return _dishes; }
        }

        public void addDish(Dish d)
        {
            _dishes.Add(d);
        }

        public void deleteDish(int num)
        {
            _dishes.RemoveAt(num - 1);
        }

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
