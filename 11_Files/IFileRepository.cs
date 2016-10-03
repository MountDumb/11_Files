using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    public interface IFileRepository : IStockRepository, IFileOperation
    {
       // void SaveStock(Stock s);
    }
}
