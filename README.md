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
Use **Extensions → Install from file** in Macro Deck, select the generated `.macroDeckPlugin`, and restart Macro Deck to complete the installation (Macro Deck applies local installs on restart).

<<<<<<< HEAD
<<<<<<< HEAD
## Packaging for distribution
Create a `.macroDeckPlugin` archive (zip with custom extension) containing:
```
Stubbs.HellDivers2Strats.dll
ExtensionManifest.json
Plugin.png
```
<<<<<<< HEAD
Macro Deck users can import the package through **Package Manager → Install from file**.
=======
## Installing manually
Copy the release DLL alongside `ExtensionManifest.json` and `ExtensionIcon.png` into `%AppData%\Macro Deck\plugins\Stubbs.HellDivers2Strats`, then restart Macro Deck.
>>>>>>> e8a3b94 (build fixes)
=======
## Installing manually
Copy the release DLL alongside `ExtensionManifest.json` and `ExtensionIcon.png` into `%AppData%\Macro Deck\plugins\Stubbs.HellDivers2Strats`, then restart Macro Deck.
>>>>>>> e8a3b94 (build fixes)
=======
Macro Deck users can import the package through **Package Manager -> Install from file**.
>>>>>>> 270ba632ef17768b56c849ba7c1b120439c0d169

## Publishing to the Extension Store
Follow the workflow in [Macro-Deck-Extensions](https://github.com/Macro-Deck-App/Macro-Deck-Extensions#readme). Provide this repository URL (`https://github.com/rstubbs94/Stubbs.HellDivers2Strats`) and version `1.0.0` when running the "Add/Update Extension" GitHub Action.

## License
Released under the MIT License. See [LICENSE](LICENSE).