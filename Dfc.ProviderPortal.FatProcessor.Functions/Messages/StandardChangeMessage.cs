using System.Text.Json.Serialization;
using Dfc.ProviderPortal.FatProcessor.Domain.Interfaces;
using Dfc.ProviderPortal.FatProcessor.Domain.Messages;
using Dfc.ProviderPortal.FatProcessor.Functions.Dto.Fat;
using Microsoft.Azure.ServiceBus;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Messages
{
    public class ApprenticeshipChangeMessage<T> : MessageBase, IMessage<T> where T : IMessagePayload
    {
        public ApprenticeshipChangeMessage(string apprenticeship, string actorName) : base(typeof(T).ToString(), actorName)
        {
            Apprenticeship = apprenticeship;
        }

        [JsonPropertyName("apprenticeshipId")] public string Apprenticeship { get; }
        [JsonPropertyName("providerId")] public int Provider { get; set; }
        [JsonPropertyName("data")] public T Payload { get; set; }
    }

    public class StandardChangeMessage : MessageBase, IMessage<StandardExport>
    {
        public StandardChangeMessage(int standardCode, string actorName) : base("Standard", actorName)
        {
            Standard = standardCode;
        }

        [JsonPropertyName("standardId")] public int? Standard { get; }
        [JsonPropertyName("providerId")] public int Provider { get; set; }
        [JsonPropertyName("data")] public StandardExport Payload { get; set; }
    }
}