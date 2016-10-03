using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _11_Files
{
    public class MemoryStockRepository : IStockRepository
    {
        private long id;
        private List<IAsset> assets;
        public MemoryStockRepository()
        {
            assets = new List<IAsset>();
            id = 0;
        }

        public long NextId()
        {
            id++;
            return id;
        }

        public void SaveStock(IAsset iass)
        {
            assets.Add(iass);
        }

        public Stock LoadStock(long id)
        {
            foreach (var item in assets)
            {
                if (item.Id == id)
                {
                    return (Stock)item;
                }
            }
            return null;
        }

        public List<IAsset> FindAllStocks()
        {
            return assets;
        }

        public void Clear()
        {
            assets.Clear();
        }


    }
}
