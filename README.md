# Project Title

One Paragraph of project description goes here

### Installing

In order to get the app properly built for testing, you should first refer to [the Unity documentation for building on iOS](https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-ios-device-testing?playlist=17138).

Some key things to note:
1) You want to make sure you do the Edit > Project Settings > Player instruction of changing the bundle name; otherwise, your app will not be allowed to install.
2) You want to make sure you have your Apple ID set up and trusted on your device.

## Running the tests

Once you go through the initial installing instructions, these are the steps you will use regularly:
1) Build from Unity. Make sure all compiler errors are fixed, and that your desired scenes are checked off in the pop up window.
2) This should automatically open up the Finder window with your build. Open the XCode project.
3) Under Identity on the XCode project details, make sure your Developer ID is selected. You must do this otherwise it will not build.
4) Make sure your device is selected instead of "Generic iOS Device"
5) Hit PLAY

Tips: Make sure to manually delete the app once in a while to clear the cache. You might need to have your device connected to Wi-Fi in order to successfully launch the app (it needs connection to verify your app which is under your Apple Developer ID). This may only be a problem if you're using a device that doesn't have data.