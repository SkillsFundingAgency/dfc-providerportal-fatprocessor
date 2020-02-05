using System.Text.Json.Serialization;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Domain.Messages;
using Dfc.ProviderPortal.FatProcessor.Functions.Dto.Fat;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Messages
{
    public class FrameworkChangeMessage : MessageBase, IMessage<FrameworkExport>
    {
        public FrameworkChangeMessage(int frameworkCode, int pathway, int programmeType, string actorName) : base("Framework", actorName)
        {
            FrameworkCode = frameworkCode;
        }

        [JsonPropertyName("frameworkId")] public int FrameworkCode { get; }
        [JsonPropertyName("providerId")] public int Provider { get; set; }
        [JsonPropertyName("data")] public FrameworkExport Payload { get; set; }
    }
}