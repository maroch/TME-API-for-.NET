using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace tmeapiwrapper
{
    public class ServiceBase
    {
        /// <summary>
        /// Send POST message to TME API
        /// </summary>
        /// <param name="url">post method addres</param>
        /// <param name="values">parameters to post method</param>
        /// <param name="msg">ApiSignature value</param>
        /// <returns> string result </returns>
        public string SendPostRequest(string url, List<KeyValuePair<string, string>> values, string msg)
        {
     
            using (var client = new HttpClient())
            {
             

                    // add values to data for post
                    values.Add(new KeyValuePair<string, string>("ApiSignature", msg));
                    FormUrlEncodedContent content = new FormUrlEncodedContent(values);

                    // Post data
                    var result = client.PostAsync(url, content).Result;

                    // Access content as stream which you can read into some string
                    var res = result.Content.ReadAsStringAsync();
                    return res.Result;


            }

            return "";
        }

    }
}
