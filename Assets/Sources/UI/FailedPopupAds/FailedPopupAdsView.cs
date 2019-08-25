using System;
using Entitas;
using TMPro;
using UnityEngine;

public class FailedPopupAdsView : PopupConfig, IAnyCurrentLevelListener {
    [SerializeField] private TextMeshProUGUI _titleText;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        LinkedEntity.isFailedPopupAds = true;
        
        OnViewEnableRemoved(null);
        
        contexts.gameState.CreateEntity().AddAnyCurrentLevelListener(this);
    }

    public void OnAnyCurrentLevel(GameStateEntity entity, int value) {
        if (_titleText == null) 
            throw new ArgumentNullException("_titleText");
        _titleText.text = $"Stage {value}\nContinue?";
    }
}