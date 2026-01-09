NOFrameLimiter - Simple FPS Limiter Plugin for Nuclear Option.

Requires BepInEx 5

Installation Instructions:

0. [Download](https://github.com/KopterBuzz/NOFrameLimiter/releases) the latest release of the mod. Unzip it somewhere.
1. Download and install the latest release of [BepInEx 5](https://github.com/BepInEx/BepInEx/releases/latest) for Nuclear Option.

	You need the latest "BepInEx_win_x64" release of BepInEx 5.

	[BepInEx Installation Guide.](https://docs.bepinex.dev/articles/user_guide/installation/index.html#where-to-download-bepinex)
2. After installing BepInEx, run the game once so BepInEx can generate its default directory and file structure.
3. Copy the NOFrameLimiter.dll file to the game's BepInEx plugins folder.
4. After you loaded the plugin once, there will be a KopterBuzz.NOFrameLimiter.cfg in the game's BepInEx/Plugins Folder. You can set the FPS Limit there by changing the FrameRateLimit value:
```
## Settings file was created by plugin NOFrameLimiter v0.0.1
## Plugin GUID: KopterBuzz.NOFrameLimiter

[General Settings]

## Maximum Desired Frame Rate. -1 = Unlimited. Default = 60
# Setting type: Int32
# Default value: 60
FrameRateLimit = 60
```
Alternatively you can use [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) ([Latest Release](https://github.com/BepInEx/BepInEx.ConfigurationManager/releases), download the BepInEx5 version) to configure the setting at runtime from its GUI (F1 key by default)
