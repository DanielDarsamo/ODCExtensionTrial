using OutSystems.ExternalLibraries.SDK;

namespace HelloWorldLib
{
    [OSInterface(
        Description = "A tiny library that greets a user by name.",
        IconResourceName = "HelloWorldLib.Resources.icon.png",
        Name = "HelloWorldLib"
    )]
    public interface IHelloWorld
    {
        /// <summary>
        /// Returns a greeting for the given name, e.g. "Hello, Duarte!"
        /// </summary>
        [OSAction(Description = "Returns a friendly greeting for the given name.")]
        string SayHello(
            [OSParameter(Description = "The name of the user typing their name.")] string name
        );
    }
}
