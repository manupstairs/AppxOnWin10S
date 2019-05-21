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
        public ServiceControllerStatus StartService(string name)
        {
            Console.WriteLine("Ready to start service……");
            ServiceController controller = new ServiceController(name);

            if (controller.Status == ServiceControllerStatus.Stopped)
            {
                Console.WriteLine("Starting service……");
                controller.Start();
                controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                Console.WriteLine("Finished start service……");
            }
            return controller.Status;
        }
    }
}
