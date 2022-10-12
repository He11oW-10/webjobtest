using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using System.Net.Http;
using System.Threading.Tasks;

namespace webjobcon
{
    class Program
    {
        static void Main(string[] args)
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.ConnectionString ="InstrumentationKey=9bf0e014-3d3b-4b75-9833-45f4d8c0870d;IngestionEndpoint=https://centralus-2.in.applicationinsights.azure.com/;LiveEndpoint=https://centralus.livediagnostics.monitor.azure.com/";
            TelemetryClient client = new TelemetryClient(configuration);
            client.TrackTrace("This is from webjob.");
            for (int i = 0; i < 10; i++)
            {
                client.TrackEvent("Testing " + i);
            }          
            client.TrackException(new Exception("Demo exception."));
            client.TrackTrace("console stop.");
            client.Flush();
        }
    }
}