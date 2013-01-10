using EasyESB.Messages;
using Magnum;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnum.Extensions;
using MassTransit.Saga;
using Magnum.StateMachine;

namespace EasyESB.Officer
{
    public class OfficerSaga : SagaStateMachine<OfficerSaga>, ISaga
    {

        static OfficerSaga()
        {
            Define(() =>
                {
                    Initially(When(Submit)
                        .Then((s, m) => AddEvidence(s,m))
                        .TransitionTo(Completed));

                    During(Completed, When(Added)
                        .Then((s, m) => ThankTheClerk(m))
                        .Complete());
                });
        }

        public static State Initial { get; set; }
        public static State Completed { get; set; }

        public static Event<SubmitEvidence> Submit { get; set; }
        public static Event<EvidenceAddedEvent> Added { get; set; }

        private static void AddEvidence(ISaga saga, SubmitEvidence msg)
        {
            saga.Bus.Publish(new AddEvidenceToLockup()
            {
                CorrelationId = msg.CorrelationId,
                CaseNumber = msg.CaseNumber,
                Evidence = msg.Evidence
            });
        }

        private static void ThankTheClerk(EvidenceAddedEvent msg)
        {
            Console.WriteLine("Thank you {0}.", msg.ClerkName);
        }

        public OfficerSaga(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public IServiceBus Bus { get; set; }

        public Guid CorrelationId { get; private set; }
    }
}
