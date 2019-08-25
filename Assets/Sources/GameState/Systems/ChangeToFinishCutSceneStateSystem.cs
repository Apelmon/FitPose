using System.Collections.Generic;
using Entitas;

public class ChangeToFinishCutSceneStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToFinishCutSceneStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.FinishCutSceneState.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isFinishCutSceneState;

    protected override void Execute(List<GameStateEntity> entities) {
        var gameState = _contexts.gameState;
        var ui = _contexts.ui;
        
//        if (ui.isStartMenu) ui.startMenuEntity.isViewEnable = false;
    }
}