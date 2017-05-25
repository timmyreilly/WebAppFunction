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

        public async Task GetRoute(string a, string b)
        {
            await RouteRequest(a, b);
        }

        public async Task RouteRequest(string locationA, string locationB)
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

            await ProcessRequest(r);

        }

        private async Task ProcessRequest(BaseRestRequest request)
        {
            try
            {


                var start = DateTime.Now;

                var response = await ServiceManager.GetResponseAsync(request);

                var end = DateTime.Now;

                var processingTime = end - start;

                Debug.WriteLine($"Processing Time: {processingTime}");

                Debug.WriteLine(response);  


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);  
            }
        }

    }
}
