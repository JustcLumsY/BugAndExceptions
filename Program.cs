using System;

namespace BugAndExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var customer = new Customer(
                "John", new Address()
                {
                    StreetName = "Vadumåsen",
                    HouseNumber = "1",
                    City = "Melsomvik",
                    Municipality = "Sandefjord"
                },
                new BankInformation()
                {
                    BankName = "DNB",
                    AccountNumber = "1111 2222 3333 4444",
                    Balance = 20000,
                    Currency = "NOK"
                });
            Shop.Run(shop, customer);
        }              
   }
}
