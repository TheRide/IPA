using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Discovery;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri(string.Format("http://{0}:8000/discovery/scenarios/Myservice/{1}/",
            System.Net.Dns.GetHostName(), Guid.NewGuid().ToString()));
            Console.WriteLine(baseAddress);
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service.Service1), baseAddress))
            {
                serviceHost.AddServiceEndpoint(typeof(Service.IService1), new WSHttpBinding(), string.Empty);
                serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
                serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());
                serviceHost.Open();
                Console.WriteLine("Press to terminate service.");
                Console.ReadLine();
            }
        }
    }
}
