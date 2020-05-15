using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using MenuManagement;

namespace MenuSystem
{
    public class Management
    {/*
        private List<Menu> _menus;
        //use for store user input (temporary),[o] strore id, [1] store name
        //private string[] _tempInfo = new string [2];

        public Management()
        {
            _menus = new List<Menu>();

        }


        //Display all menu
        public void Display()
        {
            loadMenu();
            foreach (Menu m in _menus)
            {
                Console.WriteLine("Name:" + m.Name + " ID:" + m.Id[0]);
            }
        }

        //load menus from txt file and save into _menu list
        public void loadMenu()
        {
            //current directory
            DirectoryInfo dinfo = new DirectoryInfo(@"C:\Users\mintm\Documents\C#\Development Project\Menu Storage\Menu Storage");

            //Get MenusList txt files (menus) from current directory
            FileInfo[] Files = dinfo.GetFiles("MenusList.txt");

            using (StreamReader sr = File.OpenText(@"C:\Users\mintm\Documents\C#\Development Project\Menu Storage\Menu Storage"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
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
                    SaveChanges();
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

        //Save any new changes to txt file (cover orginal file)
        public void SaveChanges()
        {
            string path = Path.GetTempPath();
            using (StreamWriter w = File.AppendText(("MenusList.txt")))
            {
                foreach (Menu m in _menus)
                {
                    w.WriteLine(m);
                }
                w.Close();
            }

        }


        //TextWriter tw = new StreamWriter("Menus.txt");

        //Delete Menu from list
        public void deleteMenu()
        {
            //load all menus from txt file and display them on console.
            loadMenu();
            Display();

            string decide;
            Console.WriteLine("Which menu you want to delete?");
            decide = Console.ReadLine().ToLower();

            foreach (Menu m in _menus)
            {
                if (decide == m)
                {
                    Console.WriteLine("Delete " + m.Name + " ?");
                    _menus.Remove(m);
                    SaveChanges();
                }
                else
                {
                    Console.WriteLine("The menu you trying to find does not exist.");
                }

            }

        }*/
    }
}
