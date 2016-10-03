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

            return "";
        
        }

        public string StockFileName(Stock s)
        {
            return "";
        }
    }
}