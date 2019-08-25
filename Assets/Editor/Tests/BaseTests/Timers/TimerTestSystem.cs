using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TimerTestSystem : ReactiveSystem<TimerEntity> {

    private Contexts _contexts;

    public TimerTestSystem(Contexts contexts) : base(contexts.timer) {
        _contexts = contexts;
    }

    protected override ICollector<TimerEntity> GetTrigger(IContext<TimerEntity> context) =>
        // todo add here the TimerEventComponent DoIt
        context.CreateCollector(TimerMatcher.Completed.Added());
    
    protected override bool Filter(TimerEntity entity) => true;

    protected override void Execute(List<TimerEntity> entities) {
        foreach (var entity in entities) {
            // todo DoIt here instead of the actions under
            entity.isCompleted = false;
            entity.ReplaceTimer(10.0f);
        }
    }
}