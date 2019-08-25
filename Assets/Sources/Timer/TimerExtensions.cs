public static class TimerExtensions {
    // timer entity example
    public static TimerEntity CreateFailedPopupAdsTimer(this Contexts contexts) {
        var e = TimerEntity(contexts.timer, contexts.config.gameConfig.value.failedPopupAdsDelay);
        e.isFailedPopupAdsEvent = true;
        
     
        return e;
    }
    // timer entity example
    public static TimerEntity PrepareToGameplayTimer(this TimerContext context, float time) {
        var e = TimerEntity(context, time);
        e.isPrepareToGameplayEvent = true;
        
        return e;
    }
    
    public static TimerEntity PrepareToLoseTimer(this TimerContext context, float time) {
        var e = TimerEntity(context, time);
        e.isPrepareToLoseEvent = true;
        
        return e;
    }
    
    public static TimerEntity FinishCutSceneTimer(this TimerContext context, float time) {
        var e = TimerEntity(context, time);
        e.isFinishCutSceneEvent = true;
        
        return e;
    }

    public static TimerEntity ExplosionTimer(this Contexts contexts, int id, float time) {
        var e = contexts.timer.CreateEntity();
        e.AddTimer(time);
        e.AddExplosionTimer(id);
        
        return e;
    }

    private static TimerEntity TimerEntity(TimerContext context, float time) {
        var e = context.CreateEntity();
        e.AddTimer(time);
        return e;
    }
}