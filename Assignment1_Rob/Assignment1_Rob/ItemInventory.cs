using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQShop
{
    public class ItemInventory
    {
        private List<Item> itemList = null;

        //Constructor
        public ItemInventory()
        {

            //Sample items to retrieve
            itemList = new List<Item>()
            {
                new Item{ ID=1, Cat = Category.Food, Name= "Köttbullar", Price = 39.50},
                new Item{ ID=2,Cat = Category.Food, Name= "Pizza", Price = 29.50},
                new Item{ ID=3,Cat = Category.Drinks, Name= "Mjölk", Price = 29.50},
                new Item{ ID=4,Cat = Category.Drinks, Name= "Juice", Price = 29.50},
                new Item{ ID=5,Cat = Category.Bread, Name= "Frukostbröd", Price = 18.00},
                new Item{ ID=6,Cat = Category.Sport, Name= "Yogamatta", Price = 99.00},
                new Item{ ID=7,Cat = Category.Sport, Name= "Boxningshandskar", Price = 200.00},
                new Item{ ID=8,Cat = Category.Books, Name= "Gudfadern", Price = 59.00},
                new Item{ ID=9,Cat = Category.Books, Name= "Bröderna Lejonhjärta", Price = 71.00},
                new Item{ ID=10,Cat = Category.Books, Name= "Ta bättre bilder", Price = 150.00},
                new Item{ ID=11,Cat = Category.Bread, Name= "Hårdbröd", Price = 12.00},
            };
        }

        public IEnumerable<Item> GetAllItems()
        {
            return itemList;
        }
    }

    
    

}
