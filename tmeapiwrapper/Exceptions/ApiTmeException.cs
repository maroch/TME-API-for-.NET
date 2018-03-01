using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmeapiwrapper.Exceptions
{
    public class ApiTmeException : Exception
    {
        public string Status { get; set; }
        public new List<object> Data { get; set; }
        public string ErrorMessage { get; set; }
        public List<object> Error { get; set; }
    }
}
