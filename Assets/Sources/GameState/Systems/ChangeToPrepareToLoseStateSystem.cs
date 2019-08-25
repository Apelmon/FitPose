using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ChangeToPrepareToLoseStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToPrepareToLoseStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.PrepareToLose.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isPrepareToLose;

    protected override void Execute(List<GameStateEntity> entities) {

        _contexts.timer.PrepareToLoseTimer(1.0f);
    }
}