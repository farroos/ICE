using System.ServiceModel;
using MarketWatch.Interface;

namespace MarketWatch.Service
{
    public class MarketWatch : IMarketWatch
    {
        public delegate void PriceChangeDelegate(object sender, PriceChangeEventArgs e);

        public void Subscribe()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IClientCallback>();

            PriceChangeEvent += delegate(object sender, PriceChangeEventArgs args)
            {
                callback.NotifyPriceChange(args.Symbol, args.Price);
            };
        }

        public void PublishPriceChange(string symbol, decimal newPrice)
        {
            PriceChangeEvent?.Invoke(this, new PriceChangeEventArgs(symbol, newPrice));
        }

        public static event PriceChangeDelegate PriceChangeEvent;
    }
}