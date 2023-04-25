using WiredBrainCoffee.DataProcessor.Data;
using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessorTests.Data
{
    public class ConsoleCoffeeCountStoreTests
    {
        [Fact]
        public void ShouldWriteOutputToConsole()
        {
            //arrange
            var item = new CoffeeCountItem("cappucino", 5);
            var stringWriter = new StringWriter();
            var consoleCoffeeCountStore = new ConsoleCoffeeCountStore(stringWriter);
            
            //act
            consoleCoffeeCountStore.Save(item);
            
            //assert
            var output = stringWriter.ToString();
            Assert.Equal($"{item.CoffeeType}:{item.Count}{Environment.NewLine}", output);
        }
    }
}