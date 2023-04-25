using System.Globalization;
using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Parsing;

public class CsvLineParserTests
{
    [Fact]
    public void ShouldParseValidLine()
    {
        
        //arrange
        string[] csvLines = { "Cappuccino;10/27/2022 8:15:43 AM" };
        
        //act
        var machineDataItems = CsvLineParser.Parse(csvLines);
        
        //assert
        var coffeeType = "Cappuccino";
        var dateTime = DateTime.Parse("10/27/2022 8:15:43 AM", CultureInfo.InvariantCulture);
        
        Assert.NotNull(machineDataItems);
        Assert.Single(machineDataItems);
        Assert.Equal(new MachineDataItem(coffeeType, dateTime), machineDataItems.First());
    }

    [Fact]
    public void ShouldSkipEmptyLines()
    {
        //arrange
        string[] csvLines = {"", " "};
        
        //act
        var machineDataItems = CsvLineParser.Parse(csvLines);
        
        //assert
        Assert.NotNull(machineDataItems);
        Assert.Empty(machineDataItems);
    }
    [InlineData("Cappuccino", "Invalid csv line")]
    [InlineData("Cappuccino; InvalidDateTime", "Invalid datetime in csv line")]
    [Theory]
    public void ShouldThrowExceptionForInvalidLine(string csvLine, string expectedMessagePrefix)
    {
        //arrange
        string[] csvLines = {csvLine};
        
        //Act
        var message = Assert.Throws<Exception>(() => CsvLineParser.Parse(csvLines)).Message;
        
        //assert the message
        Assert.Equal($"{expectedMessagePrefix}: {csvLine}", message);
    }
}