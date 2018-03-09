using System.Threading.Tasks;

namespace Messaging.Shared.Contracts
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T perso);
    }
}