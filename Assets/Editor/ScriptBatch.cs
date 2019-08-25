using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using Debug = UnityEngine.Debug;

public class ScriptBatch {
    [MenuItem("Tools/iOS Build With Postprocess")]
    public static void BuildToiOS() {
        string pathToVersion = "version.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(pathToVersion);
        string fileText = reader.ReadToEnd();
        reader.Close();

        PlayerSettings.bundleVersion = fileText;

        // Get filename.
        string path = "./Build/iOS/ColorBallsShooter";
        string[] levels = new string[] {
            "Assets/Scenes/Launcher.unity",
            "Assets/Scenes/Levels/Level01.unity",
            "Assets/Scenes/Levels/Level02.unity",
            "Assets/Scenes/Levels/Level03.unity",
            "Assets/Scenes/Levels/Level04.unity",
            "Assets/Scenes/Levels/Level05.unity",
            "Assets/Scenes/Levels/Level06.unity",
            "Assets/Scenes/Levels/Level07.unity",
            "Assets/Scenes/Levels/Level08.unity",
            "Assets/Scenes/Levels/Level09.unity",
            "Assets/Scenes/Levels/Level10.unity"
        };


        // Build player.
        BuildPipeline.BuildPlayer(levels, path, BuildTarget.iOS, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
//        FileUtil.CopyFileOrDirectory("Assets/Templates/Readme.txt", path + "Readme.txt");
    }

    [MenuItem("Tools/Print build number")]
    public static void PrintBuildNumber() {
        string pathToVersion = "version.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(pathToVersion);
        string fileText = reader.ReadToEnd();
        Debug.Log(pathToVersion + " " + fileText);
        reader.Close();

//        PlayerSettings.bundleVersion = fileText;

        Debug.Log("Build version -> " + PlayerSettings.bundleVersion);
        Debug.Log("Build number -> " + PlayerSettings.iOS.buildNumber);
    }
}