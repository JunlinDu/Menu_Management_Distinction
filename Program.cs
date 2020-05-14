using System;

namespace MenuProject
{
    class MainClass
    {
        /// <summary>
        /// the restaurant name, used temporarily, will be modified
        /// reuable later.
        /// </summary>
        public static String a = "Suzuran";

        public static void Main(string[] args)
        {
            String input;
            startMenu(a);
            input = Console.ReadLine();
            do
            {
                Console.WriteLine("test");
                input = Console.ReadLine();
            } while (input != "q");
        }

        public static void startMenu(String a)
        {
            Console.WriteLine("Welcome to {0}", a);
            Console.WriteLine("Please type anything to view menu and start your order...");
        }
    }
}
