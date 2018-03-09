using System;
using System.Threading.Tasks;
using Messaging.Shared.Contracts;
using RawRabbit;
using RawRabbit.Configuration.Exchange;

namespace Messaging.Send
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IBusClient _bus;

        public CommandDispatcher(IBusClient bus)
        {
            _bus = bus;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), "Command can not be null");

            await _bus.PublishAsync(command, Guid.NewGuid(),
                cfg => cfg
                    .WithRoutingKey("person.getname")
                    .WithExchange(ex => ex.WithName("person_exchange").WithType(ExchangeType.Topic).WithAutoDelete())
            );
        }
    }
}