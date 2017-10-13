using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQShop
{
    class Program
    {
        static bool isRunning = true;
        static ShopHandler shandler;

        public static void SortMenu()
        {
            List<Item> returnList = new List<Item>();
            Console.WriteLine("0: Exit\n" +
                "1: Sort by Name\n" +
                "2: Sort by Price\n" +
                "3: Sort by Price and Name\n" +
                "4: Sort by Price, Grouped by Category\n" +
                "5: Search by Name\n" +
                "6: search by Price\n" +
                "7: search by Price and Name\n" +
                "8: search by Price OR Name, in Category\n" +
                "--------------------------------------------------");

            List<Item> returnedItems = new List<Item>();

            char input = Console.ReadLine()[0];

            string s = "";
            double low = -1;
            double high = -1;
           

            switch (input)
            {
                case '0':
                    isRunning = false;
                    break;
                case '1':
                    returnedItems = shandler.SortByName();

                    foreach (var item in returnedItems)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case '2':
                    returnedItems = shandler.SortByPrice();

                    foreach (var item in returnedItems)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case '3':
                    returnedItems = shandler.SortByPriceName();

                    foreach (var item in returnedItems)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case '4':
                    shandler.OrderPriceGroupByCategory();
                    break;
                case '5':
                    Console.WriteLine("Input a name: ");
                    s = Console.ReadLine();
                    Console.WriteLine("Exact name y/n: ");
                    char optionyn = Console.ReadLine()[0];

                    if (optionyn == 'y')
                    {
                        returnedItems = shandler.SearchByName(s, true);
                    }
                    else
                    {
                        returnedItems = shandler.SearchByName(s, false);
                    }


                    foreach (var item in returnedItems)
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case '6':
                    Console.WriteLine("Higher than: ");

                    double.TryParse(Console.ReadLine(), out low);

                    Console.WriteLine("Lower than: ");
                   
                    double.TryParse(Console.ReadLine(), out high);

                    returnedItems = shandler.SearchByPrice(low, high);


                    foreach (var item in returnedItems)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case '7':

                    Console.WriteLine("Higher than: ");
                    double.TryParse(Console.ReadLine(), out low);

                    Console.WriteLine("Lower than: ");
                    double.TryParse(Console.ReadLine(), out high);

                    Console.WriteLine("Input a name: ");
                    s = Console.ReadLine();
                    Console.WriteLine("Exact name y/n: ");
                    char optionyn2 = Console.ReadLine()[0];

                    returnedItems = shandler.SearchByPriceAndName(low, high, s);


                    foreach (var item in returnedItems)
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case '8':

                    Console.WriteLine("Pick A category\n" +
                        "0: books 1: bread 2: food 3: drinks 4: sport");

                    char d = Console.ReadLine()[0];

                    Category cat = new Category();

                    switch (d)
                    {
                        case '0':
                            cat = Category.Books; 
                            break;
                        case '1':
                            cat = Category.Bread;
                            break;
                        case '2':
                            cat = Category.Food;
                            break;
                        case '3':
                            cat = Category.Drinks;
                            break;
                        case '4':
                            cat = Category.Sport;
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("Search by price p or name n: ");

                    char e = Console.ReadLine()[0];

                    if (e == 'p')
                    {
                        Console.WriteLine("Higher than: ");
                        double.TryParse(Console.ReadLine(), out low);

                        Console.WriteLine("Lower than: ");
                        double.TryParse(Console.ReadLine(), out high);
                    }
                    else if (e == 'n')
                    {
                        Console.WriteLine("Input a name: ");
                        s = Console.ReadLine();
                    }
                   
                    shandler.SearchByPriceOrNameInCat(low, high, s, cat);


                    ////foreach (var item in returnedItems)
                    ////{
                    ////    Console.WriteLine(item);
                    ////}

                    break;
                default:
                    break;
            }


        }

        static void PrintResults(List<Item> results)
        {

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        
        static void Main(string[] args)
        {
            //Create a menu and make 
            //calls to ShopHandler for search and sort.
            shandler = new ShopHandler();

            
            while (isRunning)
            {
            SortMenu();
            }
        }
    }

    
    /*  
     Enumerations are special sets of named values 
     which all maps to a set of numbers, usually integers. 
     They come in handy when you wish to be able to choose 
     between a set of constant values. 
     Category is here used to define category for Items.
    */
    public enum Category
    {
        Food,
        Drinks,
        Bread,
        Books,
        Sport
    }
}
