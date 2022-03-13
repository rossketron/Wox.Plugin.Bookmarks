#!/usr/bin/env bash

#################################
WOX_VERSION="1.3.524"
#################################

if [ -d release ]; then
  rm -r release
fi

mkdir release
cp ./bin/Debug/*.dll* release/
cp ./bin/Debug/*.xml release/
cp ./plugin.json release/
cp ./Prompt.png release/

if [ -d ~/AppData/Local/Wox/app-$WOX_VERSION/Plugins/Wox.Plugin.Bookmarks ]; then
  rm -r ~/AppData/Local/Wox/app-$WOX_VERSION/Plugins/Wox.Plugin.Bookmarks
fi

mkdir ~/AppData/Local/Wox/app-$WOX_VERSION/Plugins/Wox.Plugin.Bookmarks
mv release/* ~/AppData/Local/Wox/app-$WOX_VERSION/Plugins/Wox.Plugin.Bookmarks
rmdir release
