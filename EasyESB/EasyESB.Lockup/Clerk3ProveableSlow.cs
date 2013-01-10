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
    public class Clerk3ProveableSlow : Consumes<AddEvidenceToLockup>.Context
    {
        public void Consume(IConsumeContext<AddEvidenceToLockup> message)
        {
            var msg = message.Message;
            Console.WriteLine("PROVEABLESLOW > Right away officer.");
            Thread.Sleep(1000);
            Console.WriteLine("PROVEABLESLOW > Time to file this {0} for case number {1}", msg.Evidence, msg.CaseNumber);
            Thread.Sleep(1000);
            Console.WriteLine("PROVEABLESLOW > Alright filed that in case {0}", msg.CaseNumber);

            message.Respond(new EvidenceAddedEvent() { ClerkName = "PROVEABLESLOW" });
        }
    }
}