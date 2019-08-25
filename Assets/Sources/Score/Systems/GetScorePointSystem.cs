using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GetScorePointSystem : IExecuteSystem {
    readonly Contexts _contexts;
    private IGroup<GameEntity> _scorePoints;
    private List<GameEntity> _scorePointsBuffer = new List<GameEntity>(2000);
    private float _time;
    private float _maxTime;
    private int _scoreByOneTick;
    private int _scoreOld;

    public GetScorePointSystem(Contexts contexts) {
        _contexts = contexts;
        _scorePoints = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ScorePoint, GameMatcher.Rigidbody));
        _time = 0;
        _maxTime = 0.3f;
        _scoreByOneTick = 0;
        _scoreOld = 0;
    }

    public void Execute() {
        if (_contexts.gameState.isWaitInputState) {
            _scoreOld = 0;
            _scoreByOneTick = 0;
            _time = 0;
        }

        if (!_contexts.gameState.isGameplayState) return;

        foreach (var entity in _scorePoints.GetEntities(_scorePointsBuffer)) {
            if (!entity.rigidbody.value.IsSleeping && entity.hasScorePoint) {
                entity.hasScorePoint = false;

                _time = _maxTime;
                _scoreByOneTick++;
//                _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + 10);

//                Debug.Log(entity.view.value.gameObject.name + " vel -> " +
//                          entity.view.value.gameObject.GetComponent<Rigidbody>().velocity + " angl -> " +
//                          entity.view.value.gameObject.GetComponent<Rigidbody>().angularVelocity +
//                          " parent -> " + entity.view.value.gameObject.transform.parent.name +
//                          " parent pos -> " + entity.view.value.gameObject.transform.parent.transform.position+
//                          " position -> " + entity.view.value.gameObject.transform.position
//                          );

                if (!_contexts.ui.isMainScoreDisplay) {
                    var e = _contexts.ui.CreateEntity();
                    e.isPooled = true;
                    e.isMainScoreDisplay = true;
                    e.AddScoreDisplay(_scoreByOneTick);
                    e.AddAsset("AddScoreDisplay");
                    e.AddUIParent(_contexts.ui.levelUiEntity.uiView.value);
                }
                else {
                    _contexts.ui.mainScoreDisplayEntity.ReplaceScoreDisplay(_scoreByOneTick);
                }
            }
        }

        if (_scoreByOneTick - _scoreOld > 15 && !_contexts.ui.isCurrentPerfectFX) {
            var config = _contexts.config.gameConfig.value;
//            Debug.Log("CREATE PERFECT TEXT -> " + _scoreByOneTick + " --- " + _scoreOld);

            var e = _contexts.ui.CreateEntity();
            e.isCurrentPerfectFX = true;
            e.isPooled = true;
            e.AddAsset("BestFX");
            e.AddUIParent(_contexts.ui.levelUiEntity.uiView.value);

            _scoreOld = _scoreByOneTick;
        }

        _time -= _contexts.input.fixedDeltaTime.value;

        if (_time <= 0 && _scoreByOneTick != 0) {
//            Debug.Log("score by on tick ---> " + _scoreByOneTick + " - display exists -> " + _contexts.ui.isMainScoreDisplay);
            if (_contexts.ui.isMainScoreDisplay) _contexts.ui.mainScoreDisplayEntity.isViewEnable = false;

            _scoreByOneTick = 0;
        }

        _scoreOld = _scoreByOneTick;
    }
}