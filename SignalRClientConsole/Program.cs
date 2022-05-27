using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/chatHub")
                .Build();

            connection.StartAsync().Wait();
            connection.InvokeCoreAsync("SendMessage", args: new []{"Suleyman", "Hello World" });
            connection.On("ReceiveMessage", (string userName, string message) =>
            {
                Console.WriteLine(userName + ":" + message);
            });
            Console.ReadKey();
        }
    }
}