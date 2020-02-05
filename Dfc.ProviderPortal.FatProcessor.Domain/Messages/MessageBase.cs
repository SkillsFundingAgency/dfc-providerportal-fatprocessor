using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Messages
{
    public class MessageBase
    {
        protected MessageBase(string messageType, string actorName)
        {
            ActorName = actorName;
            MessageType = messageType;
        }

        [JsonPropertyName("source")] public string ActorName { get; }
        [JsonPropertyName("type")] public string MessageType { get; private set; }

    }
}