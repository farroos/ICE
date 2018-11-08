namespace SimulationEngine
{
    public interface ISymbol
    {
        string Name { get; }
        decimal Price { get; set; }
    }
}