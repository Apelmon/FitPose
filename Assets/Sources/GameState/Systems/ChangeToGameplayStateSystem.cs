using System.Collections.Generic;
using Entitas;

public class ChangeToGameplayStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToGameplayStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.GameplayState.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isGameplayState;

    protected override void Execute(List<GameStateEntity> entities) {
        var ui = _contexts.ui;
    }
}