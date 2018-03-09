using System.Threading.Tasks;

namespace Messaging.Shared.Contracts
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}