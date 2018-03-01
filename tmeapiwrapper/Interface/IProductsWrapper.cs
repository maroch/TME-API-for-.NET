using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmeapiwrapper.Data;

namespace tmeapiwrapper.Interface
{
    public interface IProductsWrapper
    {
        RootObjectResponse GetStocks(string country, string language, List<string> symbolList);
    }
}
