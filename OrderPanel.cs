using System;
using System.Collections.Generic;
using System.IO;
namespace MenuProject
{
    public class OrderPanel:IdentifiableEntities
    {
        private List<Menu> _menuList;
        private List<Dish> _orderList;
        private double totalPrice;

        public OrderPanel():base
            (new String[] {"op", "order panel" }, "Order Panel")
        {
            _menuList = new List<Menu>();
            _orderList = new List<Dish>();
        }


        /// <summary>
        /// this method should be able to load information from a
        /// text file, adding different menu to the menu list.
        /// </summary>
        public override void Load(string fileLocation)
        {
            Menu m = new Menu(new string[] { },"new name");
            StreamReader reader = new StreamReader(fileLocation);
            try
            {
                m.Load(fileLocation);
                _menuList.Add(m);
            }
            finally 
            {
                reader.Close();
            }
        }

        public override void Save(string fileLocation)
        {

        }

        public override void Locate()
        {
        }


        /// <summary>
        /// this method shoule be able to be called for the customer to finalize their orders
        /// </summary>
        public void processOrder()
        {
            clearOrderList();
        }

        /// <summary>
        /// the orderList should be cleared after customers finish ordering
        /// </summary>
        private void clearOrderList()
        {

        }

        public void addDishToOrder()
        {

        }

        public void deleteDishFromOrder()
        {

        }

    }
}
