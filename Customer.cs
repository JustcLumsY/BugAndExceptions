using System;
using System.Collections.Generic;
using System.Text;

namespace BugAndExceptions
{
    public class Customer
    {
        public string Name { get; set; }
        public Address CustomerAddress { get; set; }
        public BankInformation CustomerBankInfo { get; set; } 
        public List<ShopItem> ShoppingCart { get; set; }
        public List<ShopItem> Inventory { get; set; }

        public Customer(string name, Address address, BankInformation bankInfo)
        {    
            ShoppingCart = new List<ShopItem>();
            Inventory = new List<ShopItem>();
            Name = name;
            CustomerAddress = address;
            CustomerBankInfo = bankInfo;
        }
        
        public void AddItemToShoppingCart(ShopItem item)
        {
            ShoppingCart.Add(item);
        }
   
        public void PrintItemsInCart(Shop shop)
        {
            shop.totalPrice = 0;
            Console.WriteLine("ShoppingCart now has: ");
            foreach(var Item in ShoppingCart)
            {           
                Console.WriteLine($"<{Item.ItemName}> {Item.Price} NOK");
                shop.totalPrice += Item.Price;
            }
            if (shop.totalPrice <= 0) { return; }
            Console.WriteLine($"Total price is: { shop.totalPrice} { CustomerBankInfo.Currency}");
            Console.WriteLine();
        }
        public void BuyItemsInCart()
        {
            Inventory = ShoppingCart;
            Console.WriteLine("Items bought");
            foreach(var Item in Inventory)
            {
                Console.WriteLine($"<{Item.ItemName}> {Item.Price} NOK");
            }                 
        }
    }
}
