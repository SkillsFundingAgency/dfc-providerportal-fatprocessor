using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Dfc.ProviderPortal.FatProcessor.Functions
{
    public static class ApprenticeshipChangeProcessor
    {
        [FunctionName("ApprenticeshipChangeProcessor")]
        public static void Run([ServiceBusTrigger(
                "export",
                Connection = "Apprenticeships_QueueConnection")]
            string myQueueItem, 
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
