using UnityEngine;

public class Prefs {
    public static string GAME_ID = "_";
    public static string LEVEL = "level";
    public static string COINS = "coins";
    public static string SCORE = "score";
    public static string BEST_SCORE = "best_score";

    public static bool HasPrefs(string name) {
        return PlayerPrefs.HasKey(GAME_ID + name);
    }
    
    public static int GetIntPrefs(string name) {
        return PlayerPrefs.GetInt(GAME_ID + name);
    }

    public static void SetIntPrefs(string name, int value) {
        PlayerPrefs.SetInt(GAME_ID + name, value);
    }
}