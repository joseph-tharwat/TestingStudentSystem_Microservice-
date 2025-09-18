
namespace GradingManagment.Infrastructure.RabbitMQ
{
    public class GetTestInfoWorker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            return Task.CompletedTask;
        }
    }
}
