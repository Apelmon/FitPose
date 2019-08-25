using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public sealed class UnlinkUIViewSystem : ITearDownSystem {
    readonly Contexts _contexts;
    private IGroup<UiEntity> _group;
    private List<UiEntity> _buffer = new List<UiEntity>();

    public UnlinkUIViewSystem(Contexts contexts) {
        _contexts = contexts;
        _group = _contexts.ui.GetGroup(UiMatcher.UiView);
    }

    public void TearDown() {
        foreach (var e in _group.GetEntities(_buffer)) {
            if (e.hasUiView && e.uiView.value != null && e.uiView.value.gameObject != null) {
                e.uiView.value.gameObject.Unlink();
            }
        }
    }
}