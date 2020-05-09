# Speedy Cultist

This is a mod for Cultist Simulator that adds the ability to warp time ahead to when the next verb / situation completes.

Download the latest release [here](https://github.com/RoboPhred/cultist-speedy/releases/).

## Usage

Once the mod is installed, the following hotkeys are available:

- F7 - Jump time ahead to the next event.

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

### Installing the mod to BepInEx

Place the CultistSpeedy.dll file in `Cultist Sumulator/BepInEx/Plugins`

### Troubleshooting

If the mod isn't working, you can turn on the BepInEx logs to see what is going on.

Open your BepInEx config file at `Cultist Simulator/BepInEx/config/BepInEx.cfg` and enable the console by changing the `Enabled` key of `[Logging.Console]` to `true`.
```
[Logging.Console]
Enabled = true
```

Doing this will create a terminal window when you launch cultist simulator.  If you do not see this new window open, then BepInEx is probably not installed correctly,
or the config file is misconfigured.

Once you get the window, check its output after you hit the play button on the Cultist Simulator launcher.  You can either drag the terminal window to another
monitor, or tab out of Cultist Simulator to check it after launch.

If BepInEx is installed and configured properly, you should see messages similar to the following:
```
[Message:   BepInEx] BepInEx 5.0.0.0 RC1 - cultistsimulator
[Message:   BepInEx] Compiled in Unity v2018 mode
[Info   :   BepInEx] Running under Unity v2019.1.0.2698131
[Message:   BepInEx] Preloader started
[Info   :   BepInEx] 1 patcher plugin(s) loaded
[Info   :   BepInEx] Patching [UnityEngine.CoreModule] with [BepInEx.Chainloader]
[Message:   BepInEx] Preloader finished
```

If you do not see these messages, and your terminal window remains blank, then you probably forgot to turn off `AllowRuntimePatches`.  Read the section on Installing again.

Once you have confirmed BepInEx is installed properly, look for the mod loading message.  Once you start the game from the launcher, the terminal window should contain:
```
[Info   :   BepInEx] Loading [CultistSpeedy 0.0.1]
```
and
```
[Info   :CultistSpeedy] CultistSpeedy initialized.
```

If you do not see these lines, then the mod isn't in the correct folder.  Check the Installation instructions for details on where to put the mod.

If you have confirmed all of the above and still are having trouble, try looking at the terminal for lines starting with `[Error  :CultistSpeedy]`.  The mod will
try to log errors when it cannot do it's job properly.  Create a github issue with any CultistSpeedy error messages you find, and I will try to help you further.

## Development

### Dependencies

Project dependencies should be placed in a folder called `externals` in the project's root directory.
This folder should include:
- BepInEx.dll - Copied from the BepInEx 5.0 installation under `BepInEx/core`
- Assembly-CSharp.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`
- UnityEngine.CoreModule.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`
- UnityEngine.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`
- UnityEngine.InputLegacyModule.dll - Copied from `Cultist Simulator/cultistsimulator_Data/Managed`

### Compiling

This project uses the dotnet cli, provided by the .Net SDK.  To compile, simply use `dotnet build` on the project's root directory.

## TODO

- Configurable hotkeys
- Configurable 'fast' game speed
