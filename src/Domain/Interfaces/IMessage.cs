using System;
using System.Dynamic;

namespace Dfc.ProviderPortal.FatProcessor.Domain.Interfaces
{
    public interface IMessagePayload
    {
    }

    public interface IMessage<T> where T : IMessagePayload
    {
        string MessageType { get; }
        int Provider { get; set; }
        T Payload { get; set; }
    }
}