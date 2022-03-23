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
                    Balance = 0,
                    Currency = "NOK"
                });
            //var bank = new BankInformation();
            Shop.Run(shop, customer);
        }              
   }
}
