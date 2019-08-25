using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtnConfig : BaseButtonConfig
{
    protected override void ButtonHandler() {
//        Debug.Log("Invoke from " + GetType());
        // todo create restart entity here + add tests for check it
        
//        var gameState = Contexts.sharedInstance.gameState;
        
//        gameState.ReplaceCurrentLevel(gameState.currentLevel.value);
        
//        gameState.SwitchToState(GameStateExtensions.LOADING);
        Prefs.SetIntPrefs(Prefs.SCORE, 0);
        Prefs.SetIntPrefs(Prefs.BEST_SCORE, Contexts.sharedInstance.gameState.bestScore.value);

        SceneManager.LoadScene("Game");
    }
}
