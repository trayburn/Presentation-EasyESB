using MassTransit;
using System;
namespace EasyESB.Messages
{
    public class AddEvidenceToLockup : CorrelatedBy<Guid>
    {
        public int CaseNumber { get; set; }
        public string Evidence { get; set; }

        public Guid CorrelationId { get; set; }
    }
}