using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Discovery;

namespace Client
{
    class Program
    {
        static EndpointAddress serviceAddress;
        static void Main()
        {
            if (FindService()) 
                InvokeService();
        }
        static bool FindService()
        {
            Console.WriteLine("\nFinding Myservice Service ..");
            DiscoveryClient discoveryClient =
                  new DiscoveryClient(new UdpDiscoveryEndpoint());
            var Services =
                 discoveryClient.Find(new FindCriteria(typeof(Service.IService1)));
            discoveryClient.Close();
            if (Services == null)
            {
                Console.WriteLine("\nNo services are found.");
                return false;
            }
            else
            {
                serviceAddress = Services.Endpoints[0].Address;
                return true;
            }
        }
        static void InvokeService()
        {
            Console.WriteLine("\nInvoking My Service at {0}\n", serviceAddress);
            Service.Service1 client = new Service.Service1();
            //client.
            //client.Endpoint.Address = serviceAddress;
            //client.GetData(1);
        }
    }
}
