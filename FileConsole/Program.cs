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
            Console.Title = "StockHandler";
            bool running = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1: Show Stocks");
                Console.WriteLine("2: New Stock");
                Console.WriteLine("3: Buy Stocks");
                Console.WriteLine("x: Exit");
                string choice = Console.ReadLine();
                MenuOptions mo = new MenuOptions(choice, stockRepo);

                running = mo.Run();
            }
            while (running);

        }
    }
}
