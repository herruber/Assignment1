using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a menu and make 
            //calls to ShopHandler for search and sort.


            while (true)
            {


                int input = -1;
                try
                {
                    input = Console.ReadLine()[0];
                }
                catch (Exception e)
                {

                    Console.WriteLine("Input has to be a number");
                }

                switch (input)
                {
                    case 0:
                        break;
                    case 1:

                    default:
                        break;
                }
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
