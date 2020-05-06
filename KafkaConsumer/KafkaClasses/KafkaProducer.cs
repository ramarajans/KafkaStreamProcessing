using Confluent.Kafka;
using Confluent.Kafka.Admin;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    class KafkaProducer
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public KafkaProducer()
        {
            PostMessage();
        }

        /// <summary>
        /// This method is to send the message from producer
        /// </summary>
        public static void PostMessage()
        {
            string topic = ConfigurationSettings.AppSettings["TopicName"];
            Uri uri = new Uri(ConfigurationSettings.AppSettings["URI"]);

            while (true)
            {
                Console.WriteLine("Please post your message here:");
                object payload = GetUserInput();
                Message msg = new Message(payload.ToString());
                var options = new KafkaOptions(uri);
                var router = new BrokerRouter(options);
                var client = new Producer(router);
                client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
                Console.WriteLine("Do you want to post another message? (Y/N) : ");
                if ("Y".Equals(Console.ReadLine().ToString()))
                {
                    Console.WriteLine("Please post your message here");
                    payload = GetUserInput();
                }
                else
                {
                    return;
                }
            }
        }

        public static Car GetUserInput()
        {
            Car car = new Car();
            Console.WriteLine("Please input brand name : ");
            car.BrandName = Console.ReadLine();
            Console.WriteLine("Please input model : ");
            car.Model = Console.ReadLine();
            Console.WriteLine("Please input number of doors : ");
            car.NoOfDoors = Console.ReadLine();
            Console.WriteLine("Is this sports model? : ");
            car.IsSportsCar = Console.ReadLine();
            
            return car;
        }
        public class Car
        {
            public string BrandName { get; set; }
            public string Model { get; set; }
            public string NoOfDoors { get; set; }
            public string IsSportsCar { get; set; }
            public override string ToString()
            {
                return string.Format("Brand Name : {0} , Model : {1}, Number of doors : {2}, Is Sports Car : {3}", BrandName, Model, NoOfDoors, IsSportsCar);
            }
        }
    }
}