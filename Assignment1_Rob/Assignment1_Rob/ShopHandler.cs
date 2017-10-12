using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQShop
{
    class ShopHandler 
    {
        private ItemInventory inventory;

        //constructor
        public ShopHandler()
        {
            inventory = new ItemInventory();
        }

        public IEnumerable<Item> itemsList { get; set; }

        //Add methods to: 

       public List<Item> SortByPrice()
        {
            return inventory.GetAllItems().OrderBy(e => e.Price).ToList();
        }

        public List<Item> SortByName()
        {
            return inventory.GetAllItems().OrderBy(e => e.Name).ToList();
        }

        public List<Item> SortByPriceName()
        {
            return inventory.GetAllItems().OrderBy(e => e.Price).ThenBy(e => e.Name).ToList();
        }

        public void OrderPriceGroupByCategory()
        {

            var groups = inventory.GetAllItems().OrderBy(e => e.Price).GroupBy(e => e.Cat);

            foreach (var item in groups)
            {
                Console.WriteLine(item.Key);
            }
        }

        public void OptionError(string s)
        {
            Console.WriteLine("Not a valid menu option: " +s);
        }

        public List<Item> SearchByName(string name, bool exact)
        {
            if (exact)
            {
                return inventory.GetAllItems().Where(e => e.Name.Equals(name)).ToList();
            }
            else
            {
                return inventory.GetAllItems().Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
            }

        }

        public List<Item> SearchByPrice(double low, double high)
        {
            return inventory.GetAllItems().Where(e => e.Price > low && e.Price < high).ToList();
        }

        public List<Item> SearchByPriceAndName(double low, double high, string name)
        {
            return inventory.GetAllItems().Where(e => e.Price > low && e.Price < high && e.Name.Contains(name)).ToList();
        }

        public void SearchByPriceOrNameInCat(double low, double high, string name, Category cat)
        {
            if (low > 0 || high > 0)
            {
                var p = inventory.GetAllItems().OrderBy(e => e.Price > low && e.Price < high).GroupBy(e => e.Cat).ToList();
            }
            else
            {
                var n = inventory.GetAllItems().OrderBy(e => e.Name.Contains(name)).GroupBy(e => e.Cat).ToList();

                foreach (var item in n)
                {
                    Console.WriteLine(item.Key);
                }
            }

           
        }

        //return items sorted by price/name/price and name/price grouped by category
        //Also to search based on name, price or both at the same time.
        //Use LINQ to query/filter/order/group the items.



    }
}
