using System;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class PrepareToGameplayStateSystem : IExecuteSystem {
    readonly Contexts _contexts;
    
    public PrepareToGameplayStateSystem(Contexts contexts) {
        _contexts = contexts;
    }
    
    public void Execute() {
        if (_contexts.input.isPointerDown && _contexts.gameState.isWaitInputState) {
            var ui = _contexts.ui;
            if (ui.isStartMenu) ui.startMenuEntity.isViewEnable = false;
            if (ui.isTutorial) ui.tutorialEntity.isViewEnable = true;
            
            _contexts.gameState.SwitchToState(GameStateExtensions.PREPARE_TO_GAMEPLAY);
            
//            if (!_contexts.game.isPlayer) throw new NullReferenceException("Player is missing!");
//    
//            var config = _contexts.config.gameConfig.value;
//            var player = _contexts.game.playerEntity;
//            player.rigidbody.value.IsKinematic = true;
//            player.ReplaceTurnAngle(0);
//
//            var switchTime = config.SwitchToRaceTime;
//            
//            var steerWheels = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.WheelCollider));
//            foreach (var wheel in steerWheels) {
//                wheel.wheelCollider.value.BrakeTorque = 0;
//                if (wheel.canSteer) {
//                    DOTween.To(
//                        () => wheel.wheelCollider.value.SteerAngle,
//                        x => wheel.wheelCollider.value.SteerAngle = x, 0, switchTime).SetEase(Ease.InSine);
//                }
//            }
//            
//            var camera = _contexts.game.mainCameraEntity.view.value.gameObject.transform;
//            var wantedPosition = new Vector3(config.RaceCameraPosition.x, config.RaceCameraPosition.y,
//                player.view.value.gameObject.transform.position.z + config.RaceCameraPosition.z);
//            camera.DOMove(wantedPosition, switchTime).SetEase(Ease.InOutSine);

            _contexts.timer.PrepareToGameplayTimer(1.0f);
        }
    }
}