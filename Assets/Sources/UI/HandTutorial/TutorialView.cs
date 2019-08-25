using Entitas;

public class TutorialView : UnityUIView, IViewEnableListener, IViewEnableRemovedListener {
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        Enabled = false;
        LinkedEntity.isTutorial = true;
        
        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);
    }

    public void OnViewEnable(UiEntity entity) {
        Enabled = true;
    }

    public void OnViewEnableRemoved(UiEntity entity) {
        Enabled = false;
    }
}