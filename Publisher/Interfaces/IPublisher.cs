using System.Threading.Tasks;

namespace eVendas.Publisher
{
    public interface IPublisher
    {
        Task SendMessageAsync<TMessage>(string topicName, TMessage message);
    }
}
