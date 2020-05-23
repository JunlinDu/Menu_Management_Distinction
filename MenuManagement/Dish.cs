using MenuProject;
using System;
using System.IO;
namespace MenuManagement
{
    public class Dish:IdentifiableEntities
    {
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

        public Dish Load(StreamReader reader, String[] ids)
        {
            Identifiers = ids;
            Name = reader.ReadLine();
            Description = reader.ReadLine();
            Price = reader.ReadSingle();
            return this;
        }

        private double priceRange(double num)
        {
            if (num < 150.0 && num > 0.0)
                return num;
            return 0;
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = priceRange(value); }
        }
    }
}
