using System;
using System.Collections.Generic;
using System.IO;

namespace MenuProject
{
    public class Menu:IdentifiableEntities
    {
        private List<Dish> _dishes;
        private int _numOfDishes;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ids">the menu should be identified by its name and acronym
        /// identifiers should be all lowercase letters! identifers for menu may not
        /// be necessary because menu will be identified by its index number in
        /// order's arrylist. </param>
        /// <param name="name">menu name</param>
        public Menu(String[] ids, String name): base(ids, name)
        {
            _dishes = new List<Dish>();
            _numOfDishes = 0;
           
        }

        public int NumOfDishes
        {
            get => _numOfDishes;
            set => _numOfDishes = value;
        }
        /// <summary>
        /// should be able to identify itelf by its own identifier, and can locate items in the menu
        /// </summary>
        public override void Locate()
        {
        }

        public override void Load(string fileLocation)
        {
            StreamReader reader = new StreamReader(fileLocation);
            Dish d = new Dish( new string[] {},"","",0);
            try 
            {
                NumOfDishes = reader.ReadInteger();
                for (int i=0;i<NumOfDishes;i++)
                {
                    d.Load(fileLocation);
                    addDish(d);
                }
            }
            finally
            {
                reader.Close();
            }
            
        }

        public override void Save(string fileLocation)
        {
            StreamWriter writer = new StreamWriter(fileLocation);
            try
            {
                writer.WriteLine(NumOfDishes);
                foreach (Dish d in Dishes)
                {
                    d.Save(fileLocation);
                }

            }
            finally
            {
                writer.Close();
            }
        }

        public List<Dish> Dishes
        {
            get { return _dishes; }
        }

        public void addDish(Dish d)
        {
            _dishes.Add(d);
            NumOfDishes++;
            
        }

        public void deleteDish(int num)
        {
            _dishes.RemoveAt(num - 1);
        }

    }
}
