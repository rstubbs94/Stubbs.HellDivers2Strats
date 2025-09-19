# Stubbs.HellDivers2Strats

Macro Deck 2 plugin that exposes Helldivers 2 stratagems as ready-to-use actions. Each action sends the correct Control + arrow inputs so the stratagem picker opens and the combination executes in sequence.

## Features
- 80 stratagem definitions covering reinforcements, resupplies, sentries, exosuits, and more.
- Simple configuration: pick a stratagem from the dropdown; no manual key mapping required.
- Timing tuned for the in-game stratagem wheel using native key simulation (`keybd_event`) for broad compatibility.

## Requirements
- [Macro Deck 2](https://macrodeck.org/) version 2.14.1 or newer.
- Plugin API version 40.
- Windows.

## Building
```powershell
cd src
# Restore dependencies and build a release binary
dotnet build -c Release
```
The compiled plugin can be found at `src\bin\Release\net8.0-windows\Stubbs.HellDivers2Strats.dll`.

## Installing locally
1. Build the plugin (see above).
2. Copy the release DLL alongside `ExtensionManifest.json` and `Plugin.png` into `%AppData%\Macro Deck\plugins\Stubbs.HellDivers2Strats`.
3. Restart Macro Deck and add the **Helldivers 2 Stratagem** action to a button.

## Packaging for distribution
Create a `.macroDeckPlugin` archive (zip with custom extension) containing:
```
Stubbs.HellDivers2Strats.dll
ExtensionManifest.json
Plugin.png
```
Macro Deck users can import the package through **Package Manager -> Install from file**.

## Publishing to the Extension Store
Follow the workflow in [Macro-Deck-Extensions](https://github.com/Macro-Deck-App/Macro-Deck-Extensions#readme). Provide this repository URL (`https://github.com/rstubbs94/Stubbs.HellDivers2Strats`) and version `1.0.0` when running the "Add/Update Extension" GitHub Action.

## License
Released under the MIT License. See [LICENSE](LICENSE).