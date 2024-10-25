using ApplicationLayer.Interfaces.InfrastructureLayer;
using Hangfire;

namespace InfrastructureLayer.Services
{
    public class JobsService : IJobsService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public JobsService(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        public void OneTime()
        {
            _backgroundJobClient.Enqueue(() => Console.WriteLine("One-time job"));

        }
        public void Delayed()
        {
            _backgroundJobClient.Schedule(() => Console.WriteLine("Delayed job"), TimeSpan.FromSeconds(10));
        }
        public void Recurring()
        {
            _recurringJobManager.AddOrUpdate("my-recurring-job", () => Console.WriteLine("Recurring job"), Cron.Daily);
        }
        public void Continuation()
        {
            var jobId = _backgroundJobClient.Enqueue(() => Console.WriteLine("First job"));
            _backgroundJobClient.ContinueWith(jobId, () => Console.WriteLine("Continuation job"));
        }
    }
}
