using KafkaNet;
using KafkaNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafkaNet.Protocol;
using System.Configuration;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            KafkaProducer prodObj = new KafkaProducer();
            KafkaConsumer consObj = new KafkaConsumer();
        }
    }
}