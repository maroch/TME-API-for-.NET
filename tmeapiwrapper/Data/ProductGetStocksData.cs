using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmeapiwrapper.Data
{
    public class ProductGetStocksData
    {
        public string Symbol { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}
