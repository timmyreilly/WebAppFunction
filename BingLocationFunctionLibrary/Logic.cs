using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingLocationFunctionLibrary
{
    public class Logic
    {

        private readonly string _apiKey;

        public Logic(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void SayHello(string words)
        {
            Debug.WriteLine(words);  
        }
    }
}
