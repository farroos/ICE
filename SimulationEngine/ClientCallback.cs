using System;
using SimulationEngine.MarketWatchService;

namespace SimulationEngine
{
    public class ClientCallback : IMarketWatchCallback
    {
        public void NotifyPriceChange(string symbol, decimal price)
        {
            Console.WriteLine($"Price change - Symbol: {symbol}, Price: {price:C}");
        }
    }
}