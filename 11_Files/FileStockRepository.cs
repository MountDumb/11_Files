using System.IO;
using System.Collections.Generic;

namespace _11_Files
{
    public class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo repositoryDir;
        private long id = 0;

        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            this.repositoryDir = repositoryDir;
        }

        public long NextId()
        {
            id++;
            return id;
        }

        public string StockFileName(long number)
        {

            return "stock" + number + ".txt"; 
            //foreach (var item in repositoryDir.GetFiles())
            //{
            //    if (item.ToString() == "stock" + number + ".txt")
            //    {
            //        return item.ToString();
            //    }
            //}
            //return "";

        }

        public string StockFileName(Stock s)
        {
            return "stock" + s.Id + ".txt";
            //foreach (var item in repositoryDir.GetFiles())
            //{
            //    if (item.ToString() == "stock" + s.Id + ".txt")
            //    {
            //        return item.ToString();
            //    } 
            //}   
            //return "";
        }

        public void SaveStock(IAsset ias)
        {

            NextId();
            Stock s = (Stock)ias;
            s.Id = id;
            FileInfo f = new FileInfo(repositoryDir + StockFileName(s));
            StockIO sio = new StockIO();
            sio.WriteStock(f, s);
        }
        public Stock LoadStock(long l)
        {
            StockIO sio = new StockIO();

            foreach (var item in repositoryDir.GetFiles())
            {
                if (item.ToString() == "stock" + l + ".txt")
                {
                    return sio.ReadStock(new FileInfo(repositoryDir + item.ToString()));
                }
            }
            return null;
        }

        public void Clear()
        {
            foreach (var item in repositoryDir.GetFiles())
            {
                item.Delete();
            }
        }

        public List<IAsset> FindAllStocks()
        {
            List<IAsset> l = new List<IAsset>();
            StockIO sio = new StockIO();

            foreach (var item in repositoryDir.GetFiles())
            {
                l.Add(sio.ReadStock(new FileInfo(repositoryDir + item.ToString())));
            }
            return l;
        }
    }
}