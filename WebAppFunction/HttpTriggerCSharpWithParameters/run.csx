#r "..\bin\BingLocationFunctionLibrary.dll"
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, string name, TraceWriter log)
{    
    log.Info("C# HTTP trigger function processed a request.");

    // Fetching the name from the path parameter in the request URL

    var apiKey = "Ap9opDJtO8wtNnk1wNFdz2blihxwv8mPZdB5vEJR7epV3tluq67AFF75nFgVGzMH"; 

    string locationA = "79 Delmar Street San Francisco CA";
    string locationB = name;

    var logic = new BingLocationFunctionLibrary.Logic(apiKey);

    logic.GetRoute(locationA, locationB); 


    return req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
}