public sealed class TimersFeature : Feature {
    public TimersFeature(Contexts contexts) {
        Add(new MarkExplosionDestroyedSystem(contexts));
        Add(new PrepareToGameplayTimerSystem(contexts));
        Add(new PrepareToLoseTimerSystem(contexts));
        Add(new FinishCutSceneTimerSystem(contexts));
    }
}