using System;
using System.Text;
using System.Threading;
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
        private readonly IConnection _connection;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private const string _queue = "FilaPedidos";

        public Consumer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = connectionFactory.CreateConnection();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var pedidoRepository = scope.ServiceProvider.GetRequiredService<IPedidoRepository>();
                var channel = _connection.CreateModel();

                channel.QueueDeclare(_queue, true, false, false, null);
                var consume = new EventingBasicConsumer(channel);

                consume.Received += async (model, eargs) =>
                {
                    var message = eargs.Body.ToArray();
                    Console.WriteLine(message);
                    var content = Encoding.UTF8.GetString(message);
                    var events = JsonConvert.DeserializeObject<PaymentDTO>(content);

                    try
                    {
                        await Consume(events, pedidoRepository);
                        Console.WriteLine(events);
                        channel.BasicAck(eargs.DeliveryTag, false);
                        Console.WriteLine(events.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao consumir a mensagem: {ex.Message}");
                        // Realize qualquer tratamento de erro necessário
                        // Você pode optar por rejeitar (BasicReject) ou reenfileirar (BasicNack) a mensagem, se necessário
                    }
                };

                channel.BasicConsume(_queue, false, consume);

                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
        }

        private async Task Consume(PaymentDTO events, IPedidoRepository pedidoRepository)
        {
            // Use o pedidoRepository para atualizar o pagamento ou realizar qualquer lógica de consumo necessária
            var pedido =  pedidoRepository.UpdatePayment(events);
            Console.WriteLine("Pedido Recebido = " + pedido.ToString());
        }
    }
}
