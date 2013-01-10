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
    public class Clerk2Unproven : Consumes<AddEvidenceToLockup>.All
    {
        public void Consume(AddEvidenceToLockup message)
        {
            Console.WriteLine("UNPROVEN > I'll get to that officer.");

            var t = new Task(PutStuffAway, message);
            t.Start();
        }

        private void PutStuffAway(object state)
        {
            var msg = state as AddEvidenceToLockup;
            Console.WriteLine("UNPROVEN > Time to file this {0} for case number {1}", msg.Evidence, msg.CaseNumber);
            Thread.Sleep(1000);
            Console.WriteLine("UNPROVEN > Alright filed that in case {0}", msg.CaseNumber);
        }
    }
}