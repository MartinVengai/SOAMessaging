using Messaging.Shared.Extensions;
using RawRabbit.vNext;

namespace Messaging.Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            var busClient = BusClientFactory.CreateDefault();
            busClient.SubscribeToCommand(new CommandHandler());
        }
    }
}
