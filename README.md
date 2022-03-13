# Wox.Plugin.Bookmarks

## Usage

Open Wox and use the following keyword:

- bm: Open bookmark in default browser

## Installation

Copy the files located in the .7z file attached to the release

To this directory:

- `~\AppData\Local\Wox\app-*\Plugins\Wox.Plugin.Devbox`

Restart Wox

Contributing -- Build, Test, and Release

> Note: If you modify the ActionKeywords in plugin.json, the ID will need to be changed for Wox to pick up the new keywords

Build the solution:

- `dotnet build -c Release`

In order to test the Plugin while working:

- Build the solution
- If wox is currently running, you will have to exit wox before continuing
- Run the provided release.sh script
  - Update the WOX_VERSION variable at the top of the script to your wox version
  - This bundles all needed files and places them here: `~\AppData\Local\Wox\app-*\Plugins\Wox.Plugin.Devbox`
- Restart wox and test your changes

Create a Release:

- Use 7-zip to archive the plugin files located in the Wox.Plugin.Devbox directory
- Use this archive to create the releasert Wox

