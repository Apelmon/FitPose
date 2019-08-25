using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PrepareToLoseTimerSystem : ReactiveSystem<TimerEntity> {

    private Contexts _contexts;

    public PrepareToLoseTimerSystem(Contexts contexts) : base(contexts.timer) {
        _contexts = contexts;
    }

    protected override ICollector<TimerEntity> GetTrigger(IContext<TimerEntity> context) => 
        context.CreateCollector(TimerMatcher.Completed.Added(), TimerMatcher.PrepareToLoseEvent.Added());
    
    protected override bool Filter(TimerEntity entity) => entity.isCompleted && entity.isPrepareToLoseEvent;

    protected override void Execute(List<TimerEntity> entities) {
        _contexts.gameState.SwitchToState(GameStateExtensions.LOSE);
    }
}