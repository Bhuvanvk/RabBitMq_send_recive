using System;
using RabbitMQ.Client;
using System.Text;

namespace Producer
{
   public class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connect = factory.CreateConnection())
            using (var channel = connect.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string msg = "Babu new  with Rabbitmq getting start";
                var body = Encoding.UTF8.GetBytes(msg);
                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine($"Sent Message {msg}");
            }
            Console.WriteLine("enter any Key  to exit ...");
            Console.ReadLine();
        }
    }
}
