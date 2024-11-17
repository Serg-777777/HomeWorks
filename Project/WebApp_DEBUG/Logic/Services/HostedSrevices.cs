

namespace WebApp_DEBUG.Logic.Services
{
	//прогрев синхроно
	public class HostedSrevices : IHostedService 
    {
        ILogger<HostedSrevices> _logger;
        public HostedSrevices(ILogger<HostedSrevices> logger)
        {
            _logger = logger;

		}
		public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogError(":::Hosted Start");
            return Task.CompletedTask;
		}

        public Task StopAsync(CancellationToken cancellationToken)
        {
			_logger.LogError(":::Hosted Stop");
			return Task.CompletedTask;
		}
    }

	//фоновая задача асинхроно
	public class BackgroundHosted :BackgroundService 
    {
		ILogger<BackgroundHosted> _logger;
		public BackgroundHosted(ILogger<BackgroundHosted> logger)
		{
			_logger = logger;
		}
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
            while(!stoppingToken.IsCancellationRequested)
            {
				_logger.LogError ($":::BackgroundService Excute: {DateTime.UtcNow}");
				await Task.Delay(20000);
            }

			_logger.LogError(":::BackgroundService Exit");
		}
	}
}



