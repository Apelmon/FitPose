public sealed class GameStateFeature : Feature {
    public GameStateFeature(Contexts contexts) {
        Add(new ChangeToLoadingStateSystem(contexts));
        Add(new ChangeToWaitInputStateSystem(contexts));
        Add(new ChangeToGameplayStateSystem(contexts));
        Add(new ChangeToFinishCutSceneStateSystem(contexts));
        Add(new ChangeToWinStateSystem(contexts));
        Add(new ChangeToLoseStateSystem(contexts));
        Add(new ChangeToPrepareToLoseStateSystem(contexts));
//        Add(new LoadSceneSystem(contexts));
    }
}