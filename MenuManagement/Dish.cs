using MenuProject;
using System;
using System.IO;
namespace MenuManagement
{
    public class Dish:IdentifiableEntities
    {
        //<summary>
        // Dish class are inherited from IdentifiableEntities.
        // A dish stores its ID, name, price and descrption.
        // Dishes can be loaded form a text file.
        // </summary>

        private String _description;
        private double _price;

        public Dish() : this(new string[] { "dish" }, "name", "desc", 1.2) { }

        public Dish
            (String[] ids, String name, String description, double price)
            :base(ids, name)
        {
            _description = description;
            _price = priceRange(price);
        }

        public void Write(StreamWriter writer)
        {
            writer.WriteLine(this.Identifiers.Count.ToString());
            for(int i = 0; i <this.Identifiers.Count; i++)
            {
                writer.WriteLine(this.Identifiers[i].ToString());
            }
            writer.WriteLine(this.Name);
            writer.WriteLine(this.Description);
            writer.WriteLine(this.Price);
        }

        // This function can load dishes from a text file.
        public Dish Load(StreamReader reader, String[] ids)
        {
            for (int i = 0; i< ids.Length; i++)
            {
                Identifiers.Add(ids[i]);
            }
            Name = reader.ReadLine();
            Description = reader.ReadLine();
            Price = reader.ReadSingle();
            return this;
        }

        // This function can check if the price in within the price range.
        private double priceRange(double num)
        {
            if (num < 150.0 && num > 0.0)
                return num;
            return 0;
        }

        // Full description of the dish
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Price of the dish
        public double Price
        {
            get { return _price; }
            set { _price = priceRange(value); }
        }
    }
}
