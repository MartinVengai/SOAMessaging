using System;
using System.Threading.Tasks;
using Messaging.Shared.Messages;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Attributes;
using RawRabbit.Common;
using RawRabbit.vNext;

namespace Messaging.Send
{
    class Program
    {
        static void Main(string[] args)
        {
            BusClientFactory.CreateDefault(collection => collection.AddSingleton<IConfigurationEvaluator, AttributeConfigEvaluator>());
            RunAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        public static async Task RunAsync()
        {
            var commandDispatcher = new CommandDispatcher(BusClientFactory.CreateDefault());
            var person = GetCreatePerson();
            await commandDispatcher.DispatchAsync(person);
            Console.WriteLine($"My name is {person.Name}");
        }

        private static Person GetCreatePerson()
        {
            Console.WriteLine("Please enter your name");
            var name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name can not be empty, Please enter your name");
                name = Console.ReadLine();
            }

            return new Person { Name = name };
        }
    }
}
