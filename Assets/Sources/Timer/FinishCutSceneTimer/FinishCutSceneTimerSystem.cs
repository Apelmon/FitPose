using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FinishCutSceneTimerSystem : ReactiveSystem<TimerEntity> {

    private Contexts _contexts;

    public FinishCutSceneTimerSystem(Contexts contexts) : base(contexts.timer) {
        _contexts = contexts;
    }

    protected override ICollector<TimerEntity> GetTrigger(IContext<TimerEntity> context) => 
        context.CreateCollector(TimerMatcher.Completed.Added(), TimerMatcher.FinishCutSceneEvent.Added());
    
    protected override bool Filter(TimerEntity entity) => entity.isCompleted && entity.isFinishCutSceneEvent;

    protected override void Execute(List<TimerEntity> entities) {
//        var player = _contexts.game.playerEntity;
//        player.rigidbody.value.
        
        _contexts.gameState.SwitchToState(GameStateExtensions.WIN);
    }
}