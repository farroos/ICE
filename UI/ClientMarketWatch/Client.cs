using System;
using System.ServiceModel;
using ClientMarketWatch.MarketWatchService;

namespace ClientMarketWatch
{
    public class Client : IMarketWatchCallback
    {
        private readonly Action<string, string, decimal> _priceChangeDelegate;

        public Client(string source, string endpoint, Action<string, string, decimal> priceChangeDelegate)
        {
            Source = source;
            Endpoint = endpoint;
            _priceChangeDelegate = priceChangeDelegate;
        }

        public string Source { get; }
        public string Endpoint { get; }

        public void NotifyPriceChange(string symbol, decimal price)
        {
            _priceChangeDelegate?.Invoke(Source, symbol, price);
        }

        public void Load()
        {
            var site = new InstanceContext(null, new Client(Source, Endpoint, _priceChangeDelegate));
            var client = new MarketWatchClient(site, Endpoint);

            var binding = (WSDualHttpBinding) client.Endpoint.Binding;
            var clientCallbackAddress = binding.ClientBaseAddress.AbsoluteUri;
            clientCallbackAddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientCallbackAddress);

            client.Subscribe();
        }
    }
}