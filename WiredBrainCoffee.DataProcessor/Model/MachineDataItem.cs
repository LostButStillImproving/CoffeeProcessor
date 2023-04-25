namespace WiredBrainCoffee.DataProcessor.Model
{
    public class MachineDataItem
    {
        public MachineDataItem(string coffeeType, DateTime createdAt)
        {
            CoffeeType = coffeeType;
            CreatedAt = createdAt;
        }

        public string CoffeeType { get; }
        public DateTime CreatedAt { get; }

        public override bool Equals(object? obj)
        {
            return CoffeeType == ((MachineDataItem)obj).CoffeeType && CreatedAt == ((MachineDataItem)obj).CreatedAt;
        }
    }
}
