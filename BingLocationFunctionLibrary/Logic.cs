using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingMapsRESTToolkit;

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

        public async Task<string> GetRoute(string a, string b)
        {
            var travelTime = await RouteRequest(a, b); 

            return travelTime;
        }

        private async Task<string> RouteRequest(string locationA, string locationB)
        {
            var r = new RouteRequest()
            {
                RouteOptions = new RouteOptions()
                {
                    Avoid = new List<AvoidType>()
                    {
                        AvoidType.MinimizeTolls
                    },
                    TravelMode = TravelModeType.Driving,
                    DistanceUnits = DistanceUnitType.Miles,
                    Heading = 45,
                    RouteAttributes = new List<RouteAttributeType>()
                    {
                        RouteAttributeType.RoutePath
                    },
                },
                Waypoints = new List<SimpleWaypoint>()
                {
                    new SimpleWaypoint()
                    {
                        Address = locationA
                    },
                    new SimpleWaypoint()
                    {
                        Address = locationB
                    }
                },
                BingMapsKey = _apiKey
            };

            return await ProcessRequest(r);

        }

        private async Task<string> ProcessRequest(BaseRestRequest request)
        {
            try
            {
                var start = DateTime.Now;

                var response = await ServiceManager.GetResponseAsync(request);

                var end = DateTime.Now;

                var processingTime = end - start;

                Debug.WriteLine($"Processing Time: {processingTime}");

                Debug.WriteLine(response);
                var x = ((BingMapsRESTToolkit.Route)response.ResourceSets[0].Resources[0]).TravelDuration;

                return x.ToString(); 

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "no route found"; 
            }
        }

    }
}
