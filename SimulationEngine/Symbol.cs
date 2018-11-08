namespace SimulationEngine
{
    public class Symbol : ISymbol
    {
        public Symbol(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public decimal Price { get; set; }
    }
}