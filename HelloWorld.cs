using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace HelloWorldLib
{
    public class HelloWorld : IHelloWorld
    {
        private readonly ILogger<HelloWorld> _logger;

        public HelloWorld(ILogger<HelloWorld> logger)
        {
            _logger = logger;
        }

        public string SayHello(string name)
        {
            using var activity = Activity.Current?.Source.StartActivity("HelloWorld.SayHello");

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "there";
            }

            _logger.LogInformation("Saying hello to {Name}", name);

            return $"Hello, {name}!";
        }
    }
}
