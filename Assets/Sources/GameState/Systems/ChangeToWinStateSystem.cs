using System.Collections.Generic;
using Entitas;

public class ChangeToWinStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToWinStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.WinState.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isWinState;

    protected override void Execute(List<GameStateEntity> entities) {
        var gameState = _contexts.gameState;
        var ui = _contexts.ui;
        
        if (ui.isWinPopup) ui.winPopupEntity.isViewEnable = true;
        if (ui.isLevelUi) ui.levelUiEntity.isViewEnable = false;
    }
}