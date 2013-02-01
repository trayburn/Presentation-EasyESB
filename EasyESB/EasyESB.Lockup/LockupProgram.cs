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
    class LockupProgram
    {
        static void Main(string[] args)
        {
            var bus = ServiceBusFactory.New(b =>
            {
                b.UseRabbitMq();
                b.UseControlBus();
                b.ReceiveFrom("rabbitmq://localhost/Lockup");
                b.SetConcurrentConsumerLimit(1);

                b.Subscribe(c =>
                {
                    c.Consumer<Clerk4Proveable>();
                });
            });
            using (bus)
            {
                Console.WriteLine("Lockup Process Running, Press Enter to End");
                Console.ReadLine();
            }
        }
    }

}