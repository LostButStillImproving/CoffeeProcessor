using System.Collections;
using WiredBrainCoffee.DataProcessor.Data;
using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Processing;

public class MachineDataProcessorTests : IDisposable
{

    private readonly FakeCoffeeCountStore _coffeeCountStoreMock;
    private readonly MachineDataProcessor _machineDataProcessor;
    public MachineDataProcessorTests()
    {
        _coffeeCountStoreMock = new FakeCoffeeCountStore();
        _machineDataProcessor = new MachineDataProcessor(_coffeeCountStoreMock);
    }
    [Fact]
    public void ShouldSaveCountPerCoffeeType()
    {
        //arrange
        var dataItems = new []
        {
            new MachineDataItem("cappucino", new DateTime(2022, 9,27,8,0,0)),
            new("Latte", DateTime.Now)
        };
        //Act
        _machineDataProcessor.ProcessItems(dataItems);
        
        //Assert
        var expectedCoffeeCountItems = new List<CoffeeCountItem>
        {
            new("cappucino", 1),
            new("Latte", 1)
        };
        Assert.Equal(expectedCoffeeCountItems, _coffeeCountStoreMock.SavedItems);
    }
    
    [Fact]
    public void ShouldClearPreviousCoffeeCount()
    {
        //arrange
        var dataItems = new []
        {
            new MachineDataItem("cappucino", new DateTime(2022, 10,27,8,0,0)), 
        };
        //Act
        _machineDataProcessor.ProcessItems(dataItems);
        _machineDataProcessor.ProcessItems(dataItems);
        
        //Assert
        Assert.Equal(1, _coffeeCountStoreMock.SavedItems.Count);
        foreach (var item in _coffeeCountStoreMock.SavedItems)
        {
            Assert.Equal("cappucino", item.CoffeeType);
            Assert.Equal(1, item.Count);
        }
    }
    [Fact]
    public void ShouldIgnoreItemsThatAreNotNewer()
    {
        //arrange
        var dataItems = new []
        {
            new MachineDataItem("cappucino", new DateTime(2022, 11,27,8,0,0)), 
            new MachineDataItem("Espresso", new DateTime(2022, 10,27,8,0,0)),

        };
        //Act
        _machineDataProcessor.ProcessItems(dataItems);
        
        //Assert
        var expectedCoffeeCountItems = new List<CoffeeCountItem>
        {
            new("cappucino", 1),
        };
        Assert.Equal(expectedCoffeeCountItems, _coffeeCountStoreMock.SavedItems);
    }
    public void Dispose()
    {
        
    }
}
