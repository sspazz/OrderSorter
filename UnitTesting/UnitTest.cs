using Services;
using Core;
using Core.Models;

namespace UnitTesting
{
    public class UnitTest
    {
        [Fact]
        public async void Test()
        {

            RouteCalculatorService routeCalculatorService = new RouteCalculatorService();
            List<DeliveryPerson> deliveryPersons = new List<DeliveryPerson>();
            deliveryPersons.Add(new DeliveryPerson { Id = 1, ContactName = "John Smith", DefaultAddress = new Address { AddressName = "123 St", Latitude = 0, Longitude = 0 } });

            var officeAddress = new Address { AddressName = "Office", Latitude = 10, Longitude = 0 };

            List<Order> orders = new List<Order>();
            Random random = new Random();
            for (int i = 1; i <= 7; i++)
            {
                orders.Add(new Order { Id = i, ContactName = "Order " + i, Address = new Address { AddressName = "Address " + i, Latitude = i, Longitude = i } });
            }

            List<Address> addresses1 = orders.Select(o => o.Address).ToList();

            List<Address> expectedaddresses = new List<Address>();
            expectedaddresses.Add(deliveryPersons[0].DefaultAddress);
            expectedaddresses.AddRange(addresses1);
            expectedaddresses.Add(officeAddress);

            var shortestRoute = await routeCalculatorService.FindShortestRoute(deliveryPersons[0].DefaultAddress, officeAddress, addresses1);
            Assert.Equal(expectedaddresses, shortestRoute);
        }

        [Fact]
        public async void TestReverse()
        {

            RouteCalculatorService routeCalculatorService = new RouteCalculatorService();
            List<DeliveryPerson> deliveryPersons = new List<DeliveryPerson>();
            deliveryPersons.Add(new DeliveryPerson { Id = 1, ContactName = "John Smith", DefaultAddress = new Address { AddressName = "123 St", Latitude = 0, Longitude = 0 } });

            var officeAddress = new Address { AddressName = "Office", Latitude = 100, Longitude = 100 };

            List<Order> orders = new List<Order>();
            Random random = new Random();
            for (int i = 1; i <= 7; i++)
            {
                orders.Add(new Order { Id = i, ContactName = "Order " + i, Address = new Address { AddressName = "Address " + i*3, Latitude = i, Longitude = i*3 } });
            }

            List<Address> addresses1 = orders.Select(o => o.Address).ToList();

            List<Address> expectedaddresses = new List<Address>();
            expectedaddresses.Add(deliveryPersons[0].DefaultAddress);
            expectedaddresses.AddRange(addresses1);
            expectedaddresses.Add(officeAddress);

            var shortestRoute = await routeCalculatorService.FindShortestRoute(deliveryPersons[0].DefaultAddress, officeAddress, addresses1);
            Assert.Equal(expectedaddresses, shortestRoute);
        }
    }
}