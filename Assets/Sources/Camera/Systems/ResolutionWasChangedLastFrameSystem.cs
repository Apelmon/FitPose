using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ResolutionWasChangedLastFrameSystem : ReactiveSystem<GameEntity> {

    private Contexts _contexts;

    public ResolutionWasChangedLastFrameSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
        context.CreateCollector(GameMatcher.ResolutionChanged.Removed());
    
    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> entities) {
        Debug.Log("ResolutionWasChangedLastFrameSystem");
        _contexts.game.CreateEntity().isResolutionWasChangedLastFrame = true;
    }
}