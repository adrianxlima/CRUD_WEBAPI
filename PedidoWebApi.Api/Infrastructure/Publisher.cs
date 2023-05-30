using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PedidoWebApi.Domain.Domain.DTO;
using RabbitMQ.Client;

namespace PedidoWebApi.Api.Infrastructure
{
     public class Publisher : IPublisher
    {
        private readonly IConnection _connection;
        private IModel _channel;
        private string _queue = "FilaPedidos";
        public Publisher()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",                
            };    

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        public void Publish(PaymentDTO dto)
        {
            _channel.QueueDeclare(_queue, true, false, false, null);
            var payLoad = JsonConvert.SerializeObject(dto);
            var byteArray = Encoding.UTF8.GetBytes(payLoad);
             var properties = _channel.CreateBasicProperties();
             properties.Persistent = true;
            _channel.BasicPublish("", _queue, properties, byteArray);
        }
    }
}