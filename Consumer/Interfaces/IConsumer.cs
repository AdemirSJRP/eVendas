using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace eVendas.Consumer
{
    public interface IConsumer
    {
        Task ProcessMessageAsync<TMessage>(Message message, CancellationToken arg2);
    }
}
