using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TouchDownSystem : ReactiveSystem<InputEntity> {

    private Contexts _contexts;

    public TouchDownSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) => 
        context.CreateCollector(InputMatcher.PointerDown);
    
    protected override bool Filter(InputEntity entity) => entity.isPointerDown;

    protected override void Execute(List<InputEntity> entities) {
        _contexts.input.ReplaceTouchPoint(_contexts.input.pointerPosition.value);
    }
}