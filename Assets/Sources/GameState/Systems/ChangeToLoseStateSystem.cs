using System.Collections.Generic;
using Entitas;

public class ChangeToLoseStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToLoseStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.LoseState.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isLoseState;

    protected override void Execute(List<GameStateEntity> entities) {
        var ui = _contexts.ui;

        if (ui.isFailedPopup) ui.failedPopupEntity.isViewEnable = true;
        if (ui.isLevelUi) ui.levelUiEntity.isViewEnable = false;
    }
}