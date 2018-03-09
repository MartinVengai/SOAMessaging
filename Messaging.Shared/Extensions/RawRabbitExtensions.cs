using Messaging.Shared.Contracts;
using RawRabbit.Common;
using RawRabbit;
using RawRabbit.Configuration.Exchange;

namespace Messaging.Shared.Extensions
{
    public static class RawRabbitExtensions
    {
        public static ISubscription SubscribeToCommand<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(
                async (msg, context) => await handler.HandleAsync(msg),
                cfg => cfg
                    .WithRoutingKey("person.getname")
                    .WithPrefetchCount(1)
                    .WithNoAck()
                    .WithQueue(q => q.WithName("person.queue").WithDurability(true))
                    .WithExchange(ex => ex.WithType(ExchangeType.Topic).WithAutoDelete().WithName("person_exchange"))
            );
    }
}
