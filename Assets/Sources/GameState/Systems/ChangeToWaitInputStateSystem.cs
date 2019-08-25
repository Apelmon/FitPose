using System.Collections.Generic;
using Entitas;

public class ChangeToWaitInputStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToWaitInputStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.WaitInputState.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isWaitInputState;

    protected override void Execute(List<GameStateEntity> entities) {
        var gameState = _contexts.gameState;
        var ui = _contexts.ui;
        
        if (ui.isWinPopup) ui.winPopupEntity.isViewEnable = false;
        if (ui.isStartMenu) ui.startMenuEntity.isViewEnable = true;
        if (ui.isLevelUi) ui.levelUiEntity.isViewEnable = true;
    }
}