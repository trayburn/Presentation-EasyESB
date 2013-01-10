using MassTransit;
using System;

namespace EasyESB.Messages
{
    public class EvidenceAddedEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }

        public string ClerkName { get; set; }
    }
}
