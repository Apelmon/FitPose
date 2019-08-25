using System.Collections.Generic;
using Entitas;

public sealed class MarkTimerAsCompletedSystem : IExecuteSystem {

    readonly Contexts _contexts;
    private IGroup<TimerEntity> _group;
    private List<TimerEntity> _buffer = new List<TimerEntity>();

    public MarkTimerAsCompletedSystem(Contexts contexts) {
        _contexts = contexts;
        _group = _contexts.timer.GetGroup(TimerMatcher.Timer);
    }
    
    public void Execute() {
        foreach (var entity in _group.GetEntities(_buffer)) {
            if (entity.timer.value < 0f) {
                entity.RemoveTimer();
                entity.isCompleted = true;
            }
        }
    }
}