public class NextLevelBtnConfig : BaseButtonConfig
{
    protected override void ButtonHandler() {
        var gameState = Contexts.sharedInstance.gameState;
        var nextLevel = gameState.currentLevel.value + 1;

        gameState.ReplaceCurrentLevel(nextLevel);
//        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, Application.version, nextLevel.ToString("00000"));

        Prefs.SetIntPrefs(Prefs.LEVEL, gameState.currentLevel.value);
        
        gameState.SwitchToState(GameStateExtensions.WAIT_INPUT);
    }
}
