using System;
using System.IO;
using System.Collections.Generic;
using MenuProject;

namespace MenuManagement
{
    //<summary>
    // This is the overall order panel systm.
    // Menus can be loaded from text and display on the system.
    // Customers can choose the menus they want.
    // Customers can order food here.
    // Orders are being processed here.
    // </summary>
    public class OrderPanel
    {
        private List<Menu> _menuList;
        private List<Dish> _orderList;
        private double _dailySaleTotal;
        private int _guestCount;
        public OrderPanel()
        {
            _menuList = new List<Menu>();
            _orderList = new List<Dish>();
            _dailySaleTotal = 0.0;
        }

        public List<Dish> OrderList
        {
            get { return _orderList; }
        }
        
        // This function is used to save the orrder to the text file.
        private void SaveOrder()
        {
            StreamWriter writer = new StreamWriter("order_histroy.txt");
            writer.WriteLine("Guest Number: " + _guestCount);
            foreach (Dish dish in _orderList)
            {
                writer.WriteLine(dish.Name);
            }
            writer.WriteLine("Total: " + calculatePrice());
            writer.WriteLine("Daily Total: " + _dailySaleTotal);
        }

        // This function is used to load the menu and dishes in it form text file.
        public void Load(String fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            int menuCount = reader.ReadInteger();
            try
            {
                for(int i = 0; i < menuCount; i++)
                {
                    String name = reader.ReadLine();
                    _menuList.Add(new Menu(ReadId(reader), name));
                    int dishCount = reader.ReadInteger();
                    for(int idx = 0; idx < dishCount; idx++)
                    {
                        Dish dish = new Dish();
                        String[] ids = ReadId(reader);
                        _menuList[i].Dishes.Add(dish.Load(reader, ids));
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }

        //This funciton is reading dishes from its ID
        private String[] ReadId(StreamReader reader)
        {
            int idCount = reader.ReadInteger();
            String[] ids = new string[idCount];
            for (int i = 0; i < idCount; i++)
            {
                ids[i] = reader.ReadLine();
            }
            return ids;
        }

        //This funciton is used to calculate the total price
        public double calculatePrice()
        {
            double _price = 0.0;
            foreach (Dish dish in _orderList)
            {
                _price += dish.Price;
            }
            return _price;
        }

        //This funciton is used to display the order the customer has placed.
        public void displayOrder()
        {
            Console.WriteLine("****The List Below Shows Dishes That You Have Ordered****");
            for (int i = 0; i < _orderList.Count; i++)
            {
                Console.WriteLine((i+1).ToString() + ". " + _orderList[i].Name + " ······················  " + _orderList[i].Price);
            }
            Console.WriteLine("Total: " + calculatePrice().ToString());
        }

        // This function is used to display the menu in the order panel.
        public void displayMenu()
        {
            for (int i = 0; i < _menuList.Count; i++)
            {
                Console.WriteLine((i+1).ToString() + ". " + _menuList[i].Name);
            }
        }

        // This function is used to process and finalize the order
        public void FinalizeOrder()
        {
            _dailySaleTotal += calculatePrice();
            _guestCount += 1;
            SaveOrder();
            _orderList.Clear();
        }
        // This function is used to choose the menu from all menu listed
        public Menu ChooseMenu(int choice)
        {
            return _menuList[(choice - 1)];
        }

        // This function is used to add dish to the order.
        public String addDishToOrder(Menu menu, int i)
        {
            if (i <= menu.Dishes.Count)
            {
                Dish dish = menu.Dishes[i - 1];
                _orderList.Add(dish);
                return dish.Name + " successfully added!";
            }
            return "*********Please Re-Enter*********";
        }

        // This function is used to delect dish to the order.
        public String deleteDishFromOrder(int i)
        {
            if (i <= _orderList.Count)
            {
                Dish dish = _orderList[i - 1];
                _orderList.RemoveAt(i - 1);
                return dish.Name + " Deleted from Your Order List";
            }
            return "*********Please Re-Enter*********";
        }
    }
}
