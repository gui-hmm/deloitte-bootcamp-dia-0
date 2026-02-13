using MinhaApi.Queue;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaApi.Tests.Fakes
{
    public class FakeLoteQueueProducer : ILoteQueueProducer
    {
        public Task EnfileirarAsync(
            ProcessarLoteMessage message,
            CancellationToken cancellationToken)
        {
            // Fake não precisa fazer nada
            // apenas simular sucesso

            return Task.CompletedTask;
        }
    }
}
