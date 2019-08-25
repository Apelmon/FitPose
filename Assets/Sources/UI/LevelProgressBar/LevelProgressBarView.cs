using System;
using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBarView : UnityUIView, IViewEnableListener, IViewEnableRemovedListener, IAnyCurrentLevelListener {
    [SerializeField] private TextMeshProUGUI _label01;
    [SerializeField] private TextMeshProUGUI _label02;
    [SerializeField] private Image _fillImage;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        Enabled = false;
        LinkedEntity.isLevelProgressBar = true;
        
        LinkedEntity.AddViewEnableListener(this);
        LinkedEntity.AddViewEnableRemovedListener(this);

        var levelListenerEntity = contexts.gameState.CreateEntity();
        levelListenerEntity.AddAnyCurrentLevelListener(this);
    }

    public void OnAnyCurrentLevel(GameStateEntity entity, int value) {
        if (_label01 == null) 
            throw new ArgumentNullException("Label 01 is missing!");

        if (_label02 == null) 
            throw new ArgumentNullException("Label 02 is missing!");
        
        _label01.text = value.ToString();
        _label02.text = (value + 1).ToString();
    }

    // todo event when level progress is updated
    public void UpdateProgress(float value) {
        if (_fillImage == null) 
            throw new ArgumentNullException("Fill image is missing!");

        _fillImage.fillAmount = value;
    }

    public void OnViewEnable(UiEntity entity) {
        Enabled = true;
    }

    public void OnViewEnableRemoved(UiEntity entity) {
        Enabled = false;
    }
}