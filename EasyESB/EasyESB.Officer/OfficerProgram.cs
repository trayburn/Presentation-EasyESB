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
    class OfficerProgram
    {
        private static IServiceBus bus;

        static void Main(string[] args)
        {
            var bus = ServiceBusFactory.New(b =>
            {
                b.UseRabbitMq();
                b.UseControlBus();
                b.ReceiveFrom("rabbitmq://localhost/Officer");

                b.Subscribe(x =>
                {
                    x.Consumer<OffTheWallRequest>();
                    x.Saga(new InMemorySagaRepository<OfficerSaga>())
                        .Permanent();
                });
            });

            using (bus)
            {
                Console.WriteLine("Officer Process Running, Press Enter to End");

                for (int index = 0; index < 10; index++)
                {
                    Console.WriteLine("Officer > Please add this to case {0}", index);

                    //bus.Publish(new AddEvidenceToLockup
                    //{
                    //    CaseNumber = index,
                    //    Evidence = "Yet another cell phone",
                    //    CorrelationId = CombGuid.Generate()
                    //});

                    //bus.PublishRequest(new AddEvidenceToLockup
                    //{
                    //    CaseNumber = index,
                    //    Evidence = "Yet another cell phone",
                    //    CorrelationId = CombGuid.Generate()
                    //}, x =>
                    //{
                    //    x.Handle<EvidenceAddedEvent>((c, m) => Console.WriteLine("My case was filed by {0}", m.ClerkName));
                    //    x.HandleTimeout(5.Seconds(), om => Console.WriteLine("Nevermind, I'm out."));
                    //});

                    bus.Publish(new SubmitEvidence()
                    {
                        CaseNumber = index,
                        Evidence = "Yet another cell phone",
                        CorrelationId = CombGuid.Generate()
                    });

                }

                Console.WriteLine("PROCESS COMPLETE");
                Console.ReadLine();
            }
        }
    }

    public class OffTheWallRequest : Consumes<AddEvidenceToLockup>.Selected
    {

        public bool Accept(AddEvidenceToLockup message)
        {
            return message.CaseNumber == 4;
        }

        public void Consume(AddEvidenceToLockup message)
        {
            Console.WriteLine("LURKER > WooHoo! New Evidence!");
        }
    }

}
