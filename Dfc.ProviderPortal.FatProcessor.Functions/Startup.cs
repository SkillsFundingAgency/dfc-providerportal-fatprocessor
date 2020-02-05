using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly: FunctionsStartup(typeof(Dfc.ProviderPortal.FatProcessor.Functions.Startup))]
namespace Dfc.ProviderPortal.FatProcessor.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplicationInsightsTelemetry();

            // BUGFIX: This is temporary to get around the Application Insights injection issue on netcore3.1 applications.
            builder.Services.AddSingleton<TelemetryConfiguration>(sp =>
            {
                var key = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY");
                if (!string.IsNullOrWhiteSpace(key))
                {
                    return new TelemetryConfiguration(key);
                }
                return new TelemetryConfiguration();
            });
        }
    }
}