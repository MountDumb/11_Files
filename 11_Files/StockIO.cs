using System.IO;

namespace _11_Files
{
    public class StockIO
    {
        public void WriteStock(StringWriter sw, Stock s)
        {
            sw.WriteLine(s.Symbol);
            sw.WriteLine(s.PricePerShare);
            sw.WriteLine(s.NumShares);
        }

        public void WriteStock(FileInfo f, Stock s)
        {
            // Streamwriter writer = new StreamWriter(f.ToString());
            StreamWriter writer = f.CreateText(); 
            writer.WriteLine(s.Id);
            writer.WriteLine(s.Symbol);
            writer.WriteLine(s.PricePerShare);
            writer.WriteLine(s.NumShares);
            writer.Close();
        }

        public Stock ReadStock(FileInfo f)
        {
            StreamReader reader = new StreamReader(f.ToString());
            Stock s = new Stock();
            s.Id = int.Parse(reader.ReadLine());
            s.Symbol = reader.ReadLine();
            s.PricePerShare = double.Parse(reader.ReadLine());
            s.NumShares = int.Parse(reader.ReadLine());
            reader.Close();
            return s;

        }
        public Stock ReadStock(StringReader sr)
        {

            return new Stock(sr.ReadLine(), double.Parse(sr.ReadLine()), int.Parse(sr.ReadLine()));
        }
    }
}