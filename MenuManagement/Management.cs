using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using MenuProject;
using System.Diagnostics.Contracts;

namespace MenuManagement
{
    public class Management
    {
        private List<Menu> _menuList;
        private bool _menuLoaded;
        //use for store user input (temporary),[o] strore id, [1] store name
        //private string[] _tempInfo = new string [2];

        public Management()
        {
            _menuList = new List<Menu>();
            _menuLoaded = false;
        }

        public void displayMenu()
        {
            for (int i = 0; i < _menuList.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + _menuList[i].Name);
            }
        }
        //Display menu
        public void Display()
        {
            foreach (Menu m in _menuList)
            {
                Console.WriteLine("Name:" + m.Name + " ID:" + m.Identifiers);
            }
        }

        //Save any new changes to txt file (cover orginal file)
        public void SaveDishChanges(Menu m, string whichMenu)
        {
            string path = Path.GetTempPath();
            using (StreamWriter w = File.AppendText((whichMenu + ".txt")))
            {
                foreach (Menu thisM in _menuList)
                {
                    w.WriteLine(thisM.Dishes);
                }
                w.Close();
            }

        }


        //load menus from txt file and save into _menuList
        public void loadMenu(String fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            int menuCount = reader.ReadInteger();
            try
            {
                for (int i = 0; i < menuCount; i++)
                {
                    String name = reader.ReadLine();
                    _menuList.Add(new Menu(ReadId(reader), name));
                    int dishCount = reader.ReadInteger();
                    for (int idx = 0; idx < dishCount; idx++)
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
            _menuLoaded = true;
        }

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



        //Allow mnager creates a new menu
        public void CreateMenu(String fileName)
        {
            //Creat a new menu and ask manager input its id and name
            String[] thisId = new String[1];
            string thisName;

            //loop until user saticifiy with the name and id
            bool finish = false;
            while (finish != true)
            {
                Console.WriteLine("Please enter name for this menu: ");
                thisName = Console.ReadLine();
                Console.WriteLine("Please enter id for this menu: ");
                thisId[0] = Console.ReadLine();

                Console.WriteLine("New Menu's information: ");
                Console.WriteLine("Name: " + thisName);
                Console.WriteLine("Id: " + thisId);
                Console.WriteLine("If you are satisfied, press y, " +
               "if not, press n to re-enter the information ");

                //ensure user input valid options
                string decide = Console.ReadLine().ToLower();
                while (decide != "y" && decide != "n")
                {
                    Console.WriteLine("Invalid input, please re-enter your option: ");
                    decide = Console.ReadLine().ToLower();
                }

                if (decide == "y")
                {
                    Menu tempMenu = new Menu(thisId, thisName);
                    addDish(tempMenu);
                    addMenu(tempMenu);
                    SaveNewMenu(fileName);
                    finish = true; 
                    Console.WriteLine("New menu created.");
                }
                else
                {
                    Console.WriteLine("Plese re-enter menu's information.");
                }

            }
        }

        //Add new menu to menu list.
        public void addMenu(Menu menu)
        {
            _menuList.Add(menu);

        }

        public void addDish(Menu menu)
        {
            String input;
            int i = 1;
            while (true)
            {
                Dish dish = new Dish();
                do
                {
                    Console.WriteLine("Please enter a name for dish " + i.ToString());
                    input = Console.ReadLine();
                    dish.Name = input;
                    Console.WriteLine("Please enter an id for your dish " + i.ToString());
                    input = Console.ReadLine();
                    dish.Identifiers[0] = input;
                    Console.WriteLine("Please enter a description for your dish " + i.ToString());
                    input = Console.ReadLine();
                    dish.Description = input;
                    bool valid = true;
                    do
                    {
                        Console.WriteLine("Please enter a price for your dish " + i.ToString());
                        input = Console.ReadLine();
                        double d;
                        if (double.TryParse(input, out d))
                        {
                            dish.Price = double.Parse(input);
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid!");
                            valid = false;
                        }
                    } while (!valid);

                    do
                    {
                        Console.WriteLine("Do you satisfy with your input?");
                        Console.WriteLine("'y' to move on to the next dish, 'n' to edit the current dish, or 'q' to finish editing dish)");
                        input = Console.ReadLine();
                        if (input.Equals("y"))
                        {
                            menu.addDish(dish);
                            break;
                        }
                        else if (input.Equals("q"))
                        {
                            menu.addDish(dish);
                            Console.WriteLine("Dish Editing Finished");
                            break;
                        }
                        else if (input.Equals("n"))
                        {
                            Console.WriteLine("Edit dish " + i.ToString());
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please Re-enter!");
                        }
                    } while (true);

                } while (input.Equals("n"));

                if (input.Equals("q"))
                {
                    break;
                }
                i++;
            }
        }

        //create file for this menu
        public void SaveNewMenu(String fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(_menuList.Count.ToString());
            foreach(Menu menu in _menuList)
            {
                menu.Write(writer);
            }
        }
        //Delete Menu from list

        public void deleteMenu(string name)
        {
            //Determine if menus have been import to _menus field, if not, import them.
            if (_menuLoaded == false)
            {
                //loadMenu();
            }
            //display them on console.
            Display();

            /*string decide;
            Console.WriteLine("Please enter menu name");
            decide = Console.ReadLine().ToLower();*/

            //Delete the file
            File.Delete(name + ".txt");

        }

    }
}
