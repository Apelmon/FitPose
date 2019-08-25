//#define ENTITAS_DISABLE_VISUAL_DEBUGGING

using System;
using System.Collections.Generic;
using Entitas;
//using GameAnalyticsSDK;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour {
    [SerializeField] private ScriptableGameConfig _gameConfig;
    
    private Contexts _contexts;

    private FixedUpdateSystems _fixedUpdateSystems;
    private UpdateSystems _updateSystems;
    private LateUpdateSystems _lateUpdateSystems;

    private void Awake() {
        Application.targetFrameRate = 60;
        
        var random = new Random(DateTime.UtcNow.Millisecond);
        UnityEngine.Random.InitState(random.Next());
        Rand.game = new Rand(random.Next());
        
        _contexts = Contexts.sharedInstance;
        
        _contexts.config.SetGameConfig(_gameConfig);
        
//        _contexts.gameState.isInitialization = true;

        _updateSystems = new UpdateSystems(_contexts);
        _fixedUpdateSystems = new FixedUpdateSystems(_contexts);
        _lateUpdateSystems = new LateUpdateSystems(_contexts);

        _updateSystems.ActivateReactiveSystems();
        _fixedUpdateSystems.ActivateReactiveSystems();
        _lateUpdateSystems.ActivateReactiveSystems();

        _updateSystems.Initialize();
        _fixedUpdateSystems.Initialize();
        _lateUpdateSystems.Initialize();
    }

    private void FixedUpdate() {
        _fixedUpdateSystems.Execute();
        _fixedUpdateSystems.Cleanup();
    }

    private void Update() {
        _updateSystems.Execute();
        _updateSystems.Cleanup();
    }

    private void LateUpdate() {
        _lateUpdateSystems.Execute();
        _lateUpdateSystems.Cleanup();
    }

    private void OnDestroy() {
        _updateSystems.TearDown();
        _updateSystems.DeactivateReactiveSystems();
        _updateSystems.ClearReactiveSystems();

        _fixedUpdateSystems.TearDown();
        _fixedUpdateSystems.DeactivateReactiveSystems();
        _fixedUpdateSystems.ClearReactiveSystems();

        _lateUpdateSystems.TearDown();
        _lateUpdateSystems.DeactivateReactiveSystems();
        _lateUpdateSystems.ClearReactiveSystems();

        foreach (var context in _contexts.allContexts) {
//            if (!(context is ConfigContext)) {
                context.Reset();
//            }
        }

//        _contexts.Reset();
    }

#if !ENTITAS_DISABLE_VISUAL_DEBUGGING
    private void OnGUI() {
//        var state = _contexts.gameState;
//        GUILayout.Label((state.isJumping ? "V" : "O") + " Jumping");
//        GUILayout.Label((state.isApplyJump ? "V" : "O") + " ApplyJump");
//        GUILayout.Label((state.isJumpImpulseFired ? "V" : "O") + " JumpImpulseFired");
//        GUILayout.Label((state.isJumpTimedOut ? "V" : "O") + " JumpTimedOut");
//        GUILayout.Label((state.isLanded ? "V" : "O") + " Landed");
//        GUILayout.Space(20f);
//        GUILayout.Label(state.lastJumpTime.Value + " LastJumpTime");
//        GUILayout.Label(state.currentJumpCount.Value + " JumpCount");
//        GUILayout.Label(state.currentMaxVelocity.Value + " MaxVelocity");

//        GUILayout.Label("Game mode -> " + PlayerPrefs.GetInt(PlayerPrefsScript.GAME_MODE));
    }
#endif
}