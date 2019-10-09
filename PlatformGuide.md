<!---**These guides are RedBrumbler's guides**--->

# Guide to Making Custom Platforms for BMBF

### @RedBrumbler#6295 ‘s (or u/RedBrumbler) Guide to making custom platforms for the BMBF Asset replacement mod

**CoEdited by Yuuki#0802**

#### These platforms are not the custom stages! this is just the platform you are standing on when playing! keep that in mind

[Click here to go back to the main guide](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/README.md)

# Useful Links

- [BMBF](nothing here yet)
- [Sidequest Discord](https://discord.me/sidequestvr)
- [Beat Saber Modding Group Discord (BSMG)](https://discord.gg/beatsabermods)
- [Fusion360](https://www.autodesk.com/products/fusion-360/students-teachers-educators)
- [Blender](https://www.blender.org/)
- [Custom Sabers](https://github.com/RedBrumbler/BMBFCustomSabers/tree/master/Sabers)
- [Custom Blocks/Notes](https://github.com/RedBrumbler/BMBFCustomSabers/tree/master/NoteCubes)
- [Other Asset Mods](https://github.com/RedBrumbler/BMBFCustomSabers/tree/master/MiscAssetMods)

# Required Programs and Files for Making a Platform:

- Unity version [2018.3.10f1](https://unity3d.com/get-unity/download?thank-you=update&download_nid=61246&os=Win)(any lower or higher and BeatSaber will crash)
- This [unity project](https://bs.assistant.moe/Sabers/resources/CustomSaberUnityProject.zip). Source: [here](https://bs.assistant.moe/Sabers/)
- Model program of your choice (I prefer fusion360)
- UnityAssetBundleExtractor [(UABE)](https://mega.nz/#!ScgiWYRJ!5b_9g2B4eOZaAA3JAV2htVRamNYuxQLrWyMbSXv-k1o)
  *NOT my program, be careful when downloading programs from the internet!* Source: [here](https://7daystodie.com/forums/showthread.php?22675-Unity-Assets-Bundle-Extractor)
- The [Guide Files Platform.zip](https://github.com/RedBrumbler/BMBFCustomSabers/raw/master/Guidefiles/GuideFiles%20Platform/Guide%20files%20Platform.zip) Contains an .stl PlatformTemplate, .obj PlatformTemplate and a configured BMBFmod.json

# Get Your Platform Model

## Splitting pre-made models:

[![Separating Objects in Blender](https://img.youtube.com/vi/P_C3xkVT044/0.jpg)](https://youtu.be/P_C3xkVT044 "Separating Objects in Blender")

Making your own Model
------
Making your own model should be simple! just import the template I have provided in [Guide Files Platform.zip](https://github.com/RedBrumbler/BMBFCustomSabers/raw/master/Guidefiles/GuideFiles%20Platform/Guide%20files%20Platform.zip) and work around that!

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/Template.PNG)

You'll have to create a PlayersPlaceCore (the dark part of the platform) and a PlayersPlaceFrame (The glowing edge of the regular platform) I have created a Platform with my own name on it so I can show you what it looks like:

My PlayersPlaceCore:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/My%20core.PNG)

MyPlayersPlaceFrame:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/My%20frame.PNG)

Overlaid with the platform guide: (it's way too big but for the sake of this Guide I rolled with it)

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/My%20platformoverlaid.PNG)

Export your meshes as .obj, or if you are like me and use fusion360 or other program that can't export as .obj, you can use http://www.meshconvert.com/ to convert your meshes to .obj.

**Make sure to select .obj on meshconvert.com!**

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/Saveasobj.PNG)

Raw Unity Mesh Files
------
Now that you've got your models it's time to convert them into raw Unity mesh files. To start off, drag your PlayersPlaceCore.obj and PlayersPlaceFrame.obj into the unity assets window at the bottom:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/Drag%20in.PNG)

And drag the meshes from the assets into your scene:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/Dragin2.PNG)

Now you need to build the scene, press Ctrl + Shift + B and have windows mac Linux selected, and press build. Let it build in a for you recognizable folder (For me that is build in my CustomAssets folder)

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/do%20these.PNG)

Now you'll have to get the raw meshes out oif the sharedassets0.assets, you'll find sharedassets0.assets in the Data folder of your unity build, remember that location and open UABE.

Once in UABE go to file -> open and navigate to your sharedassets0.assets, open it and you'll see a bunch of assets in a list, we are looking for the 2 meshes we imported, for me they are these two:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/get%20dat.png)

I know that my PlayersPlaceFrame is the largest file of the two meshes, so I'm saving the large mesh as PlayersPlaceFrame.dat, and the smaller mesh as PlayersPlaceCore.dat

Now you should have the 2 mesh files in raw .dat format!

Getting the meshes into a mod
------

Now that you hopefully have your meshes in raw format, we can add them into a mod. If you haven't already get the configured BMBFmod.json from [Guide Files Platform.zip](https://github.com/RedBrumbler/BMBFCustomSabers/raw/master/Guidefiles/Guide%20files%20Saber.zip) And open it in a text editor (would not recommend regular notepad, something like notepad++ works way better)

This is what you should get when you first open the configured BMBFmod.json, I recommend to only change the id, name, author, description and version
```
"id": "ModID",
  "name": "Modname",
  "author": "yourname",
  "description": ["mod description"],
  "gameVersion": "1.1.0",
  "version": "1.0.0.0",
  "platform": "Quest",
  "category": "Other",
  "coverImageFilename": "Cover.png",
  "components":
```

For my platform I changed it to this:

```
"id": "RedBrumblerPlatformV1",
  "name": "RedBrumbler's platform V1", --Unique mod ID, this makes sure that when you release an update it won't install the mod again, but overwrite the old one
  "author": "RedBrumbler", --The name displayed within BMBF
  "description": ["A platform to rep RedBrumbler"], --Your name here, so people know who made that platform
  "gameVersion": "1.1.0",
  "version": "1.0.0.0", --Version of the mod, I reccommend to bump the last number up for small changes, but for larger redesigns use the second number
  "platform": "Quest",
  "category": "Other",
  "coverImageFilename": "Cover.png", --it's easier to just name the cover image to Cover.png than to keep editing this one IMO -Redbrumbler
  "components":
```

You may also use a cover image, be sure it's a png and name it Cover.png for simplicity's sake, best is to use an image from in the game of your platform, here's how to do it:

1. Start Beat Saber (not through BMBF as this will cause the Quest's screencapture capabilities to not work)
2. Head to the tutorial
3. Go back to the Quest home screen and click "Sharing" at the bottom
4. Click record or capture image
5. **If you want to capture image:** Look down at your platform and hold still for a bit
6. **If you want to record:** Also look down at your platform and try to look for the best angle!
7. Plug your Quest up to your PC
8. Open SideQuest
9. Go to the "Files" tab
10. Head to the Oculus -> Screenshots folder
11. Export to your platform's folder (Don't forget to convert to .png!)
12. If you recorded a video, export the video to a location on your pc, open the video and find a good spot to take a screen shot. Save the screenshot in your platform's folder

Now that you have your BMBFmod.json configured for use, you can put them in the same folder as your PlayersPlaceCore.dat and PlayersPlaceFrame.dat, and zip them up. Don't use a .rar file, it has to be zip!

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/zip%20them%2C%20not%20rar%20them.PNG)

This completed Platform can now be loaded into the game!

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/Upload.PNG)

Here is what mine looked like: (As I said, it's way too big, but this image shows how much too big it is :P)

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20Platform/in%20game.jpg)

# Add Your Platforms to the Repo

I also support adding your platform to the repository here!
(explanation adapted from @Yuuki#0802 from BSMG, and by that I mean mostly blatantly copied)

1. Make a Github account if you haven't already
2. Click the "fork" button in the top right of this repository
3. Download [github desktop](https://desktop.github.com/)
4. Go to your forked repo (so, yourname/BMBFCustomSabers) and click "Clone or Download", Copy that link
5. Go to Github Desktop: File -> Clone repository -> URL and paste the link, then click clone (keep note of the local path you put the repo in)
6. Head to where you saved the repo in your file explorer (C:\User\GitHub\BMBFCustomSabers)
7. Go to the "Platforms" folder.
8. Create a new folder for your sabers (ex. "LaBandit915's platforms")
9. Drag your zip file in this folder
10. Head back to Github desktop
11. Add a summary for your commit at the bottom left (ex. "Added {platformName} by LaBandit915")
12. Press commit
13. Press push
14. Go back to your forked repo and press "Create pull request" and submit!

***Once I or Yuuki accepts your pull request your platform will be added here!***

**Please test your mods before submitting. Make sure they have correct JSON formatting and appear correctly on the BMBF mod screen.**

<!---**These guides are RedBrumbler's guides**--->
