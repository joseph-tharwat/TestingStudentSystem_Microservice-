using Microsoft.Extensions.Configuration;
using Serilog;

namespace SharedLogger
{
    public static class SerilogSeqConfiguration
    {
        public static void SerilogSeqConfigur(string serviceName, IConfiguration config)
        {
            var seqUrl = config.GetSection("Seq:Url").Value ?? "http://localhost:5341";
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Service", serviceName)
                .Enrich.FromLogContext()
                .WriteTo.Seq(seqUrl)
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
