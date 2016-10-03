using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    public interface IStockRepository
    {
        long NextId();
        void SaveStock(IAsset s);

        Stock LoadStock(long l);

        void Clear();

        List<IAsset> FindAllStocks();
    }
}
