using System;

namespace MarketWatch.Service
{
    public class PriceChangeEventArgs : EventArgs
    {
        internal PriceChangeEventArgs(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }

        public string Symbol { get; }
        public decimal Price { get; }
    }
}