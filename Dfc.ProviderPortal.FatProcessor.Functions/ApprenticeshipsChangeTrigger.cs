using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Functions.Dto.Cosmos;
using Dfc.ProviderPortal.FatProcessor.Functions.Dto.Fat;
using Dfc.ProviderPortal.FatProcessor.Functions.Exceptions;
using Dfc.ProviderPortal.FatProcessor.Functions.Messages;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Dfc.ProviderPortal.FatProcessor.Functions
{
    public class ApprenticeshipsChangeTrigger
    {
        private readonly TelemetryClient _telemetryClient;

        public ApprenticeshipsChangeTrigger(TelemetryConfiguration telemetryConfiguration)
        {
            _telemetryClient = new TelemetryClient(telemetryConfiguration);
        }

        [FunctionName(nameof(ApprenticeshipsChangeTrigger))]
        public async Task Execute([CosmosDBTrigger(
                "%Apprenticeships_WatchDatabase%",
                "%Apprenticeships_WatchCollection%",
                ConnectionStringSetting = "Apprenticeships_CosmosConnection",
                LeaseCollectionName = "leases",
                LeaseCollectionPrefix = "fat_export_",
                CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> input,
            [ServiceBus(
                "export",
                Connection = "Apprenticeships_QueueConnection",
                EntityType = EntityType.Queue)]
            IAsyncCollector<string> queue,
            ExecutionContext context,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                var eventProperties = new Dictionary<string, string>();
                var metrics = new Dictionary<string, double>();

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                metrics.Add("amountOfChanges", input.Count);

                foreach (var apprenticeshipDocument in input)
                    try
                    {
                        ApprenticeshipDto apprenticeship = (dynamic) apprenticeshipDocument;
                        dynamic message = null;

                        if (apprenticeship.StandardCode.HasValue && apprenticeship.FrameworkCode.HasValue)
                            throw new IllegalApprenticeshipRecordException(
                                "Apprenticeships can not have both a Standard Code and a Framework Code. " +
                                $"StandardCode = {apprenticeship.StandardCode.Value.ToString()}, " +
                                $"FrameworkCode = {apprenticeship.FrameworkCode.Value.ToString()}");

                        eventProperties.TryAdd("UKPRN", apprenticeship.ProviderUKPRN.ToString());

                        if (apprenticeship.StandardCode.HasValue)
                        {
                            log.LogInformation($"Standard {apprenticeship.StandardCode} was updated");

                            eventProperties.TryAdd("Standard",
                                apprenticeship.StandardCode.GetValueOrDefault().ToString());

                            var payload = (StandardExport) apprenticeship;

                            message = new StandardChangeMessage(apprenticeship.StandardCode.GetValueOrDefault(0), nameof(ApprenticeshipsChangeTrigger))
                            {
                                Provider = apprenticeship.ProviderUKPRN,
                                Payload = payload
                            };
                        }

                        else if (apprenticeship.FrameworkCode.HasValue)
                        {
                            log.LogInformation($"Framework {apprenticeship.FrameworkCode} was updated");

                            eventProperties.TryAdd("Framework",
                                apprenticeship.FrameworkCode.GetValueOrDefault().ToString());

                            var payload = (FrameworkExport) apprenticeship;

                            message = new FrameworkChangeMessage(apprenticeship.FrameworkCode.GetValueOrDefault(0), apprenticeship.PathwayCode.GetValueOrDefault(0), apprenticeship.ProgType.GetValueOrDefault(0), nameof(ApprenticeshipsChangeTrigger))
                            {
                                Provider = apprenticeship.ProviderUKPRN,
                                Payload = payload
                            };
                        }

                        stopwatch.Stop();
                        metrics.Add("elapsedMilliseconds", stopwatch.ElapsedMilliseconds);

                        await queue.AddAsync(JsonSerializer.Serialize(message));
                    }
                    catch (Exception e)
                    {
                        log.Log(LogLevel.Error, e, "Could not process changes to Apprenticeship.",
                            apprenticeshipDocument);

                        _telemetryClient.TrackException(e, eventProperties, metrics);
                        throw;
                    }
                    finally
                    {
                        log.LogInformation($"[INFO] Apprenticeship {apprenticeshipDocument.Id} was updated.");
                        // log activity timers to App Insights
                        _telemetryClient.TrackEvent("ApprenticeshipChange", eventProperties, metrics);
                    }
            }
        }
    }
}