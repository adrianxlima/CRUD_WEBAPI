using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PedidoWebApi.Api.Repository;
using PedidoWebApi.Domain.Domain.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PedidoWebApi.Api.Infrastructure
{
    public class Consumer : BackgroundService
    {   
        private readonly IModel _channel;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IConnection _connection;
        
        private const string RouterSubScribe = "FilaPagamentos";
        private const string _queue = "FilaPedidos";
        private const string TrackingsExchange = "tracking-service";
        public  Consumer( IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                
            };
    

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task Consume(PaymentDTO events)
        {
          var pedido =  _pedidoRepository.UpdatePayment(events);
          Console.WriteLine(pedido);
          return Task.CompletedTask;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.ExchangeDeclare(TrackingsExchange, "topic", true, false);
            _channel.QueueDeclare(_queue, true, false, false);
            _channel.QueueBind(_queue, TrackingsExchange, RouterSubScribe);
            var consume = new EventingBasicConsumer(_channel);
            consume.Received+=(model, eargs)=> {
                var message = eargs.Body.ToArray();
                var content = Encoding.UTF8.GetString(message);
                var events = JsonConvert.DeserializeObject<PaymentDTO>(content);
                this.Consume(events).Wait();
                Console.WriteLine(events);
                _channel.BasicAck(eargs.DeliveryTag, false);
                Console.WriteLine(events.ToString());
            };
            _channel.BasicConsume(_queue, false, consume);
            return Task.CompletedTask;
        }
    }
}