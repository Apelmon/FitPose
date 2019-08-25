using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class TouchMoveSystem : ReactiveSystem<InputEntity> {
    private Contexts _contexts;
    private float _targetAngle = Single.MinValue;
    private float _quatAngleMax;

    public TouchMoveSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
        _quatAngleMax = 0.3f;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
        context.CreateCollector(InputMatcher.PointerMove.Added(), InputMatcher.PointerPosition.Added());

    protected override bool Filter(InputEntity entity) =>
        _contexts.input.isPointerMove && _contexts.input.hasPointerPosition;

    protected override void Execute(List<InputEntity> entities) {
        var input = _contexts.input;
//        float diff = (input.pointerPosition.value.x / Screen.width) - (input.touchPoint.value.x / Screen.width);

//        diff *= 30;
        
//        var percent = (Math.Abs(diff) > 0) ? diff : 0;
//        input.ReplaceControlsAngleDiff(percent);
        
        input.ReplaceTouchPoint(input.pointerPosition.value);

        if (_contexts.gameState.isGameplayState) {
            var ui = _contexts.ui;
            if (ui.isTutorial && ui.tutorialEntity.isViewEnable) ui.tutorialEntity.isViewEnable = false;
        }
    }
}