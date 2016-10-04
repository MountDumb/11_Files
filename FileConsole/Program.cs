using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _11_Files;
using System.IO;

namespace FileConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo repoDir = new DirectoryInfo("mydata\\");
            IStockRepository stockRepo = new FileStockRepository(repoDir);
            Menu(stockRepo);

        }

        static private void Menu(IStockRepository stockRepo)
        {
            bool running = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1: Show Stocks");
                Console.WriteLine("2: New Stock");
                Console.WriteLine("x: Exit");
                string choice = Console.ReadLine();

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
                        break;

                    case "2":

                        Console.WriteLine("Name: ");
                        string symbol = Console.ReadLine();
                        Console.WriteLine("Price per Share: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Number of Shares: ");
                        int shares = int.Parse(Console.ReadLine());
                        IAsset stock = new Stock(symbol, price, shares);
                        stockRepo.SaveStock(stock);
                        break;

                    case "x":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("please choose again");
                        Console.ReadLine();
                        break;
                }


            }
            while (running);

        }
    }
}
