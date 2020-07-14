<!---**These guides are RedBrumbler's guides**--->

# THIS GUIDE IS EXTREMELY OUTDATED, GO TO THE [WIKI](https://github.com/RedBrumbler/BMBFCustomSabers/wiki/RedBrumblers-Asset-Mod-Guide-Wiki) FOR UPDATED GUIDES

### @RedBrumbler#6295 ‘s (or u/RedBrumbler) Guide to making custom beat saber logo's for the BMBF Asset replacement mod

**CoEdited by Yuuki#0802**

[Click here to go back to the main guide](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/README.md)

# Useful Links

- [BMBF](nothing here yet)
- [Sidequest Discord](https://discord.me/sidequestvr)
- [Beat Saber Modding Group Discord (BSMG)](https://discord.gg/beatsabermods)
- [Custom Sabers](https://github.com/RedBrumbler/BMBFCustomSabers/tree/master/Sabers)
- [Custom Blocks/Notes](https://github.com/RedBrumbler/BMBFCustomSabers/tree/master/NoteCubes)
- [Other Asset Mods](https://github.com/RedBrumbler/BMBFCustomSabers/tree/master/MiscAssetMods)

# Required Programs and Files for Making a Saber:

- Image editing program of your choice (I prefer Photoshop, and will be using that in this Guide)
- UnityAssetBundleExtractor [(UABE)](https://mega.nz/#!ScgiWYRJ!5b_9g2B4eOZaAA3JAV2htVRamNYuxQLrWyMbSXv-k1o)
  *NOT my program, be careful when downloading programs from the internet!* Source: [here](https://7daystodie.com/forums/showthread.php?22675-Unity-Assets-Bundle-Extractor)
- The [GuideFiles BeatSaberLogo.zip](https://github.com/RedBrumbler/BMBFCustomSabers/raw/master/Guidefiles/GuideFiles%20BeatSaberLogo/GuideFiles%20BeatSaberLogo.zip) Contains a LogoE.dat, SaberLogo.assets and a configured BMBFmod.json
- A font of your choice, The font beat saber uses is [Neon Tubes](https://medialoot.com/item/neon-tubes-font/) but since youhave to pay for it you can also use [the Beon font](https://www.1001fonts.com/beon-font.html) which is free.

# Get your logo Image
This part of the guide will get you through making this Logo with Photoshop, for your own modeling program you'll have to find the equivalent steps yourself

To start, you'll have to create a new file, Make it 1024 pixels wide and 256 pixels tall

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/new%201024x256.PNG)

You'll then have to select the Text tool, choose your font, pick a text size (170 works great for me) and choose the color you want the text to be

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/text%2C%20font%2C%20size%20color.PNG)

Type whatever you want the text to be, and rasterize the type (that makes centering the text easier)

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/type%20whatever%2C%20right%20click%2C%20rasterize.PNG)

Center the text onto the middle of your canvas:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Drag%20and%20center.PNG)

Now we need to add a slight glow effect to make the text blend better in beat saber, go to Layer, Layer Style and add a stroke:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Layer%2C%20layerStyle%2C%20stroke.PNG)

These are the settings I use for the glow effect around my text:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/preferred%20settings.PNG)

Do not forget to turn the background off! we need a transparent background

![Image](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Don't%20forget%20background!.PNG)

Now that we have configured the layer style for one of the layers, we can just copy it over to the other one:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/copy%20layer%20style.PNG)

And Paste:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Paste%20layer%20style.PNG)

Now we need to edit the color of the glow, Choose the right color for your second piece of text and just select this again in the stroke menu:

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Reset%20the%20color%20for%20the%20glow.PNG)

Now we save the top text as LogoBat.png:

![Image](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/save%20top%20as%20LogoBat.PNG)

And we save the Bottom text as LogoSaber.png:

![Image](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Save%20bottom%20as%20LogoSaber.PNG)

Now you need to open SaberLogo.assets with UABE (File -> open):

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/open%20saberlogo%20with%20UABE.PNG)

Now to navigate through the menu's, click LogoBat, Go to plugins, click edit and then ok, click load, and then load in LogoBat.png

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Logobat%2C%20plugins%2C%20edit%2C%20load%2C%20Logobat.PNG)

After this you'll have to Click ok and select fast perceptual **Do not select slow, it's very slow**

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Ok%2C%20fast%20perceptual.PNG)

Now do the same for LogoSaber, but of course click LogoSaber in UABE and load in the LogoSaber.png

After having done both, you'll have to hit ok and save the changes

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Ok%2C%20save%20changes.PNG)

And save the new .assets file as something recognizable, SaberLogo2.assets for example

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Save%20recxognizable%2C%20saberlogo2.PNG)

Now Open up SaberLogo2.assets the same way you opened SaberLogo.assets

Once looking at the assets within SaberLogo2.assets, you'll want to Export them as raw, and save LogoBat as LogoBat.dat and save LogoSaber as LogoSaber.dat

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Export%20Raw%2C%20save%20as.PNG)

Now that you have your raw .dat files, you'll only need to add the LogoE.dat (required!) and BMBFmod.json

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/add%20BMBFmod%20and%20LogoE.PNG)

You'll have to add your own info to the bottom of the BMBFmod.json, this is how it should look when you download it:

```
"version": "1.0.0",
  "links": {},
  "description": [
    "Mod Description"
  ],
  "gameVersion": "1.1.0",
  "platform": "Quest",
  "id": "ModID",
  "name": "Mod name",
  "author": "Yourname",
  "category": "Other"
}
```

This is how I configured mine:

```
 "version": "1.0.0", --Mod version
  "links": {}, --Links to social media and whatnot
  "description": [
    "Changes the Beat Saber Logo in the menu to say Fuckin' Yeezies" --Mod description
  ],
  "gameVersion": "1.1.0",
  "platform": "Quest", 
  "id": "Fuckin'YeezysBSLogoV1",--Unique mod ID
  "name": "Fuckin'Yeezys Beat Saber Logo V1", --Mod name that is displayed in BMBF
  "author": "RedBrumbler", --Author name
  "category": "Other" --Mod category, leave on other for now
```

Now that you have everything you need you just need to zip it up!

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Zip%20it%20up.PNG)

You might want to also add a Cover.png to show what it looks like when in the mod list, good thing you just zipped it up! 

![Image](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Upload!.PNG)

1. To start, upload your mod to BMBF
2. Start Beat Saber (not through BMBF as this will cause the Quest's screencapture capabilities to not work)
3. Head to the menu
4. Go back to the Quest home screen and click "Sharing" at the bottom
5. Click record or capture image
6. **If you want to capture image:** Just look straight at the title
7. **If you want to record:** Just go look at the title and stop recording
8. Plug your Quest up to your PC
9. Open SideQuest
10. Go to the "Files" tab
11. Head to the Oculus -> Screenshots folder
12. Export to your title's folder
13. If you recorded a video, export the video to a location on your pc, open the video and find a good spot to take a screen shot. Save the screenshot in your title's folder

Here is what mine looked like (I noticed a spelling error in Yeezys so I Fixed that during the making of this guide, that's why there's a difference in text between my photoshop images and here)

![Image!](https://github.com/RedBrumbler/BMBFCustomSabers/blob/master/Guidefiles/GuideFiles%20BeatSaberLogo/Fuckin'Yeezys.jpg)

If the title becomes an entirely white image you forgot to turn off the background in photoshop

# Add Your Menu Titles to the Repo

I also support adding your sabers to the repository here!
(explanation adapted from @Yuuki#0802 from BSMG, and by that I mean mostly blatantly copied)

1. Make a Github account if you haven't already
2. Click the "fork" button in the top right of this repository
3. Download [github desktop](https://desktop.github.com/)
4. Go to your forked repo (so, yourname/BMBFCustomSabers) and click "Clone or Download", Copy that link
5. Go to Github Desktop: File -> Clone repository -> URL and paste the link, then click clone (keep note of the local path you put the repo in)
6. Head to where you saved the repo in your file explorer (C:\User\GitHub\BMBFCustomSabers)
7. Go to the "BeatSaberLogos" folder.
8. Create a new folder for your sabers (ex. "LaBandit915's BeatSaberLogos")
9. Drag your zip file in this folder
10. Head back to Github desktop
11. Add a summary for your commit at the bottom left (ex. "Added {LogoName} by LaBandit915")
12. Press commit
13. Press push
14. Go back to your forked repo and press "Create pull request" and submit!

***Once I or Yuuki accepts your pull request your BeatSaberLogo will be added here***

**Please test your mods before submitting. Make sure they have correct JSON formatting and appear correctly on the BMBF mod screen.**

<!---**These guides are RedBrumbler's guides**--->
