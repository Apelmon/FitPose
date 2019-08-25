public sealed class TimerSystems : Feature {
    public TimerSystems(Contexts contexts) {
        Add(new DecreaseTimerSystem(contexts));
        Add(new MarkTimerAsCompletedSystem(contexts));
        Add(new TimerCleanupSystems(contexts));
    }
}