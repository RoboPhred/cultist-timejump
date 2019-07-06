# Speedy Cultist

This is a mod for Cultist Simulator to add a faster game speed and allow skipping ahead to the next situation event.

## Usage

Once the mod is installed, 2 hotkeys will be made active:

- F7 - Set the game to a speed higher than "Fast"
- F8 - Jump time ahead to the next event.

## Installation

This mod uses BepInEx 5.0.  You must install BepInEx to use this mod.

### Setting up BepInEx 5.0
You must use the [version 5.0 RC1](https://github.com/BepInEx/BepInEx/releases/tag/v5.0-RC1) or later, as earlier versions rely on Harmony.

Once you install BepInEx 5.0, you need to shut off harmony support, or no plugins will load.  To do this, edit `Cultist Simulator/BepInEx/config/BepInEx.cfg` and set `ApplyRuntimePatches` to false:
You may have to run Cultist Simulator once after installing BepInEx to generate the config file.
```
[Preloader]
ApplyRuntimePatches = false
```

You can test to ensure the plugins are being loaded by turning on the debug console in the config file.
```
[Logging.Console]
Enabled = true
```

If you do not see BepInEx debug output, then the `ApplyRuntimePatches` setting is probably still enabled, causing BepInEx to fail to initialize.
A successful BepInEx start will emit log messages to tell you it is scanning for and loading plugins appropriately.

### Installing the mod to BepInEx

Place the CultistSpeedy.dll file in `Cultist Sumulator/BepInEx/Plugins`

## Development

### Dependencies

Project dependencies should be placed in a folder called `externals`, placed in the project's root directory.
This folder should include:
- BepInEx.dll - Copied from the BepInEx 5.0 installation under `BepInEx/core`
- Assembly-CSharp.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`
- UnityEngine.CoreModule.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`
- UnityEngine.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`

### Compiling

This project uses the dotnet cli, provided by the .Net SDK.  To compile, simply use `dotnet build` on the project's root directory.

## TODO

- Configurable hotkeys
- Configurable ultra-fast speed