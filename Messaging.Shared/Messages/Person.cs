using System;
using System.Collections.Generic;
using System.Text;
using Messaging.Shared.Contracts;
using RawRabbit.Attributes;
using RawRabbit.Configuration.Exchange;

namespace Messaging.Shared.Messages
{
    public class Person : ICommand
    {
        public string Name { get; set; }
    }
}
