using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BugAndExceptions
{
    public class Shop
    {
        public List<ShopItem> ShopItems { get; set; }
        public int totalPrice { get; set; } = 0;
        public Shop()
        {
            ShopItems = new List<ShopItem>();
            ShopItems.Add(new ShopItem { ItemName = "Pizza", Price = 67, Id = "1" });
            ShopItems.Add(new ShopItem { ItemName = "Pants", Price = 499, Id = "2" });
            ShopItems.Add(new ShopItem { ItemName = "Juice", Price = 32, Id = "3" });
            ShopItems.Add(new ShopItem { ItemName = "Milk", Price = 25, Id = "4" });
            ShopItems.Add(new ShopItem { ItemName = "Shirt", Price = 150, Id = "5" });
            ShopItems.Add(new ShopItem { ItemName = "Sweater", Price = 459, Id = "6" });
            ShopItems.Add(new ShopItem { ItemName = "Glasses", Price = 2700, Id = "7" });
            ShopItems.Add(new ShopItem { ItemName = "Computer", Price = 3790, Id = "8" });
            ShopItems.Add(new ShopItem { ItemName = "Phone", Price = 7999, Id = "9" });
            ShopItems.Add(new ShopItem { ItemName = "TV", Price = 13780, Id = "10" });
            ShopItems.Add(new ShopItem { ItemName = "Yoghurt", Price = 30, Id = "11" });
            ShopItems.Add(new ShopItem { ItemName = "Jacket", Price = 750, Id = "12" });
            ShopItems.Add(new ShopItem { ItemName = "Hat", Price = 540, Id = "13" });
            ShopItems.Add(new ShopItem { ItemName = "Cup", Price = 150, Id = "14" });
            ShopItems.Add(new ShopItem { ItemName = "Speaker", Price = 990, Id = "15" });
            ShopItems.Add(new ShopItem { ItemName = "Bread", Price = 30, Id = "16" });
            ShopItems.Add(new ShopItem { ItemName = "Napkin", Price = 50, Id = "17" });
        }

        public static void ResetShoppingCart(Shop shop, Customer customer)
        {
            customer.ShoppingCart.Clear();  
            shop.totalPrice = 0;
            Console.Clear();
            Run(shop, customer);       
        }

        public void PrintItems(Customer customer)
        {
            foreach (var item in ShopItems)
            {
                Console.WriteLine($"item: {item.Id} {item.ItemName} costs {item.Price} {customer.CustomerBankInfo.Currency}.");
            }
        }

        public int CheckOut(Shop shop, Customer customer)
        {
            if (customer.CustomerBankInfo.Balance >= totalPrice)
            {
                customer.BuyItemsInCart();
                customer.CustomerBankInfo.Balance -= totalPrice;
                Console.WriteLine("Thanks for shopping");
                customer.ShoppingCart.Clear();
                Thread.Sleep(4000);
                Run(shop, customer);
            }
            else
            {
                CheckBalance(shop, customer);
            }
           return totalPrice;
        }

        public void CheckBalance(Shop shop, Customer customer)
        {    
            if (customer.CustomerBankInfo.Balance < totalPrice)
            {
                Console.WriteLine("Not enough money");
                Console.WriteLine("S to check balance or Enter to continue");             
                ShowBalance(shop, customer);
                CheckOut(shop, customer);
            }
        }

        private void ShowBalance(Shop shop, Customer customer)
        {
            var userinput = Console.ReadLine();
            if (userinput == "S".ToLower()) 
            { 
                Console.WriteLine(customer.CustomerBankInfo.Balance + customer.CustomerBankInfo.Currency);
                Console.ReadLine();
                customer.ShoppingCart.Clear();
                Run(shop, customer);
            }
            customer.ShoppingCart.Clear();
            Console.Clear();
            Run(shop, customer);
        }

        public static void Run(Shop shop, Customer customer)
        {
            while (true)
            {
                shop.PrintItems(customer);             
                Console.WriteLine();
                Console.WriteLine("What do you want to buy?");
                Console.WriteLine("Purchase cart '0'");
                Console.WriteLine("Reset cart 'r'");
                Console.WriteLine();
                customer.PrintItemsInCart(shop);
                var itemNumber = Console.ReadLine();
                if (itemNumber == "0")
                {
                    shop.CheckOut(shop,customer);
                    shop.CheckBalance(shop, customer);
                }     
                if (itemNumber == "r".ToLower())
                {
                    ResetShoppingCart(shop ,customer);
                }
                customer.AddItemToShoppingCart(shop.ShopItems.Find(item =>  item.Id == itemNumber));              
            }
        }
    }
}

