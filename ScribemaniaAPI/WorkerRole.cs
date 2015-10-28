using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ScribemaniaAPI
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        private IDisposable app = null;

        public override void Run()
        {
            Trace.TraceInformation("ScribeAPI entry point called.");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections for worker role
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            ServicePointManager.DefaultConnectionLimit = 12;

            #if DEBUG
            var endpointName = "development";
            #else
            var endpointName = "production";
            #endif

            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[endpointName];
            string baseUri = String.Format("{0}://{1}",
                endpoint.Protocol, endpoint.IPEndpoint);

            Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseUri));

            app = WebApp.Start<Startup>(new StartOptions(url: baseUri));

            bool result = base.OnStart();

            Trace.TraceInformation("ScribeAPI has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("ScribeAPI is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            if (app != null)
            {
                app.Dispose();
            }

            base.OnStop();

            Trace.TraceInformation("ScribeAPI has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }
    }
}