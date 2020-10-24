using SimpleNetCoreApi.Controllers;
using Xunit;

namespace SimpleNetCoreApiTests
{
    public class GreetingControllerTests
    {
        
        [Fact]
         public void ShouldGetHelloWorldMessage()
         {
             var expected = "Hello, World!";
             var greedingEndpoint = new GreetingController();

             var response = greedingEndpoint.Get();

             Assert.Equal(expected, response);
         }
    }
}
