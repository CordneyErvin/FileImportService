using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace FileImportService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.Service<ImportService>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(
                        () => new ImportService());
                    serviceInstance.WhenStarted(execute => execute.Start());
                    serviceInstance.WhenStopped(execute => execute.Stop());
                });
                serviceConfig.SetServiceName("CLE_Import_Service");
                serviceConfig.SetDisplayName("CLE Custom Service");
                serviceConfig.SetDescription("Custom file watcher service for import calling SSIS");
                serviceConfig.StartAutomatically();
            });
        }
    }
}
