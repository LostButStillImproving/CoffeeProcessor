using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Data;

public class FakeCoffeeCountStore :ICoffeeCountStore
{
    public List<CoffeeCountItem> SavedItems { get; } = new();
    public void Save(CoffeeCountItem item)
    {
        SavedItems.Add(item);
    }
}