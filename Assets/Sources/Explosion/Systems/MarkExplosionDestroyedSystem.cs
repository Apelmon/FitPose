using System.Collections.Generic;
using System.Threading;
using Entitas;

public class MarkExplosionDestroyedSystem : ReactiveSystem<TimerEntity> {

    private Contexts _contexts;

    public MarkExplosionDestroyedSystem(Contexts contexts) : base(contexts.timer) {
        _contexts = contexts;
    }

    protected override ICollector<TimerEntity> GetTrigger(IContext<TimerEntity> context) => 
        context.CreateCollector(TimerMatcher.Completed.Added(), TimerMatcher.ExplosionTimer.Added());
    
    protected override bool Filter(TimerEntity entity) => entity.isCompleted && entity.hasExplosionTimer;

    protected override void Execute(List<TimerEntity> entities) {
        foreach (var entity in entities) {
            var expEntity = _contexts.game.GetEntityWithId(entity.explosionTimer.value);
            if (expEntity != null) {
                expEntity.isDestroyed = true;
            }
        }
    }
}