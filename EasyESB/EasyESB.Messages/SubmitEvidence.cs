using MassTransit;
using System;

namespace EasyESB.Messages
{
    public class SubmitEvidence : CorrelatedBy<Guid>
    {
        public SubmitEvidence()
        {
            CorrelationId = Guid.NewGuid();
        }
        public int CaseNumber { get; set; }
        public string Evidence { get; set; }

        public Guid CorrelationId { get; set; }
    }
}
