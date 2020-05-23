using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using MenuProject;


namespace MenuManagement
{
    public class Management
    {
        private List<Menu> _menus;
        private bool _menuLoaded;
        //use for store user input (temporary),[o] strore id, [1] store name
        //private string[] _tempInfo = new string [2];

        public Management()
        {
            _menus = new List<Menu>();
            _menuLoaded = false;
        }


        //Display menu
        public void Display()
        {
            loadMenu();
            foreach (Menu m in _menus)
            {
                Console.WriteLine("Name:" + m.Name + " ID:" + m.Identifiers);
            }
        }

        //create file for this menu
        public void SaveNewMenu(string name, string id)
        {
            //Create new menu(as a file) in current path
            string fileNameId = name + "id " + id;
            string path = Path.GetTempPath();
            path = Path.Combine(path, fileNameId);
        }


        //Save any new changes to txt file (cover orginal file)
        public void SaveDishChanges(Menu m, string whichMenu)
        {
            string path = Path.GetTempPath();
            using (StreamWriter w = File.AppendText((whichMenu + ".txt")))
            {
                foreach (Menu thisM in _menus)
                {
                    w.WriteLine(thisM.Dishes);
                }
                w.Close();
            }

        }


        //load menus from txt file and save into _menu list
        public void loadMenu()
        {

            //Get all menue file from current directory
            FileInfo[] Files = currendinfo.GetFiles("* Menu.txt");


            //Need to be fixed ( should read dish information from each menu and store into _menus fields.
            foreach (Files f in FileInfor)
            {
                using (StreamReader sr = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), f)))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

            }
            Console.WriteLine("Menu loaded.");

            _menuLoaded = true;

        }


        //Allow mnager creates a new menu
        public void CreateMenu()
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
                    addMenu(tempMenu);
                    SaveNewMenu(thisName, thisId[0]);
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
            _menus.Add(menu);

        }



        //Delete Menu from list
        public void deleteMenu(string name)
        {
            //Determine if menus have been import to _menus field, if not, import them.
            if (_menuLoaded == false)
            {
                loadMenu();
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
