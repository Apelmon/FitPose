using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PrepareToGameplayTimerSystem : ReactiveSystem<TimerEntity> {

    private Contexts _contexts;

    public PrepareToGameplayTimerSystem(Contexts contexts) : base(contexts.timer) {
        _contexts = contexts;
    }

    protected override ICollector<TimerEntity> GetTrigger(IContext<TimerEntity> context) => 
        context.CreateCollector(TimerMatcher.Completed.Added(), TimerMatcher.PrepareToGameplayEvent.Added());
    
    protected override bool Filter(TimerEntity entity) => entity.isCompleted && entity.isPrepareToGameplayEvent;

    protected override void Execute(List<TimerEntity> entities) {
//        if (!_contexts.game.isPlayer) return;
        
        _contexts.gameState.SwitchToState(GameStateExtensions.GAMEPLAY);

//        var player = _contexts.game.playerEntity;
//        player.isAutoAcceleration = true;
//        player.rigidbody.value.IsKinematic = false;
    }
}