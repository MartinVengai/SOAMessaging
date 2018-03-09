using Messaging.Shared.Contracts;
using RawRabbit.Common;
using RawRabbit;

namespace Messaging.Shared.Extensions
{
    public static class RawRabbitExtensions
    {
        public static ISubscription SubscribeToCommand<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(async (msg, context) => await handler.HandleAsync(msg));
        }
    }
}
