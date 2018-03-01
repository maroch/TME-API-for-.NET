using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tmeapiwrapper.Data;
using tmeapiwrapper.net.Data;

namespace TestService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var test = new tmeapiwrapper.ProductsWrapper("c2541a34499f09b3a322", "f1e6ec66ef75693b6bee3a33bf31e13d0cb9dcbeb5b57");

                RootObjectResponse rootResponse = test.GetStocks("PL", "EN", new List<string>() { "1WAT-LED-LIGHT", "3CHAZ-LO", "2W08G-E4/51" });

                var castTest = JsonConvert.DeserializeObject<ProductGetStocksResponseData>(rootResponse.Data.ToString());

                foreach (var item in castTest.ProductList)
                {

                    Console.WriteLine(item.Symbol + "amount: " +item.Amount);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an exception with service: " + ex.Message);

            }
        }
    }
}
