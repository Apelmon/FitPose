using Entitas;
using System.Collections.Generic;

public abstract class CollisionSystem : ReactiveSystem<InputEntity>
{
    protected Contexts _contexts;

    public CollisionSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Collision);
    }

    protected override bool Filter(InputEntity entity)
    {
        if (!entity.hasCollision) return false;
        return Filter(entity.collision.self, entity.collision.other);
    }

    protected abstract bool Filter(GameEntity self, GameEntity other);

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
            Execute(e, e.collision.self, e.collision.other);        
    }

    protected abstract void Execute(InputEntity entity, GameEntity self, GameEntity other);
}