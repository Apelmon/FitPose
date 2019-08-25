using System;
using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUiView : UnityUIView, IViewEnableListener, IViewEnableRemovedListener, IAnyCurrentLevelListener {
    [SerializeField] private TextMeshProUGUI _levelNum;
    private UiEntity[] _indicators;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        Enabled = false;
        LinkedEntity.isLevelUi = true;
        
        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);
        
        var levelListenerEntity = contexts.gameState.CreateEntity();
        levelListenerEntity.AddAnyCurrentLevelListener(this);
        
        OnAnyCurrentLevel(null, contexts.gameState.currentLevel.value);
    }

    public void OnAnyCurrentLevel(GameStateEntity entity, int value) {
        if (_levelNum == null) 
            throw new ArgumentNullException("Level num label is missing!");

        _levelNum.text = "Level " + value.ToString();
    }

    public void OnViewEnable(UiEntity entity) {
        Enabled = true;
    }

    public void OnViewEnableRemoved(UiEntity entity) {
        Enabled = false;
    }
}