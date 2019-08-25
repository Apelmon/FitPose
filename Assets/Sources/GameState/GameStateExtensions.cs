public static class GameStateExtensions {
    public const int LOADING = 0;
    public const int INITIALIZATION = 1;
    public const int WAIT_INPUT = 2;
    public const int PREPARE_TO_GAMEPLAY = 3;
    public const int GAMEPLAY = 4;
    public const int FINISH_CUT_SCENE = 5;
    public const int WIN = 6;
    public const int LOSE = 7;
    public const int PREPARE_TO_LOSE = 8;
    
    public static void SwitchToState(this GameStateContext context, int stateId) {
        context.ResetAllStates();
        
        switch (stateId) {
            case LOADING:
                context.isLoadingState = true;
                break;
            case INITIALIZATION:
                context.isInitialization = true;
                break;
            case WAIT_INPUT:
                context.isWaitInputState = true;
                break;
            case PREPARE_TO_GAMEPLAY:
                context.isPrepareToGameplayState = true;
                break;
            case GAMEPLAY:
                context.isGameplayState = true;
                break;
            case FINISH_CUT_SCENE:
                context.isFinishCutSceneState = true;
                break;
            case WIN:
                context.isWinState = true;
                break;
            case LOSE:
                context.isLoseState = true;
                break;
            case PREPARE_TO_LOSE:
                context.isPrepareToLose = true;
                break;
        }
    }

    public static void ResetAllStates(this GameStateContext context) {
        context.isLoadingState = false;
        context.isInitialization = false;
        context.isWaitInputState = false;
        context.isPrepareToGameplayState = false;
        context.isGameplayState = false;
        context.isFinishCutSceneState = false;
        context.isWinState = false;
        context.isLoseState = false;
        context.isPrepareToLose = false;
    }
}