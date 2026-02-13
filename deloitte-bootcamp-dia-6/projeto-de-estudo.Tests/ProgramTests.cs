using Xunit;
using Microsoft.Extensions.DependencyInjection;
using MinhaApi.Services;
using StackExchange.Redis;
using MinhaApi.Queue;

namespace projeto_de_estudo.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void DeveRegistrarDependencias()
        {
            var services = new ServiceCollection();

            services.AddSingleton<LoteService>();

            var provider = services.BuildServiceProvider();

            var service = provider.GetService<LoteService>();

            Assert.NotNull(service);
        }
    }
}
