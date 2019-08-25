using Entitas;

public class StartMenuView : PopupConfig {
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

//        LinkedEntity.isViewEnable = false;
        LinkedEntity.isStartMenu = true;
        
//        OnViewEnable(null);
        OnViewEnableRemoved(null);
    }
}