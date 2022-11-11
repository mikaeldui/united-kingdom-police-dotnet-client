# United Kingdom Police .NET Client
[![.NET](https://github.com/mikaeldui/united-kingdom-police-dotnet-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/united-kingdom-police-dotnet-client/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/united-kingdom-police-dotnet-client/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/united-kingdom-police-dotnet-client/actions/workflows/codeql-analysis.yml)

The API provides a rich data source for information, including:

neighbourhood team members
upcoming events
street-level crime and outcome data
nearest police stations

You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.UnitedKingdom.Police.Client --version *

## Example

```csharp

using PoliceClient client = new();

var crimes = await client.Crimes.GetStreetlevelCrimesAsync(51.375487, -0.096780);

foreach(var crime in crimes)
    Console.WriteLine(crime.Category);
```
