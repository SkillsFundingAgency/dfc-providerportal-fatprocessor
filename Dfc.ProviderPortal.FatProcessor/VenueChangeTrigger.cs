using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Dfc.ProviderPortal.FatProcessor.Functions
{
    public class VenueChangeTrigger
    {
        [FunctionName("VenueChangeTrigger")]
        public async Task Run([CosmosDBTrigger(
                "%Venues_WatchDatabase%",
                "%Venues_WatchCollection%",
                ConnectionStringSetting = "Venues_CosmosConnection",
                LeaseCollectionName = "leases",
                LeaseCollectionPrefix = "fat_export_",
                CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> input,
            [ServiceBus(
                "export",
                Connection = "Venues_QueueConnection",
                EntityType = EntityType.Queue)]
            IAsyncCollector<string> queue,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach (Document change in input)
                {
                    // Trigger stub
                    log.LogInformation("Documents modified " + input.Count);
                    log.LogInformation("First document Id " + input[0].Id);
                }
            }
        }
    }
}