using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Net;

public class CompileQuestSaberWindow : EditorWindow
{
    private BMBFmod.jsonreference[] questsabers;
    private string extension = "qsaber";//, internalname = "_CustomSaber";

    [MenuItem("Tools/QuestSaber Exporter")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CompileQuestSaberWindow),false , "QuestSaber Exporter");
    }

    void OnGUI()
    {
        if(GUILayout.Button("Check For Updated GUI"))
        {
            string savepath = Application.dataPath + "/downloadedCompileQuestSaberWindow.txt";
            GetText("CompileQuestSaberWindow.cs", savepath);

            File.Delete(Application.dataPath + "/Editor/CompileQuestSaberWindow.cs");
            File.Move(Application.dataPath + "/downloadedCompileQuestSaberWindow.txt", Application.dataPath + "/Editor/CompileQuestSaberWindow.cs");
            AssetDatabase.Refresh();
        }

        GUILayout.Label("QuestSabers", EditorStyles.boldLabel);

		GUILayout.Space(20);
        
        foreach (BMBFmod.jsonreference saber in questsabers)
        {
			GUILayout.Label ("GameObject : " + saber.gameObject.name, EditorStyles.boldLabel);
            //saber.AuthorName = EditorGUILayout.TextField("Author name", saber.AuthorName);
            //saber.SaberName = EditorGUILayout.TextField("Saber name", saber.SaberName);
            //saber.bmbfmod.components.Clear();
            if (saber.bmbfmod.components[0] == null)
            {
                saber.bmbfmod.components.Add(new BMBFmod.Component());
            }
            saber.bmbfmod.components[0].type = "FileCopyMod";
            saber.bmbfmod.components[0].targetRootedPathAndFileName = "/sdcard/Android/data/com.beatgames.beatsaber/files/sabers/testSaber." + extension;
            saber.bmbfmod.coverImageFilename = EditorGUILayout.TextField("Cover image name", saber.bmbfmod.coverImageFilename);
            saber.bmbfmod.icon = EditorGUILayout.TextField("Icon name", saber.bmbfmod.icon); 
            saber.bmbfmod.version = EditorGUILayout.TextField("Saber version", saber.bmbfmod.version); 
            saber.bmbfmod.links.pageLink = EditorGUILayout.TextField("Page link", saber.bmbfmod.links.pageLink);
            //saber.bmbfmod.description.Add(EditorGUILayout.TextField("Description", saber.bmbfmod.description[0]));

            if (saber.bmbfmod.description[0] == null)
            {
                saber.bmbfmod.description.Add("");
            }

            saber.bmbfmod.description[0] = EditorGUILayout.TextField("Description", saber.bmbfmod.description[0]);
            saber.bmbfmod.gameVersion = EditorGUILayout.TextField("Game version", saber.bmbfmod.gameVersion);
            saber.bmbfmod.platform = "Quest";
            saber.bmbfmod.name = EditorGUILayout.TextField("Saber name", saber.bmbfmod.name); ;
            saber.bmbfmod.author = EditorGUILayout.TextField("Author name", saber.bmbfmod.author);
            saber.bmbfmod.category = "Saber";

            saber.bmbfmod.components[0].sourceFileName = saber.bmbfmod.name + "." + extension;
            string modID = saber.bmbfmod.name + saber.bmbfmod.author + "V" + saber.bmbfmod.version;
            modID = modID.Replace(" ", string.Empty);
            saber.bmbfmod.id = modID;
            
            EditorGUI.BeginDisabledGroup (saber.transform.Find("LeftSaber") == null || saber.transform.Find("RightSaber") == null);
            if(GUILayout.Button("Export " + saber.bmbfmod.name + "." + extension))
            {
                //string objectName = saber.gameObject.name;
                //saber.gameObject.name = internalname;
                if (EditorUserBuildSettings.activeBuildTarget.ToString() == "Android")
                {
                    GameObject saberObject = saber.gameObject;
                    if (saberObject != null && saber != null)
                    {

                        string path = EditorUtility.SaveFilePanel("Save qsaber file", "", saber.bmbfmod.name + "." + extension, extension);
                        //Debug.Log(path == "");

                        if (path != "")
                        {
                            

                            string fileName = Path.GetFileName(path);
                            string folderPath = Path.GetDirectoryName(path);
                            if (File.Exists(path)) File.Delete(path);
                            if (!Directory.Exists(Application.temporaryCachePath + "/QuestSaber")) Directory.CreateDirectory(Application.temporaryCachePath + "/QuestSaber");
                            Selection.activeObject = saberObject;
                            EditorUtility.SetDirty(saber);
                            EditorSceneManager.MarkSceneDirty(saberObject.scene);
                            EditorSceneManager.SaveScene(saberObject.scene);
                            //PrefabUtility.CreatePrefab ("Assets/_CustomSaber.prefab", Selection.activeObject as GameObject);
                            PrefabUtility.SaveAsPrefabAsset(Selection.activeObject as GameObject, "Assets/_CustomSaber.prefab");
                            AssetBundleBuild assetBundleBuild = default(AssetBundleBuild);
                            assetBundleBuild.assetNames = new string[] {
                            "Assets/_CustomSaber.prefab"
                        };

                            assetBundleBuild.assetBundleName = fileName;

                            BuildTargetGroup selectedBuildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
                            BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;

                            BuildPipeline.BuildAssetBundles(Application.temporaryCachePath + "/QuestSaber", new AssetBundleBuild[] { assetBundleBuild }, 0, EditorUserBuildSettings.activeBuildTarget);
                            EditorPrefs.SetString("currentBuildingAssetBundlePath", folderPath);
                            EditorUserBuildSettings.SwitchActiveBuildTarget(selectedBuildTargetGroup, activeBuildTarget);
                            AssetDatabase.DeleteAsset("Assets/_CustomSaber.prefab");
                            File.Move(Application.temporaryCachePath + "/QuestSaber" + "/" + fileName, path);
                            AssetDatabase.Refresh();
                            clearTemp();
                            EditorUtility.DisplayDialog("Exportation Successful!", "Exportation Successful!", "OK");
                            EditorUtility.RevealInFinder(path);



                        }
                        else
                        {
                            EditorUtility.DisplayDialog("Exportation Failed!", "Path is invalid.", "OK");
                        }
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Exportation Failed!", "Saber GameObject is missing.", "OK");
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog("Exportation Failed!", "Your projects build target is not Android.", "OK");
                }
                //saber.gameObject.name = objectName;
            }
			EditorGUI.EndDisabledGroup ();

			if (saber.transform.Find("LeftSaber") == null) {
				GUILayout.Label ("LeftSaber gameObject is missing", EditorStyles.boldLabel);
			}
			if (saber.transform.Find("RightSaber") == null) {
				GUILayout.Label ("RightSaber gameObject is missing", EditorStyles.boldLabel);
			}
			if (GetObjectBounds (saber.gameObject).extents.z * 2.0 > 2.0) {
				GUILayout.Label ("The saber might be too long", EditorStyles.boldLabel);
			}
			if (GetObjectBounds (saber.gameObject).extents.x * 2.0 > 1.0) {
				GUILayout.Label ("The saber might be too large", EditorStyles.boldLabel);
			}

            GUILayout.Space(5);
            if (GUILayout.Button("Export bmbfmod.json for " + saber.bmbfmod.name + "." + extension))
            {
                string json = JsonUtility.ToJson(saber.bmbfmod, true);
                //Debug.Log(json == "{}");

                if (json != "{}")
                {
                    string path = EditorUtility.SaveFilePanel("Save bmbfmod.json", "", "bmbfmod.json", ".json");
                    //Debug.Log(path == "");

                    if (path != "")
                    {
                        string folderPath = Path.GetDirectoryName(path);

                        File.WriteAllText(path, json);

                        EditorUtility.DisplayDialog("Exportation Successful!", "JSON exportation Successful!", "OK");
                        EditorUtility.RevealInFinder(path);
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Exportation Failed!", "Path is invalid.", "OK");
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog("Exportation Failed!", "Json is invalid", "OK");
                }
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Create bmbf mod zip for " + saber.bmbfmod.name + "." + extension))
            {
                //string objectName = saber.gameObject.name;
                //saber.gameObject.name = internalname;
                if (EditorUserBuildSettings.activeBuildTarget.ToString() == "Android")
                {
                    GameObject saberObject = saber.gameObject;
                    if (saberObject != null && saber != null)
                    {
                        string zipname = saber.bmbfmod.name + "V" + saber.bmbfmod.version + ".zip";
                        zipname = zipname.Replace(" ", string.Empty);
                        string path = EditorUtility.SaveFilePanel("Save " + "." + extension + " zip", "", zipname, "zip");
                        //Debug.Log(path == "");
                        string json = JsonUtility.ToJson(saber.bmbfmod, true);

                        if (path != "" && json != "{}")
                        {
                            

                            zipname = Path.GetFileName(path);
                            string fileName = saber.bmbfmod.name + "." + extension;
                            string folderPath = Path.GetDirectoryName(path);
                            if (File.Exists(path)) File.Delete(path);
                            if (!Directory.Exists(Application.temporaryCachePath + "/QuestSaber")) Directory.CreateDirectory(Application.temporaryCachePath + "/QuestSaber");
                            Selection.activeObject = saberObject;
                            EditorUtility.SetDirty(saber);
                            EditorSceneManager.MarkSceneDirty(saberObject.scene);
                            EditorSceneManager.SaveScene(saberObject.scene);
                            //PrefabUtility.CreatePrefab ("Assets/_CustomSaber.prefab", Selection.activeObject as GameObject);
                            PrefabUtility.SaveAsPrefabAsset(Selection.activeObject as GameObject, "Assets/_CustomSaber.prefab");
                            AssetBundleBuild assetBundleBuild = default(AssetBundleBuild);
                            assetBundleBuild.assetNames = new string[] {
                            "Assets/_CustomSaber.prefab"
                        };

                            assetBundleBuild.assetBundleName = fileName;

                            BuildTargetGroup selectedBuildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
                            BuildTarget activeBuildTarget = EditorUserBuildSettings.activeBuildTarget;

                            BuildPipeline.BuildAssetBundles(Application.temporaryCachePath + "/QuestSaber/", new AssetBundleBuild[] { assetBundleBuild }, 0, EditorUserBuildSettings.activeBuildTarget);
                            EditorPrefs.SetString("currentBuildingAssetBundlePath", folderPath);
                            EditorUserBuildSettings.SwitchActiveBuildTarget(selectedBuildTargetGroup, activeBuildTarget);
                            AssetDatabase.DeleteAsset("Assets/_CustomSaber.prefab");

                            File.WriteAllText(Application.temporaryCachePath + "/QuestSaber/bmbfmod.json", json);

                            int w = 1024, h = 512;

                            bool rightwasactive = saberObject.transform.Find("RightSaber").gameObject.activeSelf;
                            bool leftwasactive = saberObject.transform.Find("LeftSaber").gameObject.activeSelf;

                            saberObject.transform.Find("RightSaber").gameObject.SetActive(false);
                            saberObject.transform.Find("LeftSaber").gameObject.SetActive(true);

                            Camera cam = GameObject.CreatePrimitive(PrimitiveType.Quad).AddComponent<Camera>();
                            cam.transform.localPosition = new Vector3(0.36f, 0.22f, -0.05f);
                            cam.transform.localEulerAngles = new Vector3(30f, -60f, 0.0f);
                            cam.backgroundColor = new Color(0.0f, 0.0f, 25.0f / 256.0f);

                            RenderTexture tempRT = new RenderTexture(w, h, 24);
                            tempRT.antiAliasing = 8;

                            cam.targetTexture = tempRT;
                            cam.Render();

                            RenderTexture.active = tempRT;

                            Texture2D saberImage = new Texture2D(w, h, TextureFormat.RGB24, false);

                            saberImage.ReadPixels(new Rect(0, 0, w, h), 0, 0);

                            RenderTexture.active = null;

                            byte[] bytes;
                            bytes = saberImage.EncodeToPNG();

                            File.WriteAllBytes(Application.temporaryCachePath + "/QuestSaber/" + saber.bmbfmod.coverImageFilename, bytes);

                            saberObject.transform.Find("RightSaber").gameObject.SetActive(rightwasactive);
                            saberObject.transform.Find("LeftSaber").gameObject.SetActive(leftwasactive);

                            DestroyImmediate(cam.gameObject);
                            DestroyImmediate(tempRT);

                            DirectoryInfo directoryToZip = Directory.CreateDirectory(Application.temporaryCachePath + "/QuestSaber" + "/tempzip");

                            File.Move(Application.temporaryCachePath + "/QuestSaber/" + saber.bmbfmod.name + "." + extension, Application.temporaryCachePath + "/QuestSaber/tempzip/" + saber.bmbfmod.name + "." + extension);
                            File.Move(Application.temporaryCachePath + "/QuestSaber/bmbfmod.json", Application.temporaryCachePath + "/QuestSaber/tempzip/bmbfmod.json");
                            File.Move(Application.temporaryCachePath + "/QuestSaber/" + saber.bmbfmod.coverImageFilename, Application.temporaryCachePath + "/QuestSaber/tempzip/" + saber.bmbfmod.coverImageFilename);

                            ZipFile.CreateFromDirectory(Application.temporaryCachePath + "/QuestSaber/tempzip", path);

                            clearTemp();

                            AssetDatabase.Refresh();
                            EditorUtility.DisplayDialog("Exportation Successful!", "bmbf mod zip exported successfully!", "OK");

                            EditorUtility.RevealInFinder(path);

                            
                        }
                        else
                        {
                            if (path == "" && json == "{}") EditorUtility.DisplayDialog("Exportation Failed!", "Path and Json are invalid.", "OK");
                            else if (path != "" && json == "{}") EditorUtility.DisplayDialog("Exportation Failed!", "Path is valid, Json is invalid.", "OK");
                            else if (path == "" && json != "{}") EditorUtility.DisplayDialog("Exportation Failed!", "Path is invalid, Json is valid.", "OK");
                        }
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Exportation Failed!", "Saber GameObject is missing.", "OK");
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog("Exportation Failed!", "Your projects build target is not Android.", "OK");
                }
                //saber.gameObject.name = objectName;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Create Saber Image of " + saber.bmbfmod.name + "." + extension))
            {
                string path = EditorUtility.SaveFilePanel("Save " + saber.bmbfmod.name + " Image png", "", "cover.png", "png");

                if (path != "")
                {
                    int w = 1024, h = 512;

                    GameObject saberObject = saber.gameObject;
                    bool rightwasactive = saberObject.transform.Find("RightSaber").gameObject.activeSelf;
                    bool leftwasactive = saberObject.transform.Find("LeftSaber").gameObject.activeSelf;

                    saberObject.transform.Find("RightSaber").gameObject.SetActive(false);
                    saberObject.transform.Find("LeftSaber").gameObject.SetActive(true);

                    Camera cam = GameObject.CreatePrimitive(PrimitiveType.Quad).AddComponent<Camera>();
                    cam.transform.localPosition = new Vector3(0.36f, 0.22f, -0.05f);
                    cam.transform.localEulerAngles = new Vector3(30f, -60f, 0.0f);
                    cam.backgroundColor = new Color(0.0f, 0.0f, 25.0f / 256.0f);

                    RenderTexture tempRT = new RenderTexture(w, h, 24);
                    tempRT.antiAliasing = 8;

                    cam.targetTexture = tempRT;
                    cam.Render();

                    RenderTexture.active = tempRT;

                    Texture2D saberImage = new Texture2D(w, h, TextureFormat.RGB24, false);

                    saberImage.ReadPixels(new Rect(0, 0, w, h), 0, 0);

                    RenderTexture.active = null;

                    byte[] bytes;
                    bytes = saberImage.EncodeToPNG();

                    File.WriteAllBytes(path, bytes);

                    saberObject.transform.Find("RightSaber").gameObject.SetActive(rightwasactive);
                    saberObject.transform.Find("LeftSaber").gameObject.SetActive(leftwasactive);

                    
                    DestroyImmediate(cam.gameObject);
                    DestroyImmediate(tempRT);

                    EditorUtility.DisplayDialog("Exportation Successful!", "Image saved successfully", "OK");
                    EditorUtility.RevealInFinder(path);
                }
                else
                {
                    EditorUtility.DisplayDialog("Exportation Failed!", "Path is invalid.", "OK");
                }
            }
            GUILayout.Space(20);
        }
    }
    private void clearTemp()
    {
        DirectoryInfo di = new DirectoryInfo(Application.temporaryCachePath + "/QuestSaber");

        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in di.GetDirectories())
        {
            dir.Delete(true);
        }

        Directory.Delete(Application.temporaryCachePath + "/QuestSaber");
    }

    private void OnFocus()
    {
		questsabers = GameObject.FindObjectsOfType<BMBFmod.jsonreference>();
    }

    private Bounds GetObjectBounds(GameObject g){
		var b = new Bounds (g.transform.position, Vector3.zero);
		foreach (Renderer r in g.GetComponentsInChildren<Renderer>()) {
			b.Encapsulate (r.bounds);
		}
		return b;
	}
    void GetText(string file_name, string savePath)
    {
        string url = @"https://raw.githubusercontent.com/RedBrumbler/BMBFCustomSabers/master/Guidefiles/QuestSaber/" + file_name;

        WebClient client = new WebClient();

        Stream data = client.OpenRead(url);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        File.WriteAllText(savePath, s);
        data.Close();
        reader.Close();
    }

}