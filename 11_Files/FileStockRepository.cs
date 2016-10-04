using System.IO;
using System.Collections.Generic;

namespace _11_Files
{
    public class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo repositoryDir;
        private long id;

        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            this.repositoryDir = repositoryDir;
            id = FindAllStocks().Count;
        }

        public long NextId()
        {
            id++;
            return id;
        }

        public string StockFileName(long number)
        {

            return "stock" + number + ".txt"; 
            
        }

        public string StockFileName(Stock s)
        {
            return "stock" + s.Id + ".txt";
      
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

            foreach (FileInfo item in repositoryDir.GetFiles())
            {
                if (item.ToString() == "stock" + l + ".txt")
                {
                    return sio.ReadStock(new FileInfo(repositoryDir + item.ToString()));
                }
            }
            throw new System.Exception("File not found");
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

            foreach (FileInfo item in repositoryDir.GetFiles())
            {
                l.Add(sio.ReadStock(new FileInfo(repositoryDir + item.ToString())));
                
            }
            
            return l;
        }

        
    }
}