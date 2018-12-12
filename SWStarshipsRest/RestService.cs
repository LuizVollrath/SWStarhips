using Nancy.Hosting.Self;
using System;
using System.Threading;

namespace SWStarshipsRest
{
    public class RestFranquia : IDisposable
    {
        private NancyHost nancyHost;

        public RestFranquia(string host)
        {
            SetupConfiguration(host);
        }

        private void SetupConfiguration(string host)
        {
            try
            {
                HostConfiguration hostConfigs = new HostConfiguration()
                {
                    UrlReservations = new UrlReservations() { CreateAutomatically = true }
                };
                nancyHost = new NancyHost(new Uri(host));
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {       
            }
        }

        public void StartServer()
        {
            nancyHost.Start();
        }

        public void StopServer()
        {
            nancyHost.Stop();
        }

        public void Dispose()
        {
            nancyHost?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}