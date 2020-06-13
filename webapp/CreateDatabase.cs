using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using webapp.Data;

namespace webapp
{
    public class CreateDatabase : IHostedService
    {
        readonly IServiceScopeFactory _scopeFactory;

        public CreateDatabase(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await dbContext.Database.EnsureCreatedAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}