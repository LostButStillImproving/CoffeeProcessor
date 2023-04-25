using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Data;

public class ConsoleCoffeeCountStore : ICoffeeCountStore
{
    private readonly TextWriter _textWriter;

    public ConsoleCoffeeCountStore():this(Console.Out) {}
    public ConsoleCoffeeCountStore(TextWriter textWriter)
    {
        _textWriter = textWriter;
    }
    public void Save(CoffeeCountItem item)
    {
        _textWriter.WriteLine($"{item.CoffeeType}:{item.Count}");
    }
}