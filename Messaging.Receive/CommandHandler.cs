using System;
using System.Threading.Tasks;
using Messaging.Shared.Contracts;
using Messaging.Shared.Messages;

namespace Messaging.Receive
{
    public class CommandHandler : ICommandHandler<Person>
    {
        public async Task HandleAsync(Person person)
        {
            if (person == null)
            {
                Console.WriteLine($"Name is not valid. Application cannot respond.");
                return;
            }

            Console.WriteLine($"Hello my name is, {person.Name}.");
            Console.WriteLine($"Hello {person.Name}, I'm your father!");
            await Task.Delay(1000);
        }
    }
}