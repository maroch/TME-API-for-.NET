using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tmeapiwrapper.Data;
using tmeapiwrapper.Interface;
using tmeapiwrapper.Logic;

namespace tmeapiwrapper
{
    public class ProductsWrapper : ServiceBase, IProductsWrapper
    {
        string _secret = "";
        string _token = "";

        public ProductsWrapper(string secret, string token)
        {
            _secret = secret;
            _token = token;
        }
        public RootObjectResponse GetStocks(string country, string language, List<string> symbolList)
        {
            var url = @"https://api.tme.eu/Products/GetStocks.json";
            var prefixRequest = "POST" + "&" + WebUtility.UrlEncode(@url) + "&";
            var suffixRequest = "";
            var values = new List<KeyValuePair<string, string>>();

            values.Add(new KeyValuePair<string, string>("Language", language));

            for (int i = 0; i < symbolList.Count; i++)
            {
                values.Add(new KeyValuePair<string, string>("SymbolList[" + i + "]", symbolList[i]));

            }
            values.Add(new KeyValuePair<string, string>("Token", _token));
            values.Add(new KeyValuePair<string, string>("Country", country));



            foreach (var el in values.OrderBy(x => x.Key))
            {

                suffixRequest += suffixRequest.Length > 1 ? WebUtility.UrlEncode("&" + WebUtility.UrlEncode(el.Key) + "=" + WebUtility.UrlEncode(el.Value)) : WebUtility.UrlEncode(WebUtility.UrlEncode(el.Key) + "=" + WebUtility.UrlEncode(el.Value));

            }


            var reply = this.SendPostRequest(url, values, Utlis.CreateToken(prefixRequest + suffixRequest, _secret));

            return JsonConvert.DeserializeObject<RootObjectResponse>(reply);
        }
    }
}
