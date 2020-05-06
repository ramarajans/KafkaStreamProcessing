using KafkaNet;
using KafkaNet.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    class KafkaConsumer
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public KafkaConsumer()
        {
            ConsumeMessage();
        }

        /// <summary>
        /// This method is to consume the message sent by producer
        /// </summary>
        public void ConsumeMessage()
        {
            try
            {
                string topic = ConfigurationSettings.AppSettings["TopicName"];
                Uri uri = new Uri(ConfigurationSettings.AppSettings["URI"]);
                var options = new KafkaOptions(uri);
                var router = new BrokerRouter(options);
                var consumer = new Consumer(new ConsumerOptions(topic, router));
                foreach (var message in consumer.Consume())
                {
                    Console.WriteLine(Encoding.UTF8.GetString(message.Value));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
