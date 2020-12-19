using Microsoft.Azure.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eVendas.Consumer
{
    public class ConsumerProduto : IConsumer
    {
        public Task ProcessMessageAsync<TMessage>(Message message, CancellationToken arg2)
        {
            throw new NotImplementedException();
        }
    }
}
