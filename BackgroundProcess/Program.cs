using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            var selfHost = new ServiceHost(typeof(LocalServiceWrapper));

            selfHost.Open();

            Console.WriteLine("The service is ready.");

            // Close the ServiceHost to stop the service.
            Console.WriteLine("Press <Enter> to terminate the service.");
            Console.WriteLine();
            Console.ReadLine();
            selfHost.Close();

        }
    }
}
