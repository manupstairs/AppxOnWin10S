using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProcess
{
    public class LocalServiceWrapper : ILocalService
    {
        public ServiceControllerStatus GetServiceStatus(string name)
        {
            Console.WriteLine($"Ready to query {name} service……");
            ServiceController controller = new ServiceController(name);

            return controller.Status;
        }

        public ServiceControllerStatus StartService(string name)
        {
            Console.WriteLine($"Ready to start {name} service……");
            ServiceController controller = new ServiceController(name);

            if (controller.Status == ServiceControllerStatus.Stopped)
            {
                Console.WriteLine($"Starting {name} service……");
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                Console.WriteLine($"Finish start {name} service……");
            }
            else
            {
                Console.WriteLine($"{name} service is already running……");
            }
            return controller.Status;
        }
    }
}
