using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ShakeSystem : IExecuteSystem {
    readonly Contexts _contexts;
    private IGroup<GameEntity> _shakeGroup;
    private List<GameEntity> _shakeBuffer = new List<GameEntity>(10);
    private IGameConfig _config;

    public ShakeSystem(Contexts contexts) {
        _contexts = contexts;
        _config = _contexts.config.gameConfig.value;
        _shakeGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shake, GameMatcher.ShakeDuration,
            GameMatcher.ShakeAmount, GameMatcher.ShakeOriginalPosition));
    }

    public void Execute() {
        foreach (var entity in _shakeGroup.GetEntities(_shakeBuffer)) {
            var viewTransform = entity.view.value.gameObject.transform;
            if (entity.shakeDuration.value > 0) {
                var shakeDurPercent = entity.shakeDuration.value / _config.ShakeDuration;
                var insideUnitCircle = Random.insideUnitCircle;
                var newShapePos = new Vector3(insideUnitCircle.x, insideUnitCircle.y, 0);
                viewTransform.localPosition = entity.shakeOriginalPosition.value +
                                              newShapePos * entity.shakeAmount.value;
                entity.ReplaceShakeDuration(entity.shakeDuration.value -
                                            _contexts.input.deltaTime.value * _config.ShakeDecreaseFactor);
                entity.ReplaceShakeAmount(_config.ShakeAmount * shakeDurPercent);
            }
            else {
                viewTransform.localPosition = entity.shakeOriginalPosition.value;
                entity.RemoveShakeAmount();
                entity.RemoveShakeDuration();
                entity.RemoveShakeOriginalPosition();
                entity.canShake = false;
            }
        }
    }
}