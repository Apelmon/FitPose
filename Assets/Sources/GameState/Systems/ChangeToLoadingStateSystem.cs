using System.Collections.Generic;
using Entitas;

public class ChangeToLoadingStateSystem : ReactiveSystem<GameStateEntity> {

    private Contexts _contexts;

    public ChangeToLoadingStateSystem(Contexts contexts) : base(contexts.gameState) {
        _contexts = contexts;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context) => 
        context.CreateCollector(GameStateMatcher.LoadingState.Added());
    
    protected override bool Filter(GameStateEntity entity) => entity.isLoadingState;

    protected override void Execute(List<GameStateEntity> entities) {
        var ui = _contexts.ui;
        
        if (ui.isWinPopup) ui.winPopupEntity.isViewEnable = false;
        if (ui.isFailedPopup) ui.failedPopupEntity.isViewEnable = false;
    }
}