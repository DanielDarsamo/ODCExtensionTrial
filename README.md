# HelloWorldLib — ODC External Library (mini example)

A minimal OutSystems Developer Cloud (ODC) External Library. Exposes one
server action, `SayHello(name)`, that returns `"Hello, <name>!"`.

## Files

- `IHelloWorld.cs` — public interface decorated with `[OSInterface]`,
  `[OSAction]`, `[OSParameter]`. This is what ODC maps to a server action.
- `HelloWorld.cs` — implementation, with logging + a tracing span.
- `HelloWorldLib.csproj` — class library project targeting `.NET 10.0`,
  referencing the OutSystems External Libraries SDK.

## Prerequisites

- .NET 10.0 SDK
- NuGet
- Visual Studio / VS Code / Rider

## Build & package

1. Open `HelloWorldLib.csproj` in your IDE (or `cd` into this folder).
2. Restore + publish:
   ```
   dotnet publish -c Release --no-self-contained
   ```
   (If you hit runtime-specific dependency issues, target Linux explicitly:
   `dotnet publish -c Release -r linux-x64 --no-self-contained`)
3. Zip the **contents** of the publish output folder (not the folder itself)
   into a ZIP file:
   ```
   ./HelloWorldLib/bin/Release/net10.0/publish/*
   ```

## Upload to ODC

1. In the ODC Portal, go to **External logic** (as in your screenshot) →
   **Create library from external code**.
2. Drag & drop (or Browse to) the ZIP you just built.
3. Review the detected interface/action/parameters, then **Continue** →
   **Publish** → **Release** the library.

## Use it in an app

Once released, `HelloWorldLib` becomes available as a reusable dependency.
In an ODC app screen:

1. Add a Text Input widget bound to a local variable `Name`.
2. Add a Button, and in its `OnClick` client action, call the server action
   `HelloWorld.SayHello(Name)`.
3. Bind the return value to a label to display the greeting.

## Extending it

- Add more methods to `IHelloWorld` (each becomes a new server action).
- Add a struct decorated with `[OSStructure]` if you want to return more
  than a plain string (e.g. a `Greeting` struct with `Message` and
  `Timestamp`).
