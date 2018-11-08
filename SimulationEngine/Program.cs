using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using SimulationEngine.MarketWatchService;

namespace SimulationEngine
{
    internal class Program
    {
        private static bool _isStarted;
        private static EventWaitHandle _terminator;

        private static readonly Dictionary<string, Symbol> SymbolDictionary = new Dictionary<string, Symbol>();
        private static readonly MarketWatchClient Client =
            new MarketWatchClient(new InstanceContext(null, new ClientCallback()));

        private static void Main(string[] args)
        {
            foreach (var symbol in Utilities.GetSymbols()) SymbolDictionary.Add(symbol.Name, symbol);

            Console.WriteLine("Choose a command.");
            Console.WriteLine("Start/Stop/Exit");
            var command = Console.ReadLine()?.ToLower();

            while (!string.Equals(command, "exit"))
            {
                switch (command)
                {
                    case "start":
                        Console.WriteLine("Starting ...");
                        Start();
                        Console.WriteLine("Started.");
                        break;
                    case "stop":
                        Console.WriteLine("Stopping ...");
                        Stop();
                        Console.WriteLine("Stopped.");
                        break;
                    default:
                        Console.WriteLine("Unknown command...");
                        break;
                }

                command = Console.ReadLine()?.ToLower();
            }
        }

        private static void Start()
        {
            if (_isStarted) return;

            _terminator = new EventWaitHandle(false, EventResetMode.ManualReset);
            var t = new Thread(UpdateSymbolPricesWorker);
            t.Start();

            _isStarted = true;
        }

        private static void Stop()
        {
            if (!_isStarted) return;

            _terminator.Set();

            _isStarted = false;
        }

        private static void UpdateSymbolPricesWorker()
        {
            while (!_terminator.WaitOne(TimeSpan.FromMilliseconds(500)))
                SetPrice(Utilities.GenerateRandomSymbolName(), Utilities.GenerateRandomPrice());
        }

        private static void SetPrice(string name, decimal price)
        {
            if (SymbolDictionary.TryGetValue(name, out var symbol))
            {
                if (symbol.Price == price) return;

                symbol.Price = price;
                Client.PublishPriceChange(symbol.Name, symbol.Price);
            }
        }
    }
}