using EasyESB.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EasyESB.Lockup
{
    public class Clerk4Proveable : Consumes<AddEvidenceToLockup>.Context
    {
        public void Consume(IConsumeContext<AddEvidenceToLockup> message)
        {
            var msg = message.Message;
            Console.WriteLine("PROVEABLE > Right away officer.");
            Thread.Sleep(1000);
            Console.WriteLine("PROVEABLE > Time to file this {0} for case number {1}", msg.Evidence, msg.CaseNumber);
            Thread.Sleep(1000);
            Console.WriteLine("PROVEABLE > Alright filed that in case {0}", msg.CaseNumber);

            message.Bus.Publish(new EvidenceAddedEvent()
            {
                CorrelationId = msg.CorrelationId,
                ClerkName = "PROVEABLE"
            });
        }
    }
}
