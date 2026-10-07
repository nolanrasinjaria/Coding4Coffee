# Coding4Coffee.Basics

A lightweight, modern .NET 10 utility library providing strongly-typed configuration management, dynamic runtime localization, and reusable `ICommand` implementations.

## Features

- ⚙️ **Configuration Management**: Strongly-typed configuration wrapper (`Config<TValue>`) with JSON serialization and optional persistence via `SettingsBase`. Includes specialized handlers for 7 types with custom serialization needs (`CultureInfoConfig`, `DirectoryInfoConfig`, `FileInfoConfig`, `UriConfig`, `IPAddressConfig`, `VersionConfig`, `EncodingConfig`) and implicit cast operators.
- 🌐 **Dynamic Localization**: Runtime culture switching via `LocalizationManager`, localizable strings (`LocalizableString`) with formatting and fallback values, and automatic culture change notifications.
- ⚡ **MVVM Commands**: Ready-to-use `ICommand` implementations: `AlwaysExecutableCommand`, `AsyncCommandBase`, `AsyncCommandBase<T>`, and `SetCultureCommand`.

## Installation

Install via NuGet Package Manager CLI:

```bash
dotnet add package Coding4Coffee.Basics
```

## Quick Start

### 1. Configuration

```csharp
using Coding4Coffee.Basics.Configuration;
using System.Globalization;
using System.IO;

// Optional: Assign SettingsBase (e.g. Properties.Settings.Default) to persist values
// ConfigFactory.Settings = Properties.Settings.Default;

// Retrieve or create strongly-typed config settings
var themeConfig = ConfigFactory.GetConfig<string>("AppTheme");
themeConfig.Value = "Dark";
string? theme = themeConfig; // Implicit conversion

var timeoutConfig = ConfigFactory.GetConfig<int>("TimeoutSeconds");
timeoutConfig.Value = 30;
int timeout = timeoutConfig; // Implicit conversion

// Use specialized configs for types with custom serialization
var cultureConfig = ConfigFactory.GetCultureInfoConfig("AppCulture");
cultureConfig.Value = new CultureInfo("de-DE");
CultureInfo? culture = cultureConfig;

var dataDirConfig = ConfigFactory.GetDirectoryInfoConfig("DataDirectory");
dataDirConfig.Value = new DirectoryInfo(@"C:\AppData");
DirectoryInfo? dataDir = dataDirConfig;
```

### 2. Localization

```csharp
using Coding4Coffee.Basics.Localization;
using Coding4Coffee.Basics.Localization.Commands;
using System.Globalization;

// 1. Assign your application's ResourceManager
BasicsLocalizationExtensions.ResourceManager = MyResources.ResourceManager;

// 2. Optionally configure culture persistence key (auto-saves/loads via ConfigFactory)
LocalizationManager.CultureConfigKey = "AppCulture";

// 3. Change application culture at runtime (notifies subscribers via CultureChanged event)
LocalizationManager.CurrentCulture = new CultureInfo("de-DE");

// 4. Use LocalizableString with resource key and fallback value
var greeting = new LocalizableString("Greeting_Hello", "Hello World!");
Console.WriteLine(greeting.ToString());
string text = greeting; // Implicit conversion to string

// 5. Or switch cultures using SetCultureCommand (e.g. in UI bindings)
SetCultureCommand.Instance.Execute("en-US");
```

## API Reference

### Configuration Management

#### ConfigFactory
- `GetConfig<T>(string key)` - Get or create a generic configuration
- `GetCultureInfoConfig(string key)` - Get or create a CultureInfo configuration
- `GetDirectoryInfoConfig(string key)` - Get or create a DirectoryInfo configuration
- `GetFileInfoConfig(string key)` - Get or create a FileInfo configuration
- `GetUriConfig(string key)` - Get or create a Uri configuration
- `GetIPAddressConfig(string key)` - Get or create an IPAddress configuration
- `GetVersionConfig(string key)` - Get or create a Version configuration
- `GetEncodingConfig(string key)` - Get or create an Encoding configuration

#### Config<T>
- `Value` - Get or set the configuration value
- Implicit cast to `T?` for easy access

### Localization Management

#### LocalizationManager
- `CurrentCulture` - Get or set the current application culture
- `CultureConfigKey` - Get or set the key for persisting culture preference
- `CultureChanged` - Event raised when culture changes

#### LocalizableString
- Constructor: `LocalizableString(string resourceKey, string fallbackValue)`
- `ToString()` - Get the localized string value
- Implicit cast to `string`

## License

Distributed under the MIT License.
