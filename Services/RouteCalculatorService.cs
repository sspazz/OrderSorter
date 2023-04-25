using Core.Abstractions.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RouteCalculatorService : IRouteCalculatorService
    {

        public async Task<List<Address>> FindShortestRoute(Address startAddress, Address endAddress, List<Address> nodesToVisit)
        {
            return await Task.Run(() =>
            {
                List<List<Address>> routes = Permute(nodesToVisit);

                double shortestDistance = double.MaxValue;
                List<Address> shortestRoute = new List<Address>();

                foreach (List<Address> route in routes)
                {
                    // Add start and end addresses to route
                    route.Insert(0, startAddress);
                    route.Add(endAddress);
                    double distance = CalculateTotalDistance(route);

                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        shortestRoute = route;
                    }
                }

                return shortestRoute;
            });
            
        }

        private List<List<Address>> Permute(List<Address> addresses)
        {
            List<List<Address>> result = new List<List<Address>>();
            if (addresses.Count == 0)
            {
                result.Add(new List<Address>());
                return result;
            }

            foreach (Address a in addresses)
            {
                List<Address> temp = new List<Address>(addresses);
                temp.Remove(a);
                List<List<Address>> permutations = Permute(temp);
                foreach (List<Address> l in permutations)
                {
                    l.Insert(0, a);
                    result.Add(l);
                }
            }

            return result;
        }

        private double CalculateTotalDistance(List<Address> addresses)
        {
            double totalDistance = 0;

            for (int i = 0; i < addresses.Count - 1; i++)
            {
                double distance = CalculateDistance(addresses[i], addresses[i + 1]);
                totalDistance += distance;
            }

            return totalDistance;
        }

        private double CalculateDistance(Address address1, Address address2)
        {
            double latDiff = address2.Latitude - address1.Latitude;
            double lonDiff = address2.Longitude - address1.Longitude;

            // Calculate the distance using the Pythagorean theorem
            double distance = Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff);

            return distance;
        }
    }
}
