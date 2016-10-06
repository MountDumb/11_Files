using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _11_Files;


namespace FileConsole
{
    public class MenuOptions
    {
        private string choice;
        private IStockRepository stockRepo;
        public MenuOptions(string choice, IStockRepository stockRepo)
        {
            this.choice = choice;
            this.stockRepo = stockRepo;

        }

        public bool Run()
        {
            switch (choice.ToLower())
            {
                case "1":
                    List<IAsset> stocks = stockRepo.FindAllStocks();
                    Console.Clear();
                    foreach (var item in stocks)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.ReadLine();
                    return true;
                    

                case "2":

                    Console.WriteLine("Name: ");
                    string symbol = Console.ReadLine();
                    Console.WriteLine("Price per Share: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Number of Shares: ");
                    int shares = int.Parse(Console.ReadLine());
                    IAsset stock = new Stock(symbol, price, shares);
                    stockRepo.SaveStock(stock);
                    return true;
                    

                case "x":
                    return false;
                    

                default:
                    Console.WriteLine("please choose again");
                    Console.ReadLine();
                    return true;
                    
            }
        }
    }

}
