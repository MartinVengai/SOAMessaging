using System;
using System.Collections.Generic;
using System.Text;
using Messaging.Shared.Contracts;
using RawRabbit.Attributes;
using RawRabbit.Configuration.Exchange;

namespace Messaging.Shared.Messages
{
    [Exchange(Name = "messaging", Type = ExchangeType.Topic)]
    [Queue(Name = "create_person", MessageTtl = 3000, AutoDelete = false, Durable = true)]
    [Routing(RoutingKey = "create_the_person", NoAck = true, PrefetchCount = 50)]
    public class Person : ICommand
    {
        public string Name { get; set; }
    }
}
