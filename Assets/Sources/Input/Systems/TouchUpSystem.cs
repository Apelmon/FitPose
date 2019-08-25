using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TouchUpSystem : ReactiveSystem<InputEntity> {

    private Contexts _contexts;

    public TouchUpSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) => 
        context.CreateCollector(InputMatcher.PointerUp);
    
    protected override bool Filter(InputEntity entity) => entity.isPointerUp;

    protected override void Execute(List<InputEntity> entities) {
    }
}