using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine
{
    public static class Utilities
    {
        public static readonly Random RandomOjbect = new Random();

        public static IEnumerable<Symbol> GetSymbols()
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
                .Select(c => new Symbol(c.ToString(), GenerateRandomPrice()));
        }

        public static decimal GenerateRandomPrice()
        {
            return RandomOjbect.Next(10, 1000);
        }

        public static string GenerateRandomSymbolName()
        {
            var num = RandomOjbect.Next(0, 26);
            var symbolName = ((char) ('A' + num)).ToString();
            return symbolName;
        }
    }
}