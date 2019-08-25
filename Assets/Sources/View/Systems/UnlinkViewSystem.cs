using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public sealed class UnlinkViewSystem : ITearDownSystem {
    readonly Contexts _contexts;
    private IGroup<GameEntity> _group;
    private List<GameEntity> _buffer = new List<GameEntity>();

    public UnlinkViewSystem(Contexts contexts) {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.View);
    }

    public void TearDown() {
        foreach (var e in _group.GetEntities(_buffer)) {
            if (e.hasView && e.view.value != null && e.view.value.gameObject != null) {
                e.view.value.gameObject.Unlink();
            }
        }
    }
}