using Entitas;

public sealed class InitGameStatesSystem : IInitializeSystem {
    readonly Contexts _contexts;
    
    public InitGameStatesSystem(Contexts contexts) {
        _contexts = contexts;
    }

    public void Initialize() {
        _contexts.game.ReplacePoseValue(0);
        
        
        var levelNum = (Prefs.HasPrefs(Prefs.LEVEL)) ? Prefs.GetIntPrefs(Prefs.LEVEL) : 1;
        _contexts.gameState.SetCurrentLevel(levelNum);
        
//        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, Application.version, levelNum.ToString("00000"));
        
        var score = (Prefs.HasPrefs(Prefs.SCORE)) ? Prefs.GetIntPrefs(Prefs.SCORE) : 0;
        _contexts.gameState.SetScore(score);
        
        var bestScore = (Prefs.HasPrefs(Prefs.BEST_SCORE)) ? Prefs.GetIntPrefs(Prefs.BEST_SCORE) : 0;
        _contexts.gameState.SetBestScore(bestScore);
        
        var coins = (Prefs.HasPrefs(Prefs.COINS)) ? Prefs.GetIntPrefs(Prefs.COINS) : 0;
        _contexts.gameState.SetCoins(coins);
    }
}