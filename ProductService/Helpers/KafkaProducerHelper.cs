using Confluent.Kafka;
using System.Text.Json;

namespace ProductService.Helpers
{
    public class KafkaProducerHelper
    {
        private readonly IConfiguration _configuration;

        public KafkaProducerHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ProduceAsync<T>(string topic, T message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var jsonMessage = JsonSerializer.Serialize(message);

            await producer.ProduceAsync(topic, new Message<Null, string> { Value = jsonMessage });
        }
    }
}