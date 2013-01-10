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
    public class Clerk1Slow : Consumes<AddEvidenceToLockup>.All
    {
        public void Consume(AddEvidenceToLockup message)
        {
            Console.WriteLine("SLOW > So you want {0} added to case number {1} ... ", message.Evidence, message.CaseNumber);
            Thread.Sleep(1000);
            Console.WriteLine("SLOW > Alright ...");
            Thread.Sleep(1000);
            Console.WriteLine("SLOW > Yup we've got that.  You're good to go officer");
            Console.WriteLine();
        }
    }
}
