# Stubbs.HellDivers2Strats

Macro Deck plugin that automates Helldivers 2 stratagem call-ins from a single deck button. Each action simulates the directional inputs required to request a stratagem in-game.

## Features
- Built-in registry of every Helldivers 2 stratagem, selectable from a searchable drop-down.
- Sends the exact key sequence using the Windows `keybd_event` API so you do not need to remember combos mid-mission.
- Adjustable timings (press duration, delay between presses, post-CTRL delay) to match your personal key repeat preferences.
- Advanced key map override that lets you remap the default WASD + CTRL inputs if you play with a custom layout.

## Requirements
- Macro Deck 2.14.1 or newer (Plugin API v40).
- Windows 10/11.
- .NET 8 SDK if you plan to build the plugin yourself.

## Building
```powershell
# Restore dependencies and build a release binary
cd src
dotnet build -c Release
```
The compiled plugin can be found at `src\bin\Release\net8.0-windows\Stubbs.HellDivers2Strats.dll`.

## Packaging (.macroDeckPlugin)
```powershell
cd C:\Dev\Stubbs.HellDivers2Strats
Remove-Item dist -Recurse -Force -ErrorAction SilentlyContinue
mkdir dist
Copy-Item ExtensionManifest.json, ExtensionIcon.png dist
Copy-Item src\bin\Release\net8.0-windows\Stubbs.HellDivers2Strats.dll dist
Compress-Archive dist\ExtensionManifest.json,dist\ExtensionIcon.png,dist\Stubbs.HellDivers2Strats.dll dist\Stubbs.HellDivers2Strats-1.0.0.zip -Force
Rename-Item dist\Stubbs.HellDivers2Strats-1.0.0.zip Stubbs.HellDivers2Strats-1.0.0.macroDeckPlugin
```
Import the generated `.macroDeckPlugin` via **Extensions -> Install from file** inside Macro Deck and restart the app to activate the plugin.

## Manual Installation
Copy `Stubbs.HellDivers2Strats.dll`, `ExtensionManifest.json`, and `ExtensionIcon.png` into `%AppData%\Macro Deck\plugins\Stubbs.HellDivers2Strats`, then restart Macro Deck.

## Publishing to the Extension Store
1. Update the metadata in `ExtensionManifest.json` (notably `version`) to match the release.
2. Build and package the plugin (see steps above) and smoke-test by importing the archive locally.
3. Sign in to the [Macro Deck developer portal](https://my.macrodeck.org) and upload the `.macroDeckPlugin` along with screenshots and release notes.
4. Submit the listing for review and, once approved, tag the corresponding release in this repository.

## License
Released under the MIT License. See [LICENSE](LICENSE).

