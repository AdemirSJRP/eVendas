using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Utils;

namespace eVendas.Publisher
{
    public class PublisherProduto : IPublisher
    {

        private readonly IConfiguration _configuration;

        public PublisherProduto(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync<TMessage>(string topicName, TMessage message)
        {
            var serviceBusClient = new TopicClient(_configuration.GetConnectionString("AzureServiceBus"), topicName);
            var msg = new Message(message.ToJsonBytes()) { ContentType = "application/json" };
            await serviceBusClient.SendAsync(msg);
        }
    }
}
