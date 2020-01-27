using System;

namespace Dfc.ProviderPortal.FatProcessor.Functions.Exceptions
{
    public class IllegalApprenticeshipRecordException : Exception
    {
        public IllegalApprenticeshipRecordException(string message) : base(message)
        {
        }

        public IllegalApprenticeshipRecordException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}