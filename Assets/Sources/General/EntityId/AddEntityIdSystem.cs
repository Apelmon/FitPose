using Entitas;

public sealed class AddEntityIdSystem : IInitializeSystem, ITearDownSystem {
    readonly Contexts _contexts;

    public AddEntityIdSystem(Contexts contexts) {
        _contexts = contexts;
    }

    public void Initialize() {
        _contexts.game.OnEntityCreated += OnGameEntityCreated;
    }

    public void TearDown() {
        _contexts.game.OnEntityCreated -= OnGameEntityCreated;
    }

    private void OnGameEntityCreated(IContext context, IEntity entity) {
        ((GameEntity) entity).AddId(entity.creationIndex);
    }
}