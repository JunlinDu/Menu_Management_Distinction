using System;
using System.Linq;
using System.IO;
namespace MenuManagement
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Authentication.RegisterAuthentication("admin", "12345");
            Authentication.RegisterAuthentication("managerOne", "qwerty");
            Authentication.RegisterAuthentication("managerTwo", "asdfgh");

            String input;
            String inputTwo;
            Console.WriteLine("Welcome to restaurant Menu Management system, You are a: ");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Customer");
            Console.WriteLine("Press 'q' to Exit");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    do
                    {
                        Console.Write("User Name ->  ");
                        input = Console.ReadLine();
                        Console.Write("Password ->  ");
                        inputTwo = Console.ReadLine();
                        var result = Authentication.Identify(input, inputTwo);
                        if(result == AuthenticationResult.nameNPasswordCorrect)
                        {
                            Console.WriteLine("Welcome!");
                            Console.WriteLine("Manager Functions need to be added..");
                            //Manager Functions need to be added
                        }
                        else if(result == AuthenticationResult.passwordIncorrect)
                        {
                            Console.WriteLine("Incorrect Password");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect User Name");
                        }
                        Console.WriteLine("Do you want to continue?");
                        input = Console.ReadLine();
                    } while (!input.ToLower().Equals("n") || !!input.ToLower().Equals("no"));
                    break;
                case "2":
                    OrderPanel panel = new OrderPanel();
                    panel.Load("menu_list.txt");
                    do
                    {
                        startMenu();
                        input = Console.ReadLine();
                        OrderingState state;
                        do
                        {
                            state = CumstomerFunctions(input, panel);
                        } while (!state.Equals(OrderingState.OrderFinalized));
                    } while (true);
                case "q":
                    break;
                default:
                    break;
            }
        }


        public static OrderingState CumstomerFunctions(String ipt, OrderPanel panel)
        {
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. View - Edit - Finalize My Order");
            Console.Write("Please Enter Your Choice ->  ");
            ipt = Console.ReadLine();
            Console.Write("\n \n \n");
            switch (ipt)
            {
                case "1":
                    ipt = DisplayMenus(panel);
                    Console.Write("\n \n \n");
                    while (!ipt.Equals("q"))
                    {
                        int option;
                        String str;
                        do
                        {
                            if (int.TryParse(ipt, out option))
                            {
                                Menu menu = panel.ChooseMenu(Int32.Parse(ipt));
                                if (menu != null)
                                {
                                    menu.DisplayDish();
                                    Console.Write("Please Enter Your Choice (Press 'q' to Exit to the Previous Level) ->  \n");
                                    str = Console.ReadLine();
                                    Console.Write("\n \n \n");
                                    if (int.TryParse(str, out option))
                                    {
                                        str = panel.addDishToOrder(menu, Int32.Parse(str));
                                        Console.WriteLine(str);
                                        Console.Write("\n \n \n");
                                        if (str != "*********Please Re-Enter*********")
                                        {
                                            break;
                                        }
                                    }
                                    else if (str.Equals("q"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("*********Please Re-Enter*********\n\n");
                                    }
                                }
                                else
                                {
                                    Console.Write("*********Please Re-Enter*********\n\n");
                                    break;
                                }
                            }
                            else
                            {
                                Console.Write("*********Please Re-Enter*********\n\n");
                                break;
                            }
                        } while (!str.Equals("q"));
                        ipt = DisplayMenus(panel);
                        Console.Write("\n \n \n");
                    }
                    return OrderingState.ViewingMenu;
                case "2":
                    OrderingState state;
                    do
                    {
                        state = FinalizedOrder(panel);
                        if(state == OrderingState.OrderFinalized)
                        {
                            break;
                        }
                    } while (!state.Equals(OrderingState.ExitToPreviousLevel));
                    return state;
                default:
                    Console.Write("*Please Re-Enter Your Choice*\n");
                    return OrderingState.UnidentifiedInput;
            }
        }

        public static String DisplayMenus(OrderPanel panel)
        {
            Console.WriteLine("  ***Menu***");
            panel.displayMenu();
            Console.Write("Please Enter Your Choice (Press 'q' to Exit to the Previous Level) ->  ");
            return Console.ReadLine();
        }

        public static OrderingState FinalizedOrder(OrderPanel panel)
        {
            if(panel.OrderList.Count == 0)
            {
                Console.WriteLine("You Don't Have Any Orders Yet");
                Console.WriteLine("Press Enter to Exit to the Previous Level");
                Console.ReadLine();
                Console.Write("\n \n \n");
                return OrderingState.ExitToPreviousLevel;
            }
            else
            {
                Console.WriteLine("    ** Your Orders **");
                panel.displayOrder();
                Console.Write("\n \n \n");
                Console.WriteLine("Please:");
                Console.WriteLine("1. ** Delete Orders **");
                Console.WriteLine("   By Selecting the Number Corresponding to Your Dish in the Orders List");
                Console.WriteLine("2. ** Finalize Orders **");
                Console.WriteLine("   By Typing 'f'");
                Console.Write("Your Choice (Press 'q' to Exit to the Previous Level) -> ");
                String choice = Console.ReadLine();
                int n;
                if (int.TryParse(choice, out n))
                {
                    if (Int32.Parse(choice) <= panel.OrderList.Count)
                    {
                        Console.Write("\n \n \n");
                        Console.WriteLine("*******" + panel.deleteDishFromOrder(Int32.Parse(choice)) + "********");
                        Console.Write("\n \n \n");
                        return OrderingState.ViewingMenu;
                    }
                    else
                    {
                        Console.WriteLine("Please Re-Enter a number");
                        return OrderingState.UnidentifiedInput;
                    }
                }
                else if (choice.Equals("f"))
                {
                    panel.FinalizeOrder();
                    return OrderingState.OrderFinalized;
                }
                else if (choice.Equals("q"))
                {
                    Console.Write("\n \n \n");
                    return OrderingState.ExitToPreviousLevel;
                }
                else
                {
                    Console.WriteLine("Please Re-Enter Your Choice");
                    return OrderingState.UnidentifiedInput;
                }
            }
        }

        

        public static void startMenu()
        {
            Console.Write("\n \n \n");
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please type anything to view menu and start your order...");
        }
    }
}
