using System.Collections.Generic;
using Entitas;

public sealed class DecreaseTimerSystem : IExecuteSystem {

    readonly Contexts _contexts;
    private IGroup<TimerEntity> _group;
    private List<TimerEntity> _buffer = new List<TimerEntity>();

    public DecreaseTimerSystem(Contexts contexts) {
        _contexts = contexts;
        _group = _contexts.timer.GetGroup(TimerMatcher.Timer);
    }
    
    public void Execute() {
        foreach (var entity in _group.GetEntities(_buffer)) {
            entity.ReplaceTimer(entity.timer.value - _contexts.input.deltaTime.value);
        }
    }
}