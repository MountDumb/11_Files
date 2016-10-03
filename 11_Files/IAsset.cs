using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    public interface IAsset
    {
        string Symbol { get; }
        int Id { get; }
        double GetValue();
        

        
    }
}
