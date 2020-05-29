# WebOsTv.Net
A .NET Standard library for interacting with LG WebOS televisions.

## Installation

Install using the nuget Package Manager:

```
Install-Package WebOsTv.Net
```

## Simple Usage

The easiest way to interact with the library is via the `Service` class:

```csharp
var service = new WebOsTv.Net.Service();

// Connect using IP Address - can also use a hostname.
await service.ConnectAsync("192.168.1.82");

// Examples 
await service.Audio.MuteAsync();
await service.Control.PlayAsync();
await service.Apps.LaunchAsync("abc");

service.Close();
```

The various methods are divided between `service.Api`,  `service.Apps`, `service.Audio`, `service.Control`, `service.Notification` and `service.Tv` .

## Advanced Usage

To have more control of the process and to receive fuller details of some responses, you can use the `Client` class:

```csharp
using var client = new WebOsTv.Net.Client();

// Connect using IP Address - can also use a hostname.
await client.ConnectAsync("192.168.1.82");

// Example
var response = await client.SendCommandAsync<ListLaunchPointsResponse>(new ListLaunchPointsCommand());
```

## Powering on the television

This library does not support the scenario as it isn't part of the LG WebSockets API. An LG TV can be switched on via Wake-On-Lan, however.

## Key Storage

The first time you connect to your LG TV you will need to approve the request for your code to control your TV. If you don't do this, the vast majority of commands will not work. 

Upon approving access, the code will be issued with a key. This is saved in a JSON file (`lgkeys.json`) in the same folder as WebOsTv.Net.dll using the default `IKeyStore` implementation. 

A custom `IKeyStore` implementation can be passed to the `Client` if this approach is too simplistic for your needs.

## Dependency Injection

Both the `Service` and `Client` classes can have their dependencies injected with the overloaded constructors of each. This is how you would inject your custom `IKeyStore` implementation, for example.

## Integration Testing

Tests within the `IntegrationTests.cs` file in the test project are marked with a `[DebugOnly]` attribute. As the name suggests, these tests will only be run on-demand in *debug* and will be skipped when *run*.

To prepare for testing, take a copy of the `device-template.json` and name it `device.json` . Insert the IP Address of your LG television. This file will not be pushed to GitHub when you commit as it's excluded by the `.gitignore` file.

Then run one of the integration tests in debug.

The software has been written and tested against an *LG 43UM7500PLA 43-Inch UHD 4K HDR Smart LED TV with Freeview Play* in the United Kingdom.